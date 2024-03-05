using System;

class Program
{
    static void Main(string[] args)
    {
        // Variables
        int age;
        string name;

        // Input
        Console.WriteLine("Enter your name:");
        name = Console.ReadLine();

        Console.WriteLine("Enter your age:");
        age = Convert.ToInt32(Console.ReadLine());

        // Output
        Console.WriteLine("Hello, " + name + "! You are " + age + " years old.");
    }
}
