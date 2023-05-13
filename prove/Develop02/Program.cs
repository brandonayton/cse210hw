using System;
using System.Collections.Generic;

class Journal
{
    private List<string> entries;

    public Journal()
    {
        entries = new List<string>();
    }

    public void WriteNewEntry(string prompt)
    {
        Console.WriteLine(prompt);
        string entry = Console.ReadLine();
        entries.Add(entry);
    }

    public void DisplayJournal()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("No entries found.");
        }
        else
        {
            Console.WriteLine("Journal Entries:");
            foreach (string entry in entries)
            {
                Console.WriteLine("- " + entry);
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("========== Journal Program ==========");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Exit");
            Console.WriteLine("=====================================");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter a prompt: ");
                    string prompt = Console.ReadLine();
                    journal.WriteNewEntry(prompt);
                    break;
                case "2":
                    journal.DisplayJournal();
                    break;
                case "3":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }
}
