using System;
using System.Formats.Asn1;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1, 11);
        int loop = 0;
        Console.WriteLine($"What is the magic number? {number}");
        
        while (loop == 0)
        {
            Console.WriteLine("What is your guess? ");
            string answer = Console.ReadLine();
            int guess = int.Parse(answer);

            if (guess == number)
            {
                loop = 1;
            }
            else if (guess > number)
            {
                Console.WriteLine("Lower");
            }
            else if (guess < number)
            {
                Console.WriteLine("Higher");
            }
        }

        Console.WriteLine("You guessed it!");
    }
}
