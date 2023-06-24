using System;
using System.Collections.Generic;
using System.Threading;

// Base class for all activities
public abstract class Activity
{
    protected int duration;

    public Activity(int duration)
    {
        this.duration = duration;
    }

    // Abstract method to display the starting message for each activity
    public abstract void DisplayStartingMessage();

    // Abstract method to display the ending message for each activity
    public abstract void DisplayEndingMessage();

    // Method to pause the program for a specified number of seconds
    protected void Pause(int seconds)
    {
        Thread.Sleep(seconds * 1000);
    }

    // Method to display a countdown animation
    protected void DisplayCountdown()
    {
        for (int i = 3; i >= 1; i--)
        {
            Console.Write(i + " ");
            Pause(1);
        }
        Console.WriteLine();
    }

    // Abstract method to perform the activity
    public abstract void PerformActivity();
}

// Activity for deep breathing
public class BreathingActivity : Activity
{
    public BreathingActivity(int duration) : base(duration)
    {
    }

    public override void DisplayStartingMessage()
    {
        Console.WriteLine("Breathing Activity");
        Console.WriteLine("------------------");
        Console.WriteLine("This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.");
        Console.WriteLine();
        Console.WriteLine($"Duration: {duration} seconds");
        Console.WriteLine();
        Console.WriteLine("Prepare to begin...");
        Pause(3);
    }

    public override void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Great job! You have completed the Breathing Activity.");
        Console.WriteLine($"Duration: {duration} seconds");
        Pause(3);
    }

    public override void PerformActivity()
    {
        DisplayStartingMessage();

        for (int i = 1; i <= duration; i++)
        {
            Console.WriteLine("Breathe in...");
            Pause(1);
            DisplayCountdown();

            Console.WriteLine("Breathe out...");
            Pause(1);
            DisplayCountdown();
        }

        DisplayEndingMessage();
    }
}

// Activity for reflection
public class ReflectionActivity : Activity
{
    private List<string> prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> questions = new List<string>
    {
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

    public ReflectionActivity(int duration) : base(duration)
    {
    }

    public override void DisplayStartingMessage()
    {
        Console.WriteLine("Reflection Activity");
        Console.WriteLine("-------------------");
        Console.WriteLine("This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
        Console.WriteLine();
        Console.WriteLine($"Duration: {duration} seconds");
        Console.WriteLine();
        Console.WriteLine("Prepare to begin...");
        Pause(3);
    }

    public override void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Great job! You have completed the Reflection Activity.");
        Console.WriteLine($"Duration: {duration} seconds");
        Pause(3);
    }

    public override void PerformActivity()
    {
        DisplayStartingMessage();

        Random random = new Random();

        for (int i = 1; i <= duration; i++)
        {
            string prompt = prompts[random.Next(prompts.Count)];
            Console.WriteLine(prompt);
            Pause(1);
            DisplayCountdown();

            foreach (string question in questions)
            {
                Console.WriteLine(question);
                Pause(2);
                DisplayCountdown();
            }
        }

        DisplayEndingMessage();
    }
}

// Activity for listing items
public class ListingActivity : Activity
{
    private List<string> prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity(int duration) : base(duration)
    {
    }

    public override void DisplayStartingMessage()
    {
        Console.WriteLine("Listing Activity");
        Console.WriteLine("----------------");
        Console.WriteLine("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
        Console.WriteLine();
        Console.WriteLine($"Duration: {duration} seconds");
        Console.WriteLine();
        Console.WriteLine("Prepare to begin...");
        Pause(3);
    }

    public override void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Great job! You have completed the Listing Activity.");
        Console.WriteLine($"Duration: {duration} seconds");
        Pause(3);
    }

    public override void PerformActivity()
    {
        DisplayStartingMessage();

        Random random = new Random();
        string prompt = prompts[random.Next(prompts.Count)];

        Console.WriteLine(prompt);
        Console.WriteLine("You may begin listing...");
        Pause(3);

        List<string> items = new List<string>();
        DateTime startTime = DateTime.Now;

        while (DateTime.Now - startTime < TimeSpan.FromSeconds(duration))
        {
            string item = Console.ReadLine();
            items.Add(item);
        }

        Console.WriteLine();
        Console.WriteLine("Items listed:");
        foreach (string item in items)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine();
        Console.WriteLine($"Total items: {items.Count}");
        Pause(3);

        DisplayEndingMessage();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Mindfulness Program");
        Console.WriteLine("-------------------");
        Console.WriteLine("1. Breathing Activity");
        Console.WriteLine("2. Reflection Activity");
        Console.WriteLine("3. Listing Activity");
        Console.WriteLine("4. Exit");
        Console.WriteLine();

        while (true)
        {
            Console.Write("Enter your choice (1-4): ");
            string input = Console.ReadLine();

            if (input == "1")
            {
                Console.Write("Enter the duration in seconds: ");
                int duration = int.Parse(Console.ReadLine());
                Console.WriteLine();

                Activity breathingActivity = new BreathingActivity(duration);
                breathingActivity.PerformActivity();
            }
            else if (input == "2")
            {
                Console.Write("Enter the duration in seconds: ");
                int duration = int.Parse(Console.ReadLine());
                Console.WriteLine();

                Activity reflectionActivity = new ReflectionActivity(duration);
                reflectionActivity.PerformActivity();
            }
            else if (input == "3")
            {
                Console.Write("Enter the duration in seconds: ");
                int duration = int.Parse(Console.ReadLine());
                Console.WriteLine();

                Activity listingActivity = new ListingActivity(duration);
                listingActivity.PerformActivity();
            }
            else if (input == "4")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
                Console.WriteLine();
            }
        }
    }
}
