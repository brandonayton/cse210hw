using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private string reference;
    private string text;
    private List<string> hiddenWords;

    public Scripture(string reference, string text)
    {
        this.reference = reference;
        this.text = text;
        hiddenWords = new List<string>();
    }

    public void Display()
    {
        Console.Clear();
        Console.WriteLine(reference + ":");
        Console.WriteLine(text);
    }

    public void HideWords(int count)
    {
        Random random = new Random();
        List<string> words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

        for (int i = 0; i < count; i++)
        {
            int index = random.Next(words.Count);
            string word = words[index];
            if (!hiddenWords.Contains(word))
            {
                hiddenWords.Add(word);
                words[index] = new string('_', word.Length);
            }
            else
            {
                i--;
            }
        }

        text = string.Join(" ", words);
    }

    public bool AllWordsHidden()
    {
        return hiddenWords.Count == text.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;
    }
}

public class Reference
{
    private string book;
    private int chapter;
    private int startVerse;
    private int endVerse;

    public Reference(string book, int chapter, int verse)
    {
        this.book = book;
        this.chapter = chapter;
        this.startVerse = verse;
        this.endVerse = verse;
    }

    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        this.book = book;
        this.chapter = chapter;
        this.startVerse = startVerse;
        this.endVerse = endVerse;
    }

    public string GetReference()
    {
        if (startVerse == endVerse)
        {
            return $"{book} {chapter}:{startVerse}";
        }
        else
        {
            return $"{book} {chapter}:{startVerse}-{endVerse}";
        }
    }
}

public class Word
{
    private string text;

    public Word(string text)
    {
        this.text = text;
    }

    public string GetText()
    {
        return text;
    }
}

public class Program
{
    public static void Main()
    {
        Scripture scripture = new Scripture("John 3:16", "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.");
        scripture.Display();

        while (!scripture.AllWordsHidden())
        {
            Console.WriteLine("Press Enter to continue or type 'quit' to exit:");
            string input = Console.ReadLine();
            if (input.ToLower() == "quit")
            {
                break;
            }

            scripture.HideWords(2);
            scripture.Display();
        }
    }
}
