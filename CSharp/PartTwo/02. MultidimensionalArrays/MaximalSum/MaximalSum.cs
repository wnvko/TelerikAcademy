/*
 * Write a program that reads a rectangular matrix of size N x M and finds in it the square 3 x 3 that has maximal sum of its elements.
 */

using System;

public class MaximalSum
{
    private static Random random = new Random();

    public static void Main()
    {
        const int SubMatrixSize = 3;

        Console.Write("Enter number of rows N: ");
        int rows = int.Parse(Console.ReadLine());
        Console.Write("Enter number of columns M: ");
        int cols = int.Parse(Console.ReadLine());

        int[,] matrix = GenerateRandomMatrix(rows, cols);

        PrintResult(SubMatrixSize, rows, cols, matrix);
    }

    private static int[,] GenerateRandomMatrix(int rows, int cols)
    {
        int maxNumberInMatrix = rows * cols * 2;
        int[,] randomMatrix = new int[rows, cols];

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                randomMatrix[row, col] = random.Next(maxNumberInMatrix);
            }
        }

        return randomMatrix;
    }

    private static int[] FindMaximalSubmatrix(int[,] inputMatrix, int sizeOfSubMatrix)
    {
        int maxSum = int.MinValue;
        int[] subMatrixStartPoint = new int[2];
        for (int row = 0; row < inputMatrix.GetLength(0) - sizeOfSubMatrix + 1; row++)
        {
            for (int col = 0; col < inputMatrix.GetLength(1) - sizeOfSubMatrix + 1; col++)
            {
                int curentSum = 0;
                for (int subRow = 0; subRow < sizeOfSubMatrix; subRow++)
                {
                    for (int subCol = 0; subCol < sizeOfSubMatrix; subCol++)
                    {
                        curentSum += inputMatrix[row + subRow, col + subCol];
                    }
                }

                if (curentSum > maxSum)
                {
                    maxSum = curentSum;
                    subMatrixStartPoint[0] = row;
                    subMatrixStartPoint[1] = col;
                }
            }
        }

        return subMatrixStartPoint;
    }

    private static void PrintResult(int subMatrixSize, int rows, int cols, int[,] matrix)
    {
        Console.WriteLine();
        Console.WriteLine("Input matrix");

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                Console.Write("{0}\t", matrix[row, col]);
            }

            Console.WriteLine();
        }

        Console.WriteLine(new string('-', rows * 4));
        Console.WriteLine();

        int[] maxPosition = FindMaximalSubmatrix(matrix, subMatrixSize);
        int startRow = maxPosition[0];
        int startCol = maxPosition[1];
        int maxSum = 0;

        Console.WriteLine("Maximal sum sub matrix");
        for (int row = startRow; row < Math.Min(rows, startRow + subMatrixSize); row++)
        {
            for (int col = startCol; col < Math.Min(cols, startCol + subMatrixSize); col++)
            {
                Console.Write("{0}\t", matrix[row, col]);
                maxSum += matrix[row, col];
            }

            Console.WriteLine();
        }

        Console.WriteLine("-----------------------");
        Console.WriteLine("Max sum  = {0}", maxSum);
    }
}
