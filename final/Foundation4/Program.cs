using System;
using System.Collections.Generic;

abstract class Exercise
{
    public DateTime Date { get; set; }
    public int Duration { get; set; }

    public abstract string GetSummary();
}

class RunningExercise : Exercise
{
    public double Distance { get; set; }

    public override string GetSummary()
    {
        double speed = Distance / (Duration / 60.0);
        double pace = Duration / Distance;

        return $"{Date.ToShortDateString()} Running ({Duration} min) - Distance: {Distance} miles, Speed: {speed} mph, Pace: {pace} min/mile";
    }
}

class CyclingExercise : Exercise
{
    public double Speed { get; set; }

    public override string GetSummary()
    {
        double distance = Speed * (Duration / 60.0);
        double pace = Duration / distance;

        return $"{Date.ToShortDateString()} Cycling ({Duration} min) - Distance: {distance} miles, Speed: {Speed} mph, Pace: {pace} min/mile";
    }
}

class SwimmingExercise : Exercise
{
    public int Laps { get; set; }

    public override string GetSummary()
    {
        double distance = Laps * 50 / 1000.0; // assuming 50 meters per lap
        double speed = distance / (Duration / 60.0);
        double pace = Duration / distance;

        return $"{Date.ToShortDateString()} Swimming ({Duration} min) - Distance: {distance} km, Speed: {speed} kph, Pace: {pace} min/km";
    }
}

class Program4
{
    static void Main(string[] args)
    {
        List<Exercise> exercises = new List<Exercise> {
            new RunningExercise { Date = DateTime.Now, Duration = 30, Distance = 3.0 },
            new CyclingExercise { Date = DateTime.Now, Duration = 30, Speed = 12.0 },
            new SwimmingExercise { Date = DateTime.Now, Duration = 30, Laps = 20 }
        };

        foreach (var exercise in exercises)
        {
            Console.WriteLine(exercise.GetSummary());
        }
    }
}
