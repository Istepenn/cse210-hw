using System;

namespace Prep2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ask the user for their grade percentage
            Console.Write("Enter your grade percentage: ");
            double gradePercentage = double.Parse(Console.ReadLine());

            // Determine the letter grade
            char letterGrade;
            string sign = "";

            if (gradePercentage >= 90)
            {
                letterGrade = 'A';
            }
            else if (gradePercentage >= 80)
            {
                letterGrade = 'B';
            }
            else if (gradePercentage >= 70)
            {
                letterGrade = 'C';
            }
            else if (gradePercentage >= 60)
            {
                letterGrade = 'D';
            }
            else
            {
                letterGrade = 'F';
            }

            // Determine the sign
            if (letterGrade != 'F')
            {
                int lastDigit = (int)gradePercentage % 10;
                if (lastDigit >= 7)
                {
                    sign = "+";
                }
                else if (lastDigit < 3)
                {
                    sign = "-";
                }
            }

            // Print the grade and sign
            if (letterGrade == 'F')
            {
                Console.WriteLine($"Your grade is {letterGrade}");
            }
            else
            {
                Console.WriteLine($"Your grade is {letterGrade}{sign}");
            }

            // Check if the user passed the course
            if (gradePercentage >= 70)
            {
                Console.WriteLine("Congratulations! You passed the course.");
            }
            else
            {
                Console.WriteLine("Keep up the good work! You'll get it next time.");
            }
        }
    }
}
