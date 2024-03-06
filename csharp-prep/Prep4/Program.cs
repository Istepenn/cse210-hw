using System;
using System.Collections.Generic;

namespace Prep4
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            int num;
            double sum = 0;
            double average;
            int max = int.MinValue;
            int minPositive = int.MaxValue;

            Console.WriteLine("Enter a list of numbers, type 0 when finished.");

            do
            {
                Console.Write("Enter number: ");
                num = int.Parse(Console.ReadLine());

                if (num != 0)
                {
                    numbers.Add(num);
                    sum += num;
                    if (num > max)
                    {
                        max = num;
                    }
                    if (num > 0 && num < minPositive)
                    {
                        minPositive = num;
                    }
                }
            } while (num != 0);

            if (numbers.Count > 0)
            {
                average = sum / numbers.Count;
                Console.WriteLine($"The sum is: {sum}");
                Console.WriteLine($"The average is: {average}");
                Console.WriteLine($"The largest number is: {max}");

                if (minPositive != int.MaxValue)
                {
                    Console.WriteLine($"The smallest positive number is: {minPositive}");
                }

                numbers.Sort();
                Console.WriteLine("The sorted list is:");
                foreach (int n in numbers)
                {
                    Console.WriteLine(n);
                }
            }
            else
            {
                Console.WriteLine("No numbers were entered.");
            }
        }
    }
}
