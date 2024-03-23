using System;
using System.Threading;

// Base class for all activities
public class Activity
{
    private string name;
    private string description;
    protected int durationInSeconds;

    public Activity(string name, string description)
    {
        this.name = name;
        this.description = description;
    }

    public virtual void StartActivity(int durationInSeconds)
    {
        this.durationInSeconds = durationInSeconds;
        Console.WriteLine($"Starting {name} activity...");
        Thread.Sleep(2000);
    }

    public virtual void Pause(int milliseconds)
    {
        Thread.Sleep(milliseconds);
    }

    public virtual void EndActivity()
    {
        Console.WriteLine($"{name} activity completed successfully.");
    }
}

// Breathing activity
public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing", "This activity will help you relax by guiding you through breathing exercises.") { }

    public override void StartActivity(int durationInSeconds)
    {
        base.StartActivity(durationInSeconds);
        Console.WriteLine("Clear your mind and focus on your breathing.");
        for (int i = 0; i < durationInSeconds; i += 2)
        {
            Console.WriteLine("Breathe in...");
            Pause(1000);
            Console.WriteLine("Breathe out...");
            Pause(1000);
        }
        base.EndActivity();
    }
}

// Reflection activity
public class ReflectionActivity : Activity
{
    private string[] prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private string[] questions = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity() : base("Reflection", "This activity will help you reflect on past experiences.") { }

    public override void StartActivity(int durationInSeconds)
    {
        base.StartActivity(durationInSeconds);
        Random rand = new Random();
        int promptIndex = rand.Next(prompts.Length);
        Console.WriteLine(prompts[promptIndex]);
        foreach (string question in questions)
        {
            Console.WriteLine(question);
            Pause(3000);
        }
        base.EndActivity();
    }
}

// Listing activity
public class ListingActivity : Activity
{
    private string[] listingPrompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing", "This activity will help you list positive aspects of your life.") { }

    public override void StartActivity(int durationInSeconds)
    {
        base.StartActivity(durationInSeconds);
        Random rand = new Random();
        int promptIndex = rand.Next(listingPrompts.Length);
        Console.WriteLine(listingPrompts[promptIndex]);
        Console.WriteLine($"You have {durationInSeconds} seconds to list as many items as you can.");
        Pause(durationInSeconds * 1000);
        Console.WriteLine("Listing activity completed.");
    }
}

// Menu class
public class Menu
{
    public void DisplayMenu()
    {
        Console.WriteLine("Select an activity:");
        Console.WriteLine("1. Breathing Activity");
        Console.WriteLine("2. Reflection Activity");
        Console.WriteLine("3. Listing Activity");
        Console.WriteLine("4. Exit");
    }

    public Activity ChooseActivity()
    {
        Console.Write("Enter your choice: ");
        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4)
        {
            Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
            Console.Write("Enter your choice: ");
        }
        switch (choice)
        {
            case 1:
                return new BreathingActivity();
            case 2:
                return new ReflectionActivity();
            case 3:
                return new ListingActivity();
            default:
                Environment.Exit(0);
                return null;
        }
    }
}

// Main program
class Program
{
    static void Main(string[] args)
    {
        Menu menu = new Menu();
        while (true)
        {
            menu.DisplayMenu();
            Activity activity = menu.ChooseActivity();
            Console.Write("Enter duration in seconds: ");
            int duration;
            while (!int.TryParse(Console.ReadLine(), out duration) || duration <= 0)
            {
                Console.WriteLine("Invalid input. Duration must be a positive integer.");
                Console.Write("Enter duration in seconds: ");
            }
            activity.StartActivity(duration);
        }
    }
}
