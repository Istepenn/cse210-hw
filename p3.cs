using System;

class Program
{
    static void Main(string[] args)
    {
        // Loop using for
        Console.WriteLine("Loop using for:");
        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine(i);
        }

        // Loop using while
        Console.WriteLine("\nLoop using while:");
        int j = 1;
        while (j <= 5)
        {
            Console.WriteLine(j);
            j++;
        }
    }
}
