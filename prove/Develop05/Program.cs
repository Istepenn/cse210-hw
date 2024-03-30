using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    abstract class Goal
    {
        public string Description { get; }
        public bool Completed { get; protected set; }

        public Goal(string description)
        {
            Description = description;
            Completed = false;
        }

        public abstract int CalculatePoints();
        public abstract string GetProgress();
    }

    class SimpleGoal : Goal
    {
        private int Points { get; }

        public SimpleGoal(string description, int points) : base(description)
        {
            Points = points;
        }

        public override int CalculatePoints()
        {
            return Completed ? Points : 0;
        }

        public override string GetProgress()
        {
            return Completed ? "[X] Completed" : "[ ] Incomplete";
        }
    }

    class EternalGoal : Goal
    {
        private int Points { get; }

        public EternalGoal(string description, int points) : base(description)
        {
            Points = points;
        }

        public override int CalculatePoints()
        {
            return Completed ? Points : 0;
        }

        public override string GetProgress()
        {
            return "[Eternal]";
        }
    }

    class ChecklistGoal : Goal
    {
        private int TargetCount { get; }
        private int PointsPerCompletion { get; }
        private int BonusPoints { get; }
        private int CompletionCount { get; set; }

        public ChecklistGoal(string description, int targetCount, int pointsPerCompletion, int bonusPoints) : base(description)
        {
            TargetCount = targetCount;
            PointsPerCompletion = pointsPerCompletion;
            BonusPoints = bonusPoints;
            CompletionCount = 0;
        }

        public override int CalculatePoints()
        {
            int totalPoints = Completed ? BonusPoints : 0;
            totalPoints += CompletionCount * PointsPerCompletion;
            return totalPoints;
        }

        public override string GetProgress()
        {
            return Completed ? $"[X] Completed ({CompletionCount}/{TargetCount})" : $"[ ] Incomplete ({CompletionCount}/{TargetCount})";
        }

        public void RecordCompletion()
        {
            CompletionCount++;
            if (CompletionCount >= TargetCount)
            {
                Completed = true;
            }
        }
    }

    class GoalManager
    {
        public List<Goal> Goals { get; }

        public GoalManager()
        {
            Goals = new List<Goal>();
        }

        public void AddGoal(Goal goal)
        {
            Goals.Add(goal);
        }

        public void RecordProgress(int index)
        {
            if (index >= 0 && index < Goals.Count)
            {
                Goals [index].Completed = true ;
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

        public void DisplayGoals()
        {
            Console.WriteLine("\nCurrent Goals:");
            for (int i = 0; i < Goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Goals[i].Description} - Points: {Goals[i].CalculatePoints()} - {Goals[i].GetProgress()}");
            }
        }

        public void SaveGoalsToFile(string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (Goal goal in Goals)
                {
                    writer.WriteLine($"{goal.GetType().Name},{goal.Description},{goal.Completed}");
                    if (goal is ChecklistGoal checklistGoal)
                    {
                        writer.WriteLine($"{checklistGoal.TargeCount},{checklistGoal.PointsPerCompletion},{checklistGoal.BonusPoints},{checklistGoal.CompletionCount}");
                    }
                }
            }
        }

        public void LoadGoalsFromFile(string fileName)
        {
            Goals.Clear();
            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length < 3)
                    {
                        Console.WriteLine("Invalid format in file.");
                        return;
                    }
                    string type = parts[0];
                    string description = parts[1];
                    bool completed = bool.Parse(parts[2]);

                    switch (type)
                    {
                        case nameof(SimpleGoal):
                            Goals.Add(new SimpleGoal(description, 0) { Completed = completed });
                            break;
                        case nameof (EternalGoal):
                            Goals.Add (new EternalGoal(description, 0) { Completed = completed }
                            break;
                        case nameof(ChecklistGoal):
                            if (parts.Length < 7)
                            {
                                Console.WriteLine("Invalid format in file.");
                                return;
                            }
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
                        default:
                            Console.WriteLine("Unknown goal type in file.");
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
            GoalManager goalManager = new GoalManager();
            bool running = true;

            while (running)
            {
                DisplayMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        goalManager.DisplayGoals();
                        break;
                    case "2":
                        AddGoal(goalManager);
                        break;
                    case "3":
                        RecordProgress(goalManager);
                        break;
                    case "4":
                        SaveGoals(goalManager);
                        break;
                    case "5":
                        LoadGoals(goalManager);
                        break;
                    case "6":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private static void DisplayMenu()
        {
            Console.WriteLine("\nEternal Quest - Main Menu");
            Console.WriteLine("1. View Goals");
            Console.WriteLine("2. Add Goal");
            Console.WriteLine("3. Record Progress");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Quit");
            Console.Write("Enter your choice: ");
        }

        private static void AddGoal(GoalManager goalManager)
        {
            Console.WriteLine("\nAdd New Goal:");
            Console.WriteLine("1. Simple Goal");
            Console.WriteLine("2. Eternal Goal");
            Console.WriteLine("3. Checklist Goal");
            Console.Write("Enter goal type: ");
            string goalType = Console.ReadLine();

            Console.Write("Enter description for the goal: ");
            string description = Console.ReadLine();

            switch (goalType)
            {
                case "1":
                    Console.Write("Enter points for completing the simple goal: ");
                    if (int.TryParse(Console.ReadLine(), out int points))
                    {
                        goalManager.AddGoal(new SimpleGoal(description, points));
                    }
                    else
                    {
                        Console.WriteLine("Invalid input for points. Goal not added.");
                    }
                    break;
                case "2":
                    Console.Write("Enter points for completing the eternal goal: ");
                    if (int.TryParse(Console.ReadLine(), out int eternalPoints))
                    {
                        goalManager.AddGoal(new EternalGoal(description, eternalPoints));
                    }
                    else
                    {
                        Console.WriteLine("Invalid input for points. Goal not added.");
                    }
                    break;
                case "3":
                    Console.Write("Enter target count for the checklist goal: ");
                    if (int.TryParse(Console.ReadLine(), out int targetCount))
                    {
                        Console.Write("Enter points per completion for the checklist goal: ");
                        if (int.TryParse(Console.ReadLine(), out int pointsPerCompletion))
                        {
                            Console.Write("Enter bonus points for completing all items in the checklist: ");
                            if (int.TryParse(Console.ReadLine(), out int bonusPoints))
                            {
                                goalManager.AddGoal(new ChecklistGoal(description, targetCount, pointsPerCompletion, bonusPoints));
                            }
                            else
                            {
                                Console.WriteLine("Invalid input for bonus points. Goal not added.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input for points per completion. Goal not added.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input for target count. Goal not added.");
                    }
                    break;
                default:
                    Console.WriteLine("Invalid goal type. Goal not added.");
                    break;
            }
        }

        private static void RecordProgress(GoalManager goalManager)
        {
            Console.WriteLine("\nRecord Progress - Choose a Goal:");
            goalManager.DisplayGoals();
            Console.Write("Enter the index of the goal to record progress: ");
            if (int.TryParse(Console.ReadLine(), out int index))
            {
                goalManager.RecordProgress(index - 1);
            }
            else
            {
                Console.WriteLine("Invalid input for goal index.");
            }
        }

        private static void SaveGoals(GoalManager goalManager)
        {
            Console.Write("\nEnter file name to save goals: ");
            string fileName = Console.ReadLine();
            goalManager.SaveGoalsToFile(fileName);
            Console.WriteLine("Goals saved successfully.");
        }

        private static void LoadGoals(GoalManager goalManager)
        {
            Console.Write("\nEnter file name to load goals: ");
            string fileName = Console.ReadLine();
            goalManager.LoadGoalsFromFile(fileName);
            Console.WriteLine("Goals loaded successfully.");
        }
    }
}
