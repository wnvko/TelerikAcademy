/*
 * Write a program that reads a rectangular matrix of size N x M and
 * finds in it the square 3 x 3 that has the maximal sum of its elements
 */

namespace MaximalSubMatrix
{
    using System;
    using System.Collections.Generic;

    class MaximalSubMatrix
    {
        static Random rnd = new Random();
        static int[,] GenerateRandomMatrix(int numberOfRows, int numberOfColumns)
        {
            int maxNumberInMatrix = numberOfRows * numberOfColumns * 2;
            int[,] randomMatrix = new int[numberOfRows, numberOfColumns];

            for (int row = 0; row < numberOfRows; row++)
            {
                for (int col = 0; col < numberOfColumns; col++)
                {
                    randomMatrix[row, col] = rnd.Next(maxNumberInMatrix);
                }
            }

            return randomMatrix;
        }

        static int[] FindMaximalSubmatrix(int[,] inputMatrix, int sizeOfSubMatrix)
        {
            int maxSum = int.MinValue;
            int[] subMatrixStartPoint = new int[2]; //store start row and col of the first element of maximal sub matrix
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

        static void Main()
        {
            const int SubMatrixSize = 3;

            Console.Write("Enter number of rows N: ");
            int numberOfRows = int.Parse(Console.ReadLine());
            Console.Write("Enter number of columns M: ");
            int numberOfCols = int.Parse(Console.ReadLine());

            int[,] matrix = new int[numberOfRows, numberOfCols];

            matrix = GenerateRandomMatrix(numberOfRows, numberOfCols);
            Console.WriteLine();
            Console.WriteLine("Input matrix");
            
            for (int row = 0; row < numberOfRows; row++)
            {
                for (int col = 0; col < numberOfCols; col++)
                {
                    Console.Write("{0}\t", matrix[row, col]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("-----------------------");
            Console.WriteLine();

            int[] maxPosition = FindMaximalSubmatrix(matrix, SubMatrixSize);
            int startRow = maxPosition[0];
            int startCol = maxPosition[1];
            int maxSum = 0;

            Console.WriteLine("Maximal sum sub matrix");
            for (int row = startRow; row < startRow + SubMatrixSize; row++)
            {
                for (int col = startCol; col < startCol + SubMatrixSize; col++)
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
}
