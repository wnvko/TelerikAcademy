/*
 * Write a program that reads a text file containing a square matrix of numbers
 * and finds in the matrix an area of size 2 x 2 with a maximal sum of its elements.
 * The first line in the input file contains the size of matrix N. Each of the next
 * N lines contain N numbers separated by space. The output should be a single
 * number in a separate text file. Example:
 * 4
 * 2 3 3 1 
 * 2 3 4 1    ->17
 * 3 7 1 2
 * 4 3 3 2
 */

namespace MaxSubmatrixFinder
{
    using System;
    using System.IO;
    using System.Text;

    public class MaxSubmatrixFinder
    {
        private static Random rnd = new Random();

        public static int[,] GenerateRandomMatrix(int numberOfRows, int numberOfColumns)
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

        public static void WriteMatrixTofile(int[,] inputMatrix)
        {
            StreamWriter matrix = new StreamWriter(@"..\..\SampleText.txt");
            int rowsCount = inputMatrix.GetLength(0);
            int colsCount = inputMatrix.GetLength(1);
            StringBuilder currentRow = new StringBuilder();

            using (matrix)
            {
                matrix.WriteLine(rowsCount);
                for (int row = 0; row < rowsCount; row++)
                {
                    for (int col = 0; col < colsCount; col++)
                    {
                        currentRow.Append(inputMatrix[row, col]);
                        currentRow.Append(" ");
                    }

                    matrix.WriteLine(currentRow.ToString().Trim());
                    currentRow.Clear();
                }
            }
        }

        public static int FindMaximalSubmatrix(int[,] inputMatrix, int sizeOfSubMatrix)
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

            return maxSum;
        }

        public static void PrintMatrix(int[,] inputMatrix)
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

        public static int[,] ReadMatrixFromFile(string filePath)
        {
            StreamReader inputFile = new StreamReader(filePath);
            int[,] matrix;
            using (inputFile)
            {
                int sizeOfMatrix = int.Parse(inputFile.ReadLine());
                matrix = new int[sizeOfMatrix, sizeOfMatrix];
                for (int row = 0; row < sizeOfMatrix; row++)
                {
                    string tempText = inputFile.ReadLine();
                    string[] numbersAsString = tempText.Split(' ');
                    for (int col = 0; col < sizeOfMatrix; col++)
                    {
                        matrix[row, col] = int.Parse(numbersAsString[col]);
                    }
                }
            }

            return matrix;
        }

        public static void Main()
        {
            // generate random matrix in SampleText.txt
            int[,] randomMatrix = GenerateRandomMatrix(6, 10);
            WriteMatrixTofile(randomMatrix);

            // read matrix from file
            int[,] matrix = ReadMatrixFromFile(@"..\..\SampleText.txt");

            // print input matrix
            PrintMatrix(matrix);

            // find and print maximal submatrix
            int maxSum = FindMaximalSubmatrix(matrix, 2);
            Console.WriteLine("\nMaximal sum is {0}", maxSum);
        }
    }
}
