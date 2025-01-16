namespace RefactoredSlotMachine
{
    internal class UI
    {
        public static void ShowWelcomeMessage()
        {
            Console.WriteLine("Welcome to the Slot Machine Game!");
        }

        public static void ShowWagerPrompt(int maxAmount)
        {
            Console.WriteLine($"Enter your wager (1 to {maxAmount}): ");
        }

        public static void ShowGridSizePrompt(int defaultSize)
        {
            Console.WriteLine($"Enter an odd number grid size (e.g., {defaultSize} for {defaultSize}x{defaultSize}): ");
        }

        public static void ShowChoicePrompt()
        {
            Console.WriteLine("Choose a line to play:");
            Console.WriteLine($"{Constants.CHOICE_CENTER}: Center Line");
            Console.WriteLine($"{Constants.CHOICE_ALL_HORIZONTAL}: All Horizontal Lines");
            Console.WriteLine($"{Constants.CHOICE_ALL_VERTICAL}: All Vertical Lines");
            Console.WriteLine($"{Constants.CHOICE_DIAGONAL}: Diagonals");
            Console.WriteLine($"{Constants.CHOICE_ALL_LINES}: All Lines");
        }

        public static int ReadIntInput(string prompt, int min, int max, bool isOdd = false)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int value) && value >= min && value <= max && (!isOdd || value % 2 != 0))
                {
                    return value;
                }
                Console.WriteLine($"Invalid input. Please enter a number between {min} and {max}{(isOdd ? ", and it must be odd" : "")}.");
            }
        }

        public static void ShowResultMessage(string message)
        {
            Console.WriteLine(message);
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
            Console.WriteLine("Do you want to play again? (y/n): ");
            char input = Console.ReadKey().KeyChar;
            Console.ReadLine(); 
            return input != Constants.PLAY_AGAIN_NO;
        }
    }
}
