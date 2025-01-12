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
    }
}
