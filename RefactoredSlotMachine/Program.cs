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
            }
        }
    }
}
