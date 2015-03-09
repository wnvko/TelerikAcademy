/*
 * Write a program that reads a text file containing a square matrix of numbers. Find an area of
 * size 2 x 2 in the matrix, with a maximal sum of its elements. The first line in the input file
 * contains the size of matrix N. Each of the next N lines contain N numbers separated by space.
 * The output should be a single number in a separate text file.
 */

using System;
using System.Diagnostics;
using System.IO;
using System.Text;

public struct Result
{
    public int MaxSum { get; set; }

    public int StartRow { get; set; }

    public int StartCol { get; set; }
}

public class MaximalAreaSum
{
    private const string MatrixFileName = @"..\..\SampleText.txt";
    private const string ResultFileName = @"ResultText.txt";
    private static Random rnd = new Random();
    private static int rows = 6;
    private static int cols = 10;
    private static int submatrixSize = 2;

    public static void Main()
    {
        // generate random matrix in SampleText.txt
        int[,] randomMatrix = GenerateRandomMatrix(rows, cols);
        WriteMatrixTofile(randomMatrix, MatrixFileName);

        // read matrix from file
        int[,] matrix = ReadMatrixFromFile(MatrixFileName);

        // print input matrix
        PrintMatrix(matrix);

        // find and print maximal sub matrix
        Result result = FindMaximalSubmatrix(matrix, submatrixSize);

        WriteResult(result.MaxSum, ResultFileName);

        Console.WriteLine("\nMaximal sum is {0} and starts at [{1}, {2}]", result.MaxSum, result.StartRow, result.StartCol);
    }

    private static int[,] GenerateRandomMatrix(int numberOfRows, int numberOfColumns)
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

    private static void WriteMatrixTofile(int[,] inputMatrix, string fileName)
    {
        StreamWriter matrix = new StreamWriter(fileName);
        int rowsCount = inputMatrix.GetLength(0);
        int colsCount = inputMatrix.GetLength(1);
        StringBuilder currentRow = new StringBuilder();

        using (matrix)
        {
            matrix.WriteLine(rowsCount);
            matrix.WriteLine(colsCount);
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

        Process.Start("notepad.exe", fileName);
    }

    private static int[,] ReadMatrixFromFile(string filePath)
    {
        StreamReader inputFile = new StreamReader(filePath);
        int[,] matrix;
        using (inputFile)
        {
            int rowsCount = int.Parse(inputFile.ReadLine());
            int colsCount = int.Parse(inputFile.ReadLine());
            matrix = new int[rowsCount, colsCount];
            for (int row = 0; row < rowsCount; row++)
            {
                string tempText = inputFile.ReadLine();
                string[] numbersAsString = tempText.Split(' ');
                for (int col = 0; col < colsCount; col++)
                {
                    matrix[row, col] = int.Parse(numbersAsString[col]);
                }
            }
        }

        return matrix;
    }

    private static void PrintMatrix(int[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write("{0}\t", matrix[row, col]);
            }

            Console.WriteLine();
        }
    }

    private static Result FindMaximalSubmatrix(int[,] matrix, int sizeOfSubMatrix)
    {
        Result result = new Result();
        result.MaxSum = int.MinValue;
        for (int row = 0; row < matrix.GetLength(0) - sizeOfSubMatrix + 1; row++)
        {
            for (int col = 0; col < matrix.GetLength(1) - sizeOfSubMatrix + 1; col++)
            {
                int curentSum = 0;
                for (int subRow = 0; subRow < sizeOfSubMatrix; subRow++)
                {
                    for (int subCol = 0; subCol < sizeOfSubMatrix; subCol++)
                    {
                        curentSum += matrix[row + subRow, col + subCol];
                    }
                }

                if (curentSum > result.MaxSum)
                {
                    result.MaxSum = curentSum;
                    result.StartRow = row;
                    result.StartCol = col;
                }
            }
        }

        return result;
    }

    private static void WriteResult(int result, string fileName)
    {
        StreamWriter resultFile = new StreamWriter(fileName);

        using (resultFile)
        {
            resultFile.WriteLine(result);
        }

        Process.Start("notepad.exe", fileName);
    }
}