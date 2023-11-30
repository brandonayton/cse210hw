using System;

class Word
{
    public string Text { get; }
    public bool IsHidden { get; set; }

    public Word(string text)
    {
        Text = text;
        IsHidden = false;
    }

    public void Hide()
    {
        IsHidden = true;
    }

    public string Display()
    {
        return IsHidden ? new string('_', Text.Length) : Text;
    }
}

class ScriptureReference
{
    public string Reference { get; }

    public ScriptureReference(string reference)
    {
        Reference = reference;
    }
}

class Scripture
{
    private readonly ScriptureReference reference;
    private readonly Word[] words;

    public Scripture(ScriptureReference reference, string text)
    {
        this.reference = reference;
        string[] wordArray = text.Split(' ');
        words = new Word[wordArray.Length];

        for (int i = 0; i < wordArray.Length; i++)
        {
            words[i] = new Word(wordArray[i]);
        }
    }

    public void HideRandomWords()
    {
        Random random = new Random();
        int wordsToHide = random.Next(1, words.Length / 2);

        for (int i = 0; i < wordsToHide; i++)
        {
            int index;
            do
            {
                index = random.Next(0, words.Length);
            } while (words[index].IsHidden);

            words[index].Hide();
        }
    }

    public void Display()
    {
        Console.Clear(); // Clear the console
        Console.WriteLine($"Scripture Reference: {reference.Reference}");
        foreach (Word word in words)
        {
            Console.Write(word.Display() + " ");
        }
        Console.WriteLine();
    }

    public bool AllWordsHidden()
    {
        foreach (Word word in words)
        {
            if (!word.IsHidden)
            {
                return false;
            }
        }
        return true;
    }

    public bool Guess(string guess)
    {
        string[] guessedWords = guess.Split(' ');

        if (guessedWords.Length != words.Length)
        {
            Console.WriteLine("Incorrect. Try again.");
            return false;
        }

        for (int i = 0; i < words.Length; i++)
        {
            if (!string.Equals(guessedWords[i], words[i].Text, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Incorrect. Try again.");
                return false;
            }
        }

        Console.WriteLine("Correct! You've guessed the scripture.");
        return true;
    }
}

class Program
{
    static void Main()
    {
        ScriptureReference reference = new ScriptureReference("John 3:16");
        Scripture scripture = new Scripture(reference, "For God so loved the world that he gave his only Son, that whoever believes in him should not perish but have eternal life.");

        do
        {
            // Display the complete scripture
            scripture.Display();

            Console.WriteLine("\nPress Enter to continue, type 'quit' to exit, or guess the scripture:");

            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;
            else if (scripture.Guess(input))
                break;

            scripture.HideRandomWords();

        } while (!scripture.AllWordsHidden());
    }
}
