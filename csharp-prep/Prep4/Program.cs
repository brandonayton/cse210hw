using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished. ");
        string input = "1";

        while (input != "0"){
            Console.WriteLine("Enter number: ");
            input = Console.ReadLine();
            int inputValue = int.Parse(input);
            
            if(inputValue != 0){
                numbers.Add(inputValue);
            }
        }
        int sum = 0;
        foreach (int number in numbers){
            sum += number;
        }

        Console.WriteLine($"The sum is {sum}");

        float average = sum / numbers.Count;
        
        Console.WriteLine($"The average is {average}");

        int max = 0;

        foreach (int number in numbers){
            if(number > max){
                max = number;
            }
        }

        Console.WriteLine($"The largest number is {max}");
    }
}
