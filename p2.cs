using System;

class Program
{
    static void Main(string[] args)
    {
        // Variables
        int number;

        // Input
        Console.WriteLine("Enter a number:");
        number = Convert.ToInt32(Console.ReadLine());

        // Conditional
        if (number % 2 == 0)
        {
            Console.WriteLine(number + " is even.");
        }
        else
        {
            Console.WriteLine(number + " is odd.");
        }
    }
}
