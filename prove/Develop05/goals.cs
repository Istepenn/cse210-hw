public abstract class Goal {
    private string _name;
    private string _description;
    protected double _points;
    protected double _timesCompleted;
    protected string _formattedString;


    public Goal(){
        this._name = SetName();
        this._description = SetDescription();
        this._points = setPoints();
        this._timesCompleted = 0;
    }
    public Goal(string name, string description, double points, int timesFinished){
        this._name = name;
        this._description = description;
        this._points = points;
        this._timesCompleted = timesFinished;
    }

    protected string SetName(){
        Console.Write("What is the name of your goal? ");
        return Console.ReadLine();
    }
    protected string SetDescription(){
        Console.Write("What is a short description of it? ");
        return Console.ReadLine();
    }
    protected int setPoints(){
        Console.Write("What is the amount of points assosciated with this goal? ");
        return int.Parse(Console.ReadLine());
    }
    public string GetName(){
        return this._name;
    }
    public string GetDescription(){
        return this._description;
    }
    public double GetPoints(){
        return this._points;
    }
    public double GetTimesFinished(){
        return this._timesCompleted;
    }
    public virtual int GetReachBonus(){
        return 0;
    }
    public virtual int GetBonusPoints(){
        return 0;
    }

    public double AwardPoints(double points){
        Console.WriteLine($"Congratualations! You have earned {this._points} points!\n");
        return points;
    }

    public virtual double RecordEvent(){
        this._timesCompleted += 1;
        return 0;
    }

    public abstract bool IsComplete();

    public virtual void ListGoal(){
        if(IsComplete()){
            Console.Write($" [X] {this._name} ({this._description})");
        }
        if(!IsComplete()){
            Console.Write($" [ ] {this._name} ({this._description})");
        }
    }

    public virtual string SerializeSelf(){
        this._formattedString += $":{this.GetName()}"
                                +$":{this.GetDescription()}:{this.GetPoints()}"
                                +$":{this.GetTimesFinished()}";
        return this._formattedString;
    }
}

public class Simple : Goal {
    public Simple() : base() {
        
    }
    public Simple(string name, string description, double points, int timesFinished):
    base(name, description, points, timesFinished){

    }

    public override bool IsComplete(){
        if(this._timesCompleted >= 1){
            return true;
        }
        else {
            return false;
        }
    }
    public override double RecordEvent(){
        base.RecordEvent();
        return AwardPoints(this._points);
    }
    public override string SerializeSelf(){
        this._formattedString = "simple";
        return base.SerializeSelf();
    }
    public override void ListGoal() {
        base.ListGoal();
        Console.Write($" --- Simple Goal\n");
    }

}

public class Eternal : Goal {

    public Eternal() : base() {
        
    }
    public Eternal(string name, string description, double points, int timesFinished):
    base(name, description, points, timesFinished) {
        
    }
    public override bool IsComplete(){
        return false;
    }
    public override double RecordEvent(){
        base.RecordEvent();
        return AwardPoints(this._points);
    }
    public override string SerializeSelf(){
        this._formattedString = "eternal";
        return base.SerializeSelf();
    }
    public override void ListGoal() {
        base.ListGoal();
        Console.Write($" --- Eternal Goal\n");
    }
    
}

public class Checklist : Goal {
    private int _reachBonus;
    private int _bonusPoints;
    
    public Checklist() : base() {

        this._reachBonus = SetReachBonus();
        this._bonusPoints = SetBonusPoints();
    }
    public Checklist(string name, string description, double points, int timesFinished, int reach, int bonus):
    base(name, description, points, timesFinished) {

        this._reachBonus = reach;
        this._bonusPoints = bonus;
    }

    protected int SetReachBonus(){
        Console.Write("How many times does this goal need to be accomplished for a bonus? ");
        return int.Parse(Console.ReadLine());
    }
    protected int SetBonusPoints(){
        Console.Write("What is the bonus for accomplishing it that many times?");
        return int.Parse(Console.ReadLine());
    }
    public override int GetReachBonus(){
        return this._reachBonus;
    }
    public override int GetBonusPoints(){
        return this._bonusPoints;
    }

    public override void ListGoal() {
        base.ListGoal();
        Console.Write($" --- Currently completed: {this._timesCompleted}/{this._reachBonus}\n");
    }
    public override bool IsComplete(){
        if(this._timesCompleted >= this._reachBonus){
            return true;
        }
        else {
            return false;
        }
    }
    public override double RecordEvent(){
        base.RecordEvent();
        if(IsComplete()){
            return AwardPoints(this._bonusPoints + this._points);
        }
        else {
            return AwardPoints(this._points);
        }
    }
    public override string SerializeSelf(){
        this._formattedString = "checklist";
        base.SerializeSelf();
        this._formattedString += $":{this.GetReachBonus()}:{this.GetBonusPoints()}";
        return this._formattedString;
    }
}