/*Write a program that finds the largest area of equal neighbor elements
 * in a rectangular matrix and prints its size.
 * Example:
 * 1 3 2 2 2 4
 * 3 3 3 2 4 4
 * 4 3 1 2 3 3  ->  13
 * 4 3 1 3 3 1
 * 4 3 3 3 1 1
 * 
 * Hint: you can use the algorithm "Depth-first search" or
 * "Breadth-first search" (find them in Wikipedia).
 */

namespace MostEqualNeightbors
{
    using System;
    using System.Collections.Generic;
    class MostEqualNeightbors
    {
        static Random rnd = new Random();
        public static int[,] RandomMatrix(int rows, int cols)
        {
            int maxNumber = rows + 1;
            int[,] result = new int[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    result[row, col] = rnd.Next(1, maxNumber);
                }
            }
            return result;
        }
        static void PrintMatrix(int[,] inputMatrix)
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
        static List<int> FindMostEqualNeighbors(int currentRow, int currentCol, int[,] inputMatrix)
        {
            int tempValue = 0;
            List<int> result = new List<int>();
            tempValue = inputMatrix[currentRow, currentCol];

            //check up number
            if (inputMatrix[currentRow, currentCol] != 0 && (currentRow - 1) >= 0 && inputMatrix[currentRow - 1, currentCol] == tempValue)
            {
                inputMatrix[currentRow, currentCol] = -1 - currentCol - currentRow; //change the value to some negative "unique" value
                result.AddRange(FindMostEqualNeighbors(currentRow - 1, currentCol, inputMatrix)); //calls in recursion the first equal neighbor cell
            }

            //check down number
            if (inputMatrix[currentRow, currentCol] != 0 && (currentRow + 1) < inputMatrix.GetLength(0) && inputMatrix[currentRow + 1, currentCol] == tempValue)
            {
                inputMatrix[currentRow, currentCol] = -1 - currentCol - currentRow;
                result.AddRange(FindMostEqualNeighbors(currentRow + 1, currentCol, inputMatrix));
            }

            //check left number
            if (inputMatrix[currentRow, currentCol] != 0 && (currentCol - 1) >= 0 && inputMatrix[currentRow, currentCol - 1] == tempValue)
            {
                inputMatrix[currentRow, currentCol] = -1 - currentCol - currentRow;
                result.AddRange(FindMostEqualNeighbors(currentRow, currentCol - 1, inputMatrix));
            }

            //check right number
            if (inputMatrix[currentRow, currentCol] != 0 && (currentCol + 1) < inputMatrix.GetLength(1) && inputMatrix[currentRow, currentCol + 1] == tempValue)
            {
                inputMatrix[currentRow, currentCol] = -1 - currentCol - currentRow;
                result.AddRange(FindMostEqualNeighbors(currentRow, currentCol + 1, inputMatrix));
            }
            
            //bottom of recursion is reached
            inputMatrix[currentRow, currentCol] = 0; //mark the cell as 0 so it will not be checked again
            
            //add to result current row and collumn number. The result list will contain at the end "coordinates"
            //of the largest area of equal neighbor values
            result.Add(currentRow);
            result.Add(currentCol);
            return result;
        }
        static void Main()
        {
            Console.Write("Input number of rows: ");
            int rowsCount = int.Parse(Console.ReadLine());

            Console.Write("Input number of columns: ");
            int colsCount = int.Parse(Console.ReadLine());

            int[,] matrix = RandomMatrix(rowsCount, colsCount);
            PrintMatrix(matrix);

            int[,] input = (int[,])matrix.Clone();
            List<int> longestList = new List<int>();
            List<int> tempList = new List<int>();
            int equalNumbersCount = int.MinValue;
            for (int row = 0; row < rowsCount; row++)
            {
                for (int col = 0; col < colsCount; col++)
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

            Console.WriteLine("\n\nThe largest area of equal neighbor elements consisits of {0} elements.\n", (longestList.Count / 2));

            //print out the matrix and markup the largest area of equal neighbor elements
            for (int row = 0; row < rowsCount; row++)
            {
                for (int col = 0; col < colsCount; col++)
                {
                    bool isColor = false;
                    for (int color = 0; color < longestList.Count; color += 2)
                    {
                        if (row == longestList[color] && col == longestList[color + 1])
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.Write(matrix[row, col]);
                            Console.ResetColor();
                            Console.Write("\t");
                            isColor = true;
                            break;
                        }
                    }
                    if (!isColor)
                    {
                        Console.Write("{0}\t", matrix[row, col]);
                    }
                }
                Console.WriteLine();
            }
        }
    }
}