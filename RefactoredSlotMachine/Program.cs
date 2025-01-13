namespace RefactoredSlotMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Slot Machine Game!");

            int playMoney = Constants.MONEY_INITIAL;

            while (playMoney > 0)
            {
                UI.DisplayMessage($"You currently have ${playMoney}. How much would you like to wager?");
                int wager = UI.GetWager(playMoney);

                int gridSize = UI.GetGridSize(Constants.GRID_SIZE_DEFAULT);

                int choice = UI.GetChoice();

                int[,] grid = Logic.GenerateGrid(gridSize);
                UI.DisplayMessage("Loading Slot Machine...");
                UI.DisplayGrid(grid);

                int winnings = Logic.CalculateWinnings(grid, choice);
                playMoney -= wager;

                if (winnings > 0)
                {
                    playMoney += wager + winnings;
                    UI.DisplayMessage($"Congrats! You won {winnings}! Your wager is returned.");
                }
                else
                {
                    UI.DisplayMessage($"Sorry, You lost this round. Your loss for this wager is {wager}.");
                }

                if (playMoney <= 0)
                {
                    UI.DisplayMessage("Out of Money. Gameover!");
                    break;
                }

                if (!UI.PromptPlayAgain())
                {
                    break;
                }
            }
        }
    }
}
