using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // List
        List<int> numbers = new List<int>();

        // Adding elements to the list
        numbers.Add(1);
        numbers.Add(2);
        numbers.Add(3);

        // Accessing elements
        Console.WriteLine("Elements in the list:");
        foreach (int num in numbers)
        {
            Console.WriteLine(num);
        }
    }
}
