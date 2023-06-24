using System;
using System.Collections.Generic;

// Base class for all goals
public abstract class Goal
{
    public string Name { get; set; }
    public int Value { get; set; }
    public bool IsCompleted { get; set; }

    public Goal(string name, int value)
    {
        Name = name;
        Value = value;
        IsCompleted = false;
    }

    // Abstract method to record progress for different goal types
    public abstract void RecordProgress();

    public override string ToString()
    {
        return $"{(IsCompleted ? "[X]" : "[ ]")} {Name}";
    }
}

// Simple goal class
public class SimpleGoal : Goal
{
    public SimpleGoal(string name, int value) : base(name, value)
    {
    }

    public override void RecordProgress()
    {
        IsCompleted = true;
    }
}

// Eternal goal class
public class EternalGoal : Goal
{
    public EternalGoal(string name, int value) : base(name, value)
    {
    }

    public override void RecordProgress()
    {
        // For an eternal goal, each recording counts as progress
        Value++;
    }
}

// Checklist goal class
public class ChecklistGoal : Goal
{
    private int targetCount;
    private int completedCount;

    public ChecklistGoal(string name, int value, int targetCount) : base(name, value)
    {
        this.targetCount = targetCount;
        completedCount = 0;
    }

    public override void RecordProgress()
    {
        completedCount++;
        if (completedCount >= targetCount)
        {
            IsCompleted = true;
            Value += (Value * targetCount); // Apply the bonus points
        }
        else
        {
            Value += Value; // Regular points for each recording
        }
    }

    public override string ToString()
    {
        return $"{base.ToString()} Completed {completedCount}/{targetCount} times";
    }
}

// Main program
public class Program
{
    private static List<Goal> goals = new List<Goal>();
    private static int score = 0;

    public static void Main(string[] args)
    {
        bool isRunning = true;

        LoadGoals(); // Load saved goals and score

        while (isRunning)
        {
            Console.Clear();
            Console.WriteLine("Eternal Quest Program");
            Console.WriteLine("---------------------");
            Console.WriteLine();

            Console.WriteLine("1. View Goals");
            Console.WriteLine("2. Add Goal");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. View Score");
            Console.WriteLine("5. Save and Exit");

            Console.WriteLine();
            Console.Write("Enter your choice (1-5): ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    ViewGoals();
                    break;
                case "2":
                    AddGoal();
                    break;
                case "3":
                    RecordEvent();
                    break;
                case "4":
                    ViewScore();
                    break;
                case "5":
                    SaveAndExit();
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid input. Please try again.");
                    break;
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }

    // Load saved goals and score from storage
    private static void LoadGoals()
    {
        // Add sample goals for testing
        goals.Add(new SimpleGoal("Run a Marathon", 1000));
        goals.Add(new EternalGoal("Read Scriptures", 100));
        goals.Add(new ChecklistGoal("Attend Temple", 50, 10));

        // TODO: Load goals and score from storage
    }

    // View the list of goals
    private static void ViewGoals()
    {
        Console.WriteLine("Goals:");
        Console.WriteLine("------");
        foreach (Goal goal in goals)
        {
            Console.WriteLine(goal);
        }
    }

    // Add a new goal
    private static void AddGoal()
    {
        Console.Write("Enter the goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter the goal value: ");
        int value = int.Parse(Console.ReadLine());

        Console.WriteLine();
        Console.WriteLine("Select goal type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        Console.Write("Enter your choice (1-3): ");
        string input = Console.ReadLine();

        switch (input)
        {
            case "1":
                goals.Add(new SimpleGoal(name, value));
                break;
            case "2":
                goals.Add(new EternalGoal(name, value));
                break;
            case "3":
                Console.Write("Enter the target count: ");
                int targetCount = int.Parse(Console.ReadLine());
                goals.Add(new ChecklistGoal(name, value, targetCount));
                break;
            default:
                Console.WriteLine("Invalid input. Goal not added.");
                break;
        }
    }

    // Record an event (goal progress)
    private static void RecordEvent()
    {
        Console.WriteLine("Select a goal to record:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i]}");
        }

        Console.Write("Enter your choice (1-{0}): ", goals.Count);
        int choice = int.Parse(Console.ReadLine()) - 1;

        if (choice >= 0 && choice < goals.Count)
        {
            Goal selectedGoal = goals[choice];
            selectedGoal.RecordProgress();
            score += selectedGoal.Value;

            Console.WriteLine("Event recorded successfully!");
        }
        else
        {
            Console.WriteLine("Invalid input. Event not recorded.");
        }
    }

    // View the current score
    private static void ViewScore()
    {
        Console.WriteLine("Score: " + score);
    }

    // Save goals and score to storage and exit the program
    private static void SaveAndExit()
    {
        // TODO: Save goals and score to storage
    }
}
