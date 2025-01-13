namespace RefactoredSlotMachine
{
    internal class Logic
    {
        public static readonly Random random = new Random();

        public static int[,] GenerateGrid(int gridSize)
        {
            int[,] grid = new int[gridSize, gridSize];
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    grid[i, j] = random.Next(0, Constants.RANDOM_LIMIT);
                }
            }
            return grid;
        }

        public static int CalculateWinnings(int[,] grid, int choice)
        {
            int gridSize = grid.GetLength(0);
            int winnings = 0;

            if (choice == Constants.CHOICE_ALL_HORIZONTAL || choice == Constants.CHOICE_ALL_LINES)
            {
                winnings += CheckHorizontal(grid, gridSize);
            }
            if (choice == Constants.CHOICE_CENTER || choice == Constants.CHOICE_ALL_LINES)
            {
                winnings += CheckCenter(grid, gridSize);
            }
            if (choice == Constants.CHOICE_ALL_VERTICAL || choice == Constants.CHOICE_ALL_LINES)
            {
                winnings += CheckVertical(grid, gridSize);
            }
            if (choice == Constants.CHOICE_DIAGONAL || choice == Constants.CHOICE_ALL_LINES)
            {
                winnings += CheckDiagonal(grid, gridSize);
            }

            return winnings;
        }

        public static int CheckHorizontal(int[,] grid, int gridSize)
        {
            int winnings = 0;
            for (int i = 0; i < gridSize; i++)
            {
                bool win = true;
                for (int j = 1; j < gridSize; j++)
                {
                    if (grid[i, j] != grid[i, j - 1])
                    {
                        win = false;
                        break;
                    }
                }
                if (win) winnings += Constants.PAYOUT;
            }
            return winnings;
        }

        public static int CheckCenter(int[,] grid, int gridSize)
        {
            int midrow = gridSize / 2;
            bool win = true;

            for (int j = 1; j < gridSize; j++)
            {
                if (grid[midrow, j] != grid[midrow, j - 1])
                {
                    win = false;
                    break;
                }
            }
            return win ? Constants.PAYOUT : 0;
        }

        public static int CheckVertical(int[,] grid, int gridSize)
        {
            int winnings = 0;
            for (int j = 0; j < gridSize; j++)
            {
                bool win = true;
                for (int i = 1; i < gridSize; i++)
                {
                    if (grid[i, j] != grid[i - 1, j])
                    {
                        win = false;
                        break;
                    }
                }
                if (win) winnings += Constants.PAYOUT;
            }
            return winnings;
        }

        public static int CheckDiagonal(int[,] grid, int gridSize)
        {
            bool diagonalWin = true;
            bool antiDiagonalWin = true;

            for (int i = 1; i < gridSize; i++)
            {
                if (grid[i, i] != grid[i - 1, i - 1])
                {
                    diagonalWin = false;
                }
                if (grid[i, gridSize - i - 1] != grid[i - 1, gridSize - i])
                {
                    antiDiagonalWin = false;
                }
            }

            int winnings = 0;
            if (diagonalWin) winnings += Constants.PAYOUT;
            if (antiDiagonalWin) winnings += Constants.PAYOUT;

            return winnings;
        }
    }
}
