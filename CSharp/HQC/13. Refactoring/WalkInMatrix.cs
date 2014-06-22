namespace Matrix
{
    using System;

    public class WalkInMatrix
    {
        public static void Main()
        {
            // to have working unit test please comment next row and uncomment 12th row
            int matrixSize = GetUserMatrixSize();

            //int matrixSize = 2;
            int[,] matrix = GenerateWalkInMatrix(matrixSize);
            PrintMatrixOnConsole(matrix);
        }

        public static int[,] GenerateWalkInMatrix(int matrixSize)
        {
            int[,] matrix = new int[matrixSize, matrixSize];
            int currentCellValue = 1;
            int currentRow = 0;
            int currentCol = 0;
            int rowOffset;
            int colOffset;

            FillMatrixCells(matrixSize, matrix, ref currentCellValue, ref currentRow, ref currentCol, out rowOffset, out colOffset);

            FindNextEmptyCell(matrix, out currentRow, out currentCol);

            if (currentRow != 0 && currentCol != 0)
            {
                FillMatrixCells(matrixSize, matrix, ref currentCellValue, ref currentRow, ref currentCol, out rowOffset, out colOffset);
            }

            return matrix;
        }

        private static int GetUserMatrixSize()
        {
            Console.WriteLine("Enter a positive number ");
            string input = Console.ReadLine();
            int matrixSize = 0;

            while (!int.TryParse(input, out matrixSize) || matrixSize < 0 || matrixSize > 100)
            {
                Console.WriteLine("You haven't entered a correct positive number");
                input = Console.ReadLine();
            }

            return matrixSize;
        }
        
        private static void PrintMatrixOnConsole(int[,] matrix)
        {
            int matrixSize = matrix.GetLength(0);

            for (int row = 0; row < matrixSize; row++)
            {
                for (int col = 0; col < matrixSize; col++)
                {
                    Console.Write("{0, 6}", matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        private static void FillMatrixCells(int matrixSize, int[,] matrix, ref int currentCellValue, ref int currentRow, ref int currentCol, out int rowOffset, out int colOffset)
        {
            rowOffset = 1;
            colOffset = 1;

            while (true)
            {
                matrix[currentRow, currentCol] = currentCellValue;
                currentCellValue++;

                bool isOutOfTheMatrix = IsOutOfMatrix(matrixSize, currentRow, currentCol, rowOffset, colOffset);

                if (isOutOfTheMatrix || matrix[currentRow + rowOffset, currentCol + colOffset] != 0)
                {
                    if (!IsMatrixFull(matrix, currentRow, currentCol))
                    {
                        break;
                    }

                    while (isOutOfTheMatrix || matrix[currentRow + rowOffset, currentCol + colOffset] != 0)
                    {
                        FindNextDirectionOffsets(ref rowOffset, ref colOffset);
                        isOutOfTheMatrix = IsOutOfMatrix(matrixSize, currentRow, currentCol, rowOffset, colOffset);
                    }
                }

                currentRow += rowOffset;
                currentCol += colOffset;
            }
        }

        private static void FindNextEmptyCell(int[,] matrix, out int currentRow, out int currentCol)
        {
            currentRow = 0;
            currentCol = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(0); col++)
                {
                    if (matrix[row, col] == 0)
                    {
                        currentRow = row;
                        currentCol = col;
                        return;
                    }
                }
            }
        }

        private static bool IsOutOfMatrix(int matrixSize, int currentRow, int currentCol, int rowOffset, int colOffset)
        {
            bool isOutOfMatrix = currentRow + rowOffset >= matrixSize ||
                                 currentRow + rowOffset < 0 ||
                                 currentCol + colOffset >= matrixSize ||
                                 currentCol + colOffset < 0;
            return isOutOfMatrix;
        }

        private static bool IsMatrixFull(int[,] matrix, int row, int col)
        {
            int[] rowOffset = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] colOffset = { 1, 0, -1, -1, -1, 0, 1, 1 };
            int possibleDirections = rowOffset.Length;

            for (int i = 0; i < possibleDirections; i++)
            {
                if (row + rowOffset[i] >= matrix.GetLength(0) || row + rowOffset[i] < 0)
                {
                    rowOffset[i] = 0;
                }

                if (col + colOffset[i] >= matrix.GetLength(0) || col + colOffset[i] < 0)
                {
                    colOffset[i] = 0;
                }

                if (matrix[row + rowOffset[i], col + colOffset[i]] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        private static void FindNextDirectionOffsets(ref int currentRowOffset, ref int currentColOffset)
        {
            int[] rowOffset = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] colOffset = { 1, 0, -1, -1, -1, 0, 1, 1 };

            int currentDirection = 0;

            for (int direction = 0; direction < 8; direction++)
            {
                if (rowOffset[direction] == currentRowOffset && colOffset[direction] == currentColOffset)
                {
                    currentDirection = direction;
                    break;
                }
            }

            if (currentDirection == 7)
            {
                currentRowOffset = rowOffset[0];
                currentColOffset = colOffset[0];
                return;
            }

            currentRowOffset = rowOffset[currentDirection + 1];
            currentColOffset = colOffset[currentDirection + 1];
        }
    }
}
