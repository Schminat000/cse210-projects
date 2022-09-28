using System;

namespace Prep3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is Prep 3");
            Console.WriteLine();

            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 100);

            int guess = -1;

            while (guess != magicNumber)
            {  
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());
                if (guess > magicNumber)
                {
                    Console.WriteLine($"It is lower than {guess}!");
                }
                else if (guess < magicNumber)
                {
                    Console.WriteLine($"It is higher than {guess}!");
                }
                else
                {
                    Console.WriteLine("That is correct!");
                }
            }
        }

    }
}
