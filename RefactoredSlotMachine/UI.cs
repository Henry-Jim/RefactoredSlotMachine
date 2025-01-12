using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactoredSlotMachine
{
    internal class UI
    {
        public static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        public static string ReadInput()
        {
            return Console.ReadLine();
        }

        public static int GetGridSize(int defaultSize)
        {
            DisplayMessage($"Enter an odd number grid size (e.g {defaultSize} for {defaultSize} x {defaultSize}): ");
            while (true)
            {
                if (int.TryParse(ReadInput(), out int gridSize) && gridSize % 2 != 0 && gridSize >= 3)
                {
                    return gridSize;
                }

                DisplayMessage("Invalid input. Please enter an odd number greater than or equal to 3");
            }
        }

        public static void DisplayGrid(int[,] grid)
        {
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    Console.Write(grid[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public static bool PromptPlayAgain()
        {
            Console.WriteLine("Do you want to play again? (y/n)");
            return Console.ReadKey().KeyChar != Constants.PLAY_AGAIN_NO;
        }

        public static int GetWager(int maxAmount)
        {
            DisplayMessage($"Enter you wager up to ${maxAmount}: ");
            while (true)
            {
                if (int.TryParse(ReadInput(), out int wager) && wager > 0 && wager <= maxAmount)
                {
                    return wager;
                }

                DisplayMessage("Invalid input. Please enter a positive number less than or equal to the maximum amount.");
            }
        }

        public static int GetChoice()
        {
            DisplayMessage("Choose a line to play: ");
            DisplayMessage($"{Constants.CHOICE_CENTER}: Center Line");
            DisplayMessage($"{Constants.CHOICE_ALL_HORIZONTAL}: All Horizontal Lines");
            DisplayMessage($"{Constants.CHOICE_ALL_VERTICAL}: All Vertical Lines");
            DisplayMessage($"{Constants.CHOICE_DIAGONAL}: Diagonals");
            DisplayMessage($"{Constants.CHOICE_ALL_LINES}: All Lines");

            while (true)
            {
                if (int.TryParse(ReadInput(), out int choice) && choice >= Constants.CHOICE_CENTER && choice <= Constants.CHOICE_ALL_LINES)
                {
                    return choice;
                }
                DisplayMessage($"Invalid option. Please select an option between {Constants.CHOICE_CENTER} and {Constants.CHOICE_ALL_LINES}")
            }
    }
}
