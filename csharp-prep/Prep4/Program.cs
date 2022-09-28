using System;
using System.Collections.Generic;

namespace Prep4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is Prep 4");
            Console.WriteLine();

            Console.WriteLine("Enter a list of numbers, type 0 when finished.");
            List<int> numbers = new List<int>();

            int userNumber = -1;
            
            while (userNumber != 0)
            {
                Console.Write("Enter number: ");
                userNumber = int.Parse(Console.ReadLine());

                numbers.Add(userNumber);
            }

            int sum = 0;
            foreach (int number in numbers)
            {
                sum += number;
            }

            Console.WriteLine($"The sum is: {sum}");

            float average = sum / numbers.Count;

            Console.WriteLine($"The average is: {average}");

            int largestNumber = 0;
            foreach (int number in numbers)
            {
                if (number > largestNumber)
                {
                    largestNumber = number;
                }
            }

            Console.WriteLine($"The largest number is: {largestNumber}");
        }
    }
}
