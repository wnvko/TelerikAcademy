namespace Minesweeper
{
    using System;
    using System.Collections.Generic;

    public class PlayGround
    {
        internal static char[,] PlaygroundInitialisation()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];
            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        internal static void DrawPlayGround(char[,] playGround)
        {
            int rows = playGround.GetLength(0);
            int cols = playGround.GetLength(1);

            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");

            for (int i = 0; i < rows; i++)
            {
                Console.Write("{0} | ", i);

                for (int j = 0; j < cols; j++)
                {
                    Console.Write(string.Format("{0} ", playGround[i, j]));
                }

                Console.WriteLine("|");
            }

            Console.WriteLine("   ---------------------\n");
        }

        internal static void CalculateCellsNumbers(char[,] playGround)
        {
            int cols = playGround.GetLength(0);
            int rows = playGround.GetLength(1);

            for (int i = 0; i < cols; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    if (playGround[i, j] != '*')
                    {
                        char surroundingMinesCount = SurroundingMinesCount(playGround, i, j);
                        playGround[i, j] = surroundingMinesCount;
                    }
                }
            }
        }

        internal static char SurroundingMinesCount(char[,] playGround, int currentRow, int currentCol)
        {
            int count = 0;
            int rows = playGround.GetLength(0);
            int cols = playGround.GetLength(1);

            if ((currentRow - 1 >= 0) && (playGround[currentRow - 1, currentCol] == '*'))
            {
                count++;
            }

            if ((currentRow + 1 < rows) && (playGround[currentRow + 1, currentCol] == '*'))
            {
                count++;
            }

            if ((currentCol - 1 >= 0) && (playGround[currentRow, currentCol - 1] == '*'))
            {
                count++;
            }

            if ((currentCol + 1 < cols) && (playGround[currentRow, currentCol + 1] == '*'))
            {
                count++;
            }

            if ((currentRow - 1 >= 0) && (currentCol - 1 >= 0) &&
                (playGround[currentRow - 1, currentCol - 1] == '*'))
            {
                count++;
            }

            if ((currentRow - 1 >= 0) && (currentCol + 1 < cols) &&
                (playGround[currentRow - 1, currentCol + 1] == '*'))
            {
                count++;
            }

            if ((currentRow + 1 < rows) && (currentCol - 1 >= 0) &&
                (playGround[currentRow + 1, currentCol - 1] == '*'))
            {
                count++;
            }

            if ((currentRow + 1 < rows) && (currentCol + 1 < cols) &&
                (playGround[currentRow + 1, currentCol + 1] == '*'))
            {
                count++;
            }

            return char.Parse(count.ToString());
        }

        internal static char[,] PutMines()
        {
            int rows = 5;
            int cols = 10;
            char[,] playGround = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    playGround[i, j] = '-';
                }
            }

            List<int> randomMines = new List<int>();
            while (randomMines.Count < 15)
            {
                Random random = new Random();
                int rnd = random.Next(50);
                if (!randomMines.Contains(rnd))
                {
                    randomMines.Add(rnd);
                }
            }

            foreach (int randomMine in randomMines)
            {
                int mineCol = randomMine / cols;
                int mineRow = randomMine % cols;
                if (mineRow == 0 && randomMine != 0)
                {
                    mineCol--;
                    mineRow = cols;
                }
                else
                {
                    mineRow++;
                }

                playGround[mineCol, mineRow - 1] = '*';
            }

            return playGround;
        }
    }
}
