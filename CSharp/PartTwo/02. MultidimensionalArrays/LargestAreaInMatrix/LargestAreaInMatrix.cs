/*
 * Write a program that finds the largest area of equal neighbour elements in a rectangular matrix and prints its size.
 */

using System;
using System.Collections.Generic;

public class LargestAreaInMatrix
{
    private static Random random = new Random();

    public static void Main(string[] args)
    {
        Console.Write("Input number of rows: ");
        int rows = int.Parse(Console.ReadLine());

        Console.Write("Input number of columns: ");
        int cols = int.Parse(Console.ReadLine());

        int[,] matrix = RandomMatrix(rows, cols);
        PrintMatrix(matrix);

        int[,] input = (int[,])matrix.Clone();
        List<int> longestList = new List<int>();
        List<int> tempList = new List<int>();
        int equalNumbersCount = int.MinValue;
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                tempList.AddRange(FindMostEqualNeighbors(row, col, (int[,])input.Clone()));

                if (tempList.Count > equalNumbersCount)
                {
                    equalNumbersCount = tempList.Count;
                    longestList.Clear();
                    longestList.AddRange(tempList);
                }

                tempList.Clear();
            }
        }

        Console.WriteLine("\n\nThe largest area of equal neighbor elements consists of {0} elements.\n", longestList.Count / 2);

        // print out the matrix and markup the largest area of equal neighbor elements
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                bool colored = false;
                for (int color = 0; color < longestList.Count; color += 2)
                {
                    if (row == longestList[color] && col == longestList[color + 1])
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.Write(matrix[row, col]);
                        Console.ResetColor();
                        Console.Write("\t");
                        colored = true;
                        break;
                    }
                }

                if (!colored)
                {
                    Console.Write("{0}\t", matrix[row, col]);
                }
            }

            Console.WriteLine();
        }
    }

    private static int[,] RandomMatrix(int rows, int cols)
    {
        int maxNumber = cols;
        int[,] result = new int[rows, cols];

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                result[row, col] = random.Next(1, maxNumber);
            }
        }

        return result;
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

    private static List<int> FindMostEqualNeighbors(int currentRow, int currentCol, int[,] inputMatrix)
    {
        int tempValue = 0;
        List<int> result = new List<int>();
        tempValue = inputMatrix[currentRow, currentCol];

        if (inputMatrix[currentRow, currentCol] != 0 && (currentRow - 1) >= 0 && inputMatrix[currentRow - 1, currentCol] == tempValue)
        {
            inputMatrix[currentRow, currentCol] = -1 - currentCol - currentRow;
            result.AddRange(FindMostEqualNeighbors(currentRow - 1, currentCol, inputMatrix));
        }

        if (inputMatrix[currentRow, currentCol] != 0 && (currentRow + 1) < inputMatrix.GetLength(0) && inputMatrix[currentRow + 1, currentCol] == tempValue)
        {
            inputMatrix[currentRow, currentCol] = -1 - currentCol - currentRow;
            result.AddRange(FindMostEqualNeighbors(currentRow + 1, currentCol, inputMatrix));
        }

        if (inputMatrix[currentRow, currentCol] != 0 && (currentCol - 1) >= 0 && inputMatrix[currentRow, currentCol - 1] == tempValue)
        {
            inputMatrix[currentRow, currentCol] = -1 - currentCol - currentRow;
            result.AddRange(FindMostEqualNeighbors(currentRow, currentCol - 1, inputMatrix));
        }

        if (inputMatrix[currentRow, currentCol] != 0 && (currentCol + 1) < inputMatrix.GetLength(1) && inputMatrix[currentRow, currentCol + 1] == tempValue)
        {
            inputMatrix[currentRow, currentCol] = -1 - currentCol - currentRow;
            result.AddRange(FindMostEqualNeighbors(currentRow, currentCol + 1, inputMatrix));
        }

        inputMatrix[currentRow, currentCol] = 0;

        result.Add(currentRow);
        result.Add(currentCol);
        return result;
    }
}
