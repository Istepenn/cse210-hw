using System;

namespace Prep3
{
    class Program
    {
        static void Main(string[] args)
        {
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101);
            int guess;
            int numberOfGuesses = 0;
            string playAgain;

            do
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                numberOfGuesses++;

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                }
            } while (guess != magicNumber);

            Console.WriteLine($"It took you {numberOfGuesses} guesses.");

            Console.Write("Do you want to play again? (yes/no): ");
            playAgain = Console.ReadLine();

            if (playAgain.ToLower() == "yes")
            {
                Main(args); // Recursive call to Main method to play again
            }
        }
    }
}
