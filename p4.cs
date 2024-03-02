using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list of integers
        List<int> numbers = new List<int>();

        // Add numbers to the list
        numbers.Add(1);
        numbers.Add(2);
        numbers.Add(3);
        numbers.Add(4);
        numbers.Add(5);

        // Display the numbers in the list
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}
