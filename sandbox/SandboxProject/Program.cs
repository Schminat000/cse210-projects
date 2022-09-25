// Author: Nathan Schmidt
// Assignment: Tic Tac Toe

using System;
using System.Collections.Generic;

namespace SandboxProject
{
    class Program
    {
        static void Main(string[] args)
        {
            displayGreeting();
            List<string> board = getBlankBoard();
            string currentTurn = "X";
            while (!gameOver(board))
            {
                displayBoard(board);
                int move = getMoveOption(currentTurn);
                currentMove(board, move, currentTurn);

                currentTurn = getNextTurn(currentTurn);
            }
            Console.WriteLine("GG. Thanks!");
        }

        static void displayGreeting()
        {
            Console.WriteLine("Welcome to the Tic Tac Toe Program!");
        }

        static List<string> getBlankBoard()
        {
            List<string> board = new List<string>();

            for (int i = 1; i <= 9; i++)
            {
                board.Add(i.ToString());
            }

            return board;
        }

        static void displayBoard(List<string> board)
        {
            Console.WriteLine($"{board[0]}|{board[1]}|{board[2]}");
            Console.WriteLine("-+-+-");
            Console.WriteLine($"{board[3]}|{board[4]}|{board[5]}");
            Console.WriteLine("-+-+-");
            Console.WriteLine($"{board[6]}|{board[7]}|{board[8]}");
        }

        static string getNextTurn(string currentTurn)
        {
            string nextTurn = "X";

            if (currentTurn == "X");
            {
                nextTurn = "O";
            }

            return nextTurn;
        }

        static int getMoveOption(string currentTurn)
        {
            Console.Write($"{currentTurn}'s turn to choose (1-9): ");
            string move = Console.ReadLine();

            int choice = int.Parse(move);

            return choice;
        }

        static bool isWinner(List<string> board, string player)
        {
            bool winner = false;

            if ((board[0] == player && board[1] == player && board[2] == player)
                || (board[3] == player && board[4] == player && board[5] == player)
                || (board[6] == player && board[7] == player && board[8] == player)
                || (board[0] == player && board[3] == player && board[6] == player)
                || (board[1] == player && board[4] == player && board[7] == player)
                || (board[2] == player && board[5] == player && board[8] == player)
                || (board[0] == player && board[4] == player && board[8] == player)
                || (board[2] == player && board[4] == player && board[6] == player)
                )
            {
                winner = true;
            }
            return winner; 
        }

        static bool gameOver(List<string> board)
        {
            bool gameOver = false;

            if (isWinner(board, "x") || isWinner(board, "o") || tie(board))
            {
                gameOver = true;
            }

            return gameOver;
        }

        static void currentMove(List<string> board, int choice, string currentTurn)
        {
            int index = choice - 1;

            board[index] = currentTurn;
        }

        static bool tie(List<string> board)
        {
            // If there is a digit, there are still moves to be made.
            bool foundValue= false;
            foreach (string value in board)
            {
                if (char.IsDigit(value[0]))
                {
                    foundValue = true;
                    break;
                }
            }
            return !foundValue;
        }
    }
}
