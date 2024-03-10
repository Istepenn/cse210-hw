using System;

namespace Learning03
{
    public class Fraction
    {
        private int numerator;
        private int denominator;

        // Constructor with no parameters, initializes to 1/1
        public Fraction()
        {
            numerator = 1;
            denominator = 1;
        }

        // Constructor with one parameter for the top, initializes denominator to 1
        public Fraction(int top)
        {
            numerator = top;
            denominator = 1;
        }

        // Constructor with two parameters for top and bottom
        public Fraction(int top, int bottom)
        {
            numerator = top;
            if (bottom != 0)
                denominator = bottom;
            else
                throw new ArgumentException("Denominator cannot be zero.");
        }

        // Getter and setter for numerator
        public int Numerator
        {
            get { return numerator; }
            set { numerator = value; }
        }

        // Getter and setter for denominator
        public int Denominator
        {
            get { return denominator; }
            set
            {
                if (value != 0)
                    denominator = value;
                else
                    throw new ArgumentException("Denominator cannot be zero.");
            }
        }

        // Method to return fraction representation as a string
        public string GetFractionString()
        {
            return $"{numerator}/{denominator}";
        }

        // Method to return decimal value of the fraction
        public double GetDecimalValue()
        {
            return (double)numerator / denominator;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Test constructors
            Fraction fraction1 = new Fraction();
            Fraction fraction2 = new Fraction(5);
            Fraction fraction3 = new Fraction(3, 4);
            Fraction fraction4 = new Fraction(1, 3);

            // Test getters and setters
            fraction1.Numerator = 1;
            fraction1.Denominator = 1;
            Console.WriteLine(fraction1.GetFractionString());
            Console.WriteLine(fraction1.GetDecimalValue());

            fraction2.Numerator = 5;
            Console.WriteLine(fraction2.GetFractionString());
            Console.WriteLine(fraction2.GetDecimalValue());

            Console.WriteLine(fraction3.GetFractionString());
            Console.WriteLine(fraction3.GetDecimalValue());

            Console.WriteLine(fraction4.GetFractionString());
            Console.WriteLine(fraction4.GetDecimalValue());
        }
    }
}
