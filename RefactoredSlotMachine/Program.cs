namespace RefactoredSlotMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UI.ShowWelcomeMessage();

            int playMoney = Constants.MONEY_INITIAL;
            while (playMoney > 0)
            {
                UI.ShowResultMessage($"You currently have ${playMoney}.");
                int wager = UI.ReadIntInput("Enter your wager: ", 1, playMoney);

                UI.ShowGridSizePrompt(Constants.GRID_SIZE_DEFAULT);
                int gridSize = UI.ReadIntInput("Grid size: ", 3, 99, isOdd: true);

                int[,] grid = Logic.GenerateGrid(gridSize);
                UI.ShowResultMessage("Slot Machine Result:");
                UI.DisplayGrid(grid);

                UI.ShowChoicePrompt();
                int choice = UI.ReadIntInput("Your choice: ", Constants.CHOICE_CENTER, Constants.CHOICE_ALL_LINES);

                int winnings = Logic.CalculateWinnings(grid, choice);
                playMoney -= wager;

                if (winnings > 0)
                {
                    playMoney += wager + winnings;
                    UI.ShowResultMessage($"Congrats! You won {winnings}! Your wager is returned.");
                }
                else
                {
                    UI.ShowResultMessage($"Sorry, you lost this round. Your loss for this wager is {wager}.");
                }

                if (playMoney <= 0)
                {
                    UI.ShowResultMessage("Out of money. Game over!");
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
