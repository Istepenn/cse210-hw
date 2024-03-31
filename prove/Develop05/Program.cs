using System;
using System.Collections.Generic;
using System.IO;

// Define the base class Goal
public abstract class Goal
{
    public string Description { get; set; }
    public bool Completed { get; set; }

    public Goal(string description)
    {
        Description = description;
        Completed = false;
    }

    // Abstract method to calculate points for completing the goal
    public abstract int CalculatePoints();

    // Abstract method to display the progress of the goal
    public abstract string GetProgress();
}

// Define derived class SimpleGoal
public class SimpleGoal : Goal
{
    public int Value { get; set; }

    public SimpleGoal(string description, int value) : base(description)
    {
        Value = value;
    }

    public override int CalculatePoints()
    {
        return Value;
    }

    public override string GetProgress()
    {
        return Completed ? "[X] Completed" : "[ ] Not Completed";
    }
}

// Define derived class EternalGoal
public class EternalGoal : Goal
{
    public int Value { get; set; }

    public EternalGoal(string description, int value) : base(description)
    {
        Value = value;
    }

    public override int CalculatePoints()
    {
        return Value;
    }

    public override string GetProgress()
    {
        return "[Eternal Goal]";
    }
}

// Define derived class ChecklistGoal
public class ChecklistGoal : Goal
{
    public int TargetCount { get; set; }
    public int PointsPerCompletion { get; set; }
    public int BonusPoints { get; set; }
    public int CompletionCount { get; set; }

    public ChecklistGoal(string description, int targetCount, int pointsPerCompletion, int bonusPoints) : base(description)
    {
        TargetCount = targetCount;
        PointsPerCompletion = pointsPerCompletion;
        BonusPoints = bonusPoints;
        CompletionCount = 0;
    }

    public void RecordCompletion()
    {
        CompletionCount++;
        if (CompletionCount == TargetCount)
        {
            // Award bonus points on completion
        }
    }

    public override int CalculatePoints()
    {
        return CompletionCount * PointsPerCompletion + (Completed ? BonusPoints : 0);
    }

    public override string GetProgress()
    {
        return $"Completed {CompletionCount}/{TargetCount} times";
    }
}

// Define the EternalQuestProgram class
public class EternalQuestProgram
{
    private List<Goal> Goals;

    public EternalQuestProgram()
    {
        Goals = new List<Goal>();
    }

    // Method to add a new goal
    public void AddGoal(Goal goal)
    {
        Goals.Add(goal);
    }

    // Method to record completion of a goal by index
    public void RecordGoalCompletion(int index)
    {
        if (index >= 0 && index < Goals.Count)
        {
            Goals[index].Completed = true;
            if (Goals[index] is ChecklistGoal checklistGoal)
            {
                checklistGoal.RecordCompletion();
            }
            Console.WriteLine("Progress recorded successfully.");
        }
        else
        {
            Console.WriteLine("Invalid goal index.");
        }
    }

    // Method to display all goals
    public void DisplayGoals()
    {
        Console.WriteLine("\nCurrent Goals:");
        for (int i = 0; i < Goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {Goals[i].Description} - Points: {Goals[i].CalculatePoints()} - {Goals[i].GetProgress()}");
        }
    }

    // Method to save goals to a file
    public void SaveGoalsToFile(string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (Goal goal in Goals)
            {
                writer.WriteLine($"{goal.GetType().Name},{goal.Description},{goal.Completed}");
                if (goal is ChecklistGoal checklistGoal)
                {
                    writer.WriteLine($"{checklistGoal.TargetCount},{checklistGoal.PointsPerCompletion},{checklistGoal.BonusPoints},{checklistGoal.CompletionCount}");
                }
            }
        }
    }

    // Method to load goals from a file
    public void LoadGoalsFromFile(string fileName)
    {
        Goals.Clear();
        using (StreamReader reader = new StreamReader(fileName))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(',');
                string type = parts[0];
                string description = parts[1];
                bool completed = bool.Parse(parts[2]);

                switch (type)
                {
                    case nameof(SimpleGoal):
                        Goals.Add(new SimpleGoal(description, 0) { Completed = completed });
                        break;
                    case nameof(EternalGoal):
                        Goals.Add(new EternalGoal(description, 0) { Completed = completed });
                        break;
                    case nameof(ChecklistGoal):
                        int targetCount = int.Parse(parts[3]);
                        int pointsPerCompletion = int.Parse(parts[4]);
                        int bonusPoints = int.Parse(parts[5]);
                        int completionCount = int.Parse(parts[6]);
                        ChecklistGoal newChecklistGoal = new ChecklistGoal(description, targetCount, pointsPerCompletion, bonusPoints)
                        {
                            Completed = completed,
                            CompletionCount = completionCount
                        };
                        Goals.Add(newChecklistGoal);
                        break;
                }
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Test the EternalQuestProgram functionality
        EternalQuestProgram questProgram = new EternalQuestProgram();

        // Add some sample goals
        questProgram.AddGoal(new SimpleGoal("Run a marathon", 1000));
        questProgram.AddGoal(new EternalGoal("Read scriptures daily", 100));
        questProgram.AddGoal(new ChecklistGoal("Attend the temple", 10, 50, 500));

        // Display goals
        questProgram.DisplayGoals();

        // Record completion of a goal
        questProgram.RecordGoalCompletion(0);

        // Display goals after completion
        questProgram.DisplayGoals();

        // Save goals to a file
        questProgram.SaveGoalsToFile("goals.txt");

        // Load goals from a file
        questProgram.LoadGoalsFromFile("goals.txt");

        // Display goals loaded from file
        questProgram.DisplayGoals();
    }
}
