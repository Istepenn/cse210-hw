using System;

class Program
{
    static void Main(string[] args)
    {
        // Prompt the user to enter their name
        Console.Write("Enter your name: ");
        string name = Console.ReadLine();

        // Prompt the user to enter their age
        Console.Write("Enter your age: ");
        int age = Convert.ToInt32(Console.ReadLine());

        // Display a message including the user's name and age
        Console.WriteLine("Hello, " + name + "! You are " + age + " years old.");
    }
}
