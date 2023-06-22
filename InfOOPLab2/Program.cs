using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfOOPLab2
{
    public class Fraction
    {
        public int Numerator { get; set; }
        public int Denominator { get; set; }

        public Fraction(int numerator, int denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }

        public Fraction(Fraction fraction)
        {
            Numerator = fraction.Numerator;
            Denominator = fraction.Denominator;
        }

        public Fraction Add(Fraction f)
        {
            int newNumerator = Numerator * f.Denominator + f.Numerator * Denominator;
            int newDenominator = Denominator * f.Denominator;
            return new Fraction(newNumerator, newDenominator);
        }

        public Fraction Subtract(Fraction f)
        {
            int newNumerator = Numerator * f.Denominator - f.Numerator * Denominator;
            int newDenominator = Denominator * f.Denominator;
            return new Fraction(newNumerator, newDenominator);
        }

        public Fraction Multiply(Fraction f)
        {
            int newNumerator = Numerator * f.Numerator;
            int newDenominator = Denominator * f.Denominator;
            return new Fraction(newNumerator, newDenominator);
        }

        public Fraction Divide(Fraction f)
        {
            int newNumerator = Numerator * f.Denominator;
            int newDenominator = Denominator * f.Numerator;
            return new Fraction(newNumerator, newDenominator);
        }

        public void Reduce()
        {
            int gcd = GCD(Numerator, Denominator);
            Numerator /= gcd;
            Denominator /= gcd;
        }

        public Fraction Power(int n)
        {
            int newNumerator = (int)Math.Pow(Numerator, n);
            int newDenominator = (int)Math.Pow(Denominator, n);
            return new Fraction(newNumerator, newDenominator);
        }

        public bool IsEqualTo(Fraction f)
        {
            return Numerator == f.Numerator && Denominator == f.Denominator;
        }

        public bool IsNotEqualTo(Fraction f)
        {
            return !IsEqualTo(f);
        }

        public bool IsGreaterThan(Fraction f)
        {
            return Numerator * f.Denominator > f.Numerator * Denominator;
        }

        public bool IsGreaterThanOrEqualTo(Fraction f)
        {
            return Numerator * f.Denominator >= f.Numerator * Denominator;
        }

        public bool IsLessThan(Fraction f)
        {
            return Numerator * f.Denominator < f.Numerator * Denominator;
        }

        public bool IsLessThanOrEqualTo(Fraction f)
        {
            return Numerator * f.Denominator <= f.Numerator * Denominator;
        }

        private int GCD(int a, int b)
        {
            if (b == 0)
            {
                return a;
            }
            return GCD(b, a % b);
        }

        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }
    }

    public class FractionArray
    {
        private List<Fraction> fractions;

        public FractionArray()
        {
            fractions = new List<Fraction>();
        }

        public FractionArray(params Fraction[] fractions)
        {
            this.fractions = new List<Fraction>(fractions);
        }

        public void Add(Fraction f)
        {
            fractions.Add(f);
        }

        public void SortAscending()
        {
            fractions.Sort((f1, f2) =>
            {
                double value1 = (double)f1.Numerator / f1.Denominator;
                double value2 = (double)f2.Numerator / f2.Denominator;
                return value1.CompareTo(value2);
            });
        }

        public void DisplayFractions()
        {
            foreach (Fraction fraction in fractions)
            {
                Console.WriteLine(fraction.ToString());
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            FractionArray fractionArray = new FractionArray();

            Console.WriteLine("Enter fractions (numerator/denominator). Enter 'done' to finish.");

            while (true)
            {
                Console.Write("Fraction: ");
                string input = Console.ReadLine();

                if (input == "done")
                    break;

                string[] parts = input.Split('/');

                if (parts.Length != 2)
                {
                    Console.WriteLine("Invalid fraction format. Please try again.");
                    continue;
                }

                if (!int.TryParse(parts[0], out int numerator) || !int.TryParse(parts[1], out int denominator))
                {
                    Console.WriteLine("Invalid fraction format. Please try again.");
                    continue;
                }

                Fraction fraction = new Fraction(numerator, denominator);
                fractionArray.Add(fraction);
            }

            fractionArray.SortAscending();

            Console.WriteLine("\nSorted fractions (in ascending order):");
            fractionArray.DisplayFractions();
            Console.WriteLine("\nPress any key to to exit...");
            Console.ReadKey();
        }
    }
}
