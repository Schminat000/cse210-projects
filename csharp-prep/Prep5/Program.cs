using System;
using System.Collections.Generic;

namespace Prep5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is Prep 5");
            Console.WriteLine();

            DisplayWelcome();
            string userName = PromptUserName();
            int number = PromptUserNumber();
            int squareNumber = SquareNumber(number);
            DisplayResult(userName, squareNumber);
        }
        static void DisplayWelcome()
        {
            Console.WriteLine("Welcome to the program!");
        }

        static string PromptUserName()
        {
            Console.Write("Please enter a your name: ");
            string userName = Console.ReadLine();
            return userName;
        }

        static int PromptUserNumber()
        {
            Console.Write("Please enter your favorite number: ");
            int favoriteNumber = int.Parse(Console.ReadLine());
            return favoriteNumber;
        }

        static int SquareNumber(int number)
        {
            int sqauredNumber = number * number;
            return sqauredNumber;
        }

        static void DisplayResult(string userName, int number)
        {
            Console.WriteLine($"{userName}, the square of your number is {number}.");
        }
    }
}
