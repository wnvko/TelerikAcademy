/*
 * We are given a matrix of strings of size N x M. Sequences in the matrix we define as sets of
 * several neighbour elements located on the same line, column or diagonal.
 * Write a program that finds the longest sequence of equal strings in the matrix.
 */

using System;

public class SequenceNMatrix
{
    private const int MaxNumberInMatrix = 5;
    private static Random rnd = new Random();

    public static void Main(string[] args)
    {
        Console.Write("Enter number of rows N: ");
        int numberOfRows = int.Parse(Console.ReadLine());

        Console.Write("Enter number of columns M: ");
        int numberOfCols = int.Parse(Console.ReadLine());

        int[,] matrix = GenerateRandomMatrix(numberOfRows, numberOfCols);

        Console.WriteLine("\nInput matrix");
        PrintMatrix(matrix);

        Console.WriteLine(new string('-', (numberOfCols - 1) * 9));
        Console.WriteLine();

        FindLongestLine(matrix);
    }

    private static int[,] GenerateRandomMatrix(int rows, int cols)
    {
        int[,] randomMatrix = new int[rows, cols];

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                randomMatrix[row, col] = rnd.Next(MaxNumberInMatrix);
            }
        }

        return randomMatrix;
    }

    private static void PrintMatrix(int[,] inputMatrix)
    {
        for (int row = 0; row < inputMatrix.GetLength(0); row++)
        {
            for (int col = 0; col < inputMatrix.GetLength(1); col++)
            {
                Console.Write("{0}\t", inputMatrix[row, col]);
            }

            Console.WriteLine();
        }
    }

    private static void FindLongestLine(int[,] inputMatrix)
    {
        int tempLenght;
        int maxLenght = 0;
        int startRow = 0;
        int startCol = 0;

        for (int row = 0; row < inputMatrix.GetLength(0); row++)
        {
            for (int col = 0; col < inputMatrix.GetLength(1); col++)
            {
                // look for same values down-left direction
                tempLenght = FindSameElements(inputMatrix, row, col, 1, -1);
                if (tempLenght > maxLenght)
                {
                    maxLenght = tempLenght;
                    startCol = col + 1;
                    startRow = row + 1;
                }

                // look for same values down direction
                tempLenght = FindSameElements(inputMatrix, row, col, 1, 0);
                if (tempLenght > maxLenght)
                {
                    maxLenght = tempLenght;
                    startCol = col + 1;
                    startRow = row + 1;
                }

                // look for same values down-right direction
                tempLenght = FindSameElements(inputMatrix, row, col, 1, 1);
                if (tempLenght > maxLenght)
                {
                    maxLenght = tempLenght;
                    startCol = col + 1;
                    startRow = row + 1;
                }

                // look for same values right direction
                tempLenght = FindSameElements(inputMatrix, row, col, 0, 1);
                if (tempLenght > maxLenght)
                {
                    maxLenght = tempLenght;
                    startCol = col + 1;
                    startRow = row + 1;
                }
            }
        }

        Console.WriteLine("The longest line starts from row {0} and column {1}", startRow, startCol);
        Console.WriteLine("and has length of {0}.", maxLenght);
    }

    private static int FindSameElements(int[,] inputMatrix, int row, int col, int rowDirection, int colDirection)
    {
        int maxLenght = 1;
        bool isInMatrix = true;
        isInMatrix = row + rowDirection >= 0;
        isInMatrix = isInMatrix && row + rowDirection < inputMatrix.GetLength(0);
        isInMatrix = isInMatrix && col + colDirection >= 0;
        isInMatrix = isInMatrix && col + colDirection < inputMatrix.GetLength(1);

        if (isInMatrix && inputMatrix[row, col] == inputMatrix[row + rowDirection, col + colDirection])
        {
            row += rowDirection;
            col += colDirection;
            maxLenght = FindSameElements(inputMatrix, row, col, rowDirection, colDirection);
            maxLenght++;
        }

        return maxLenght;
    }
}
