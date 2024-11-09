using System;
using System.Collections.Generic;
using System.Linq;

namespace NumberList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            int number;

            Console.WriteLine("Enter a list of numbers, type 0 when finished.");

            do
            {
                Console.Write("Enter number: ");
                number = int.Parse(Console.ReadLine());

                if (number != 0)
                {
                    numbers.Add(number);
                }
            } while (number != 0);

            // Core Requirement
            int sum = numbers.Sum();
            double average = numbers.Average();
            int max = numbers.Max();

            Console.WriteLine($"The sum is: {sum}");
            Console.WriteLine($"The average is: {average}");
            Console.WriteLine($"The largest number is: {max}");

            // Stretch Challenge
            int minPositive = numbers.Where(n => n > 0).Min();
            numbers.Sort();

            Console.WriteLine($"The smallest positive number is: {minPositive}");
            Console.WriteLine("The sorted list is:");
            foreach (int num in numbers)
            {
                Console.WriteLine(num);
            }
        }
    }
}