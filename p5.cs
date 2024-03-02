using System;

class Program
{
    static void Main(string[] args)
    {
        // Prompt the user to enter two numbers
        Console.Write("Enter the first number: ");
        int num1 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter the second number: ");
        int num2 = Convert.ToInt32(Console.ReadLine());

        // Call the function to calculate the sum
        int sum = CalculateSum(num1, num2);

        // Display the sum
        Console.WriteLine("Sum: " + sum);
    }

    // Function to calculate the sum of two numbers
    static int CalculateSum(int a, int b)
    {
        return a + b;
    }
}
