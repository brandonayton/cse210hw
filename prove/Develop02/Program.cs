using System; 
using System.Collections.Generic;

class JournalEntry
{
    public string Prompt { get; set; }
    public string Entry { get; set; }
}

class Journal
{
    private List<JournalEntry> entries;

    public Journal()
    {
        entries = new List<JournalEntry>();
    }

    public void WriteNewEntry(string prompt)
    {
        Console.WriteLine(prompt);
        string entry = Console.ReadLine();
        entries.Add(new JournalEntry { Prompt = prompt, Entry = entry });
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
            foreach (JournalEntry entry in entries)
            {
                Console.WriteLine("- Prompt: " + entry.Prompt);
                Console.WriteLine("  Entry: " + entry.Entry);
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
                    Console.Write("Enter an entry for: ");
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
