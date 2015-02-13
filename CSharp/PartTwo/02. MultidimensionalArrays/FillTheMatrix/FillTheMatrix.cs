/*
 * Write a program that fills and prints a matrix of size (n, n) as shown below:
 * 
 * Example for n=4:
 * 
 * a)               b)              c)              d)
 * 1 5  9 13        1 8  9 16       7 11 14 16      1 12 11 10
 * 2 6 10 14        2 7 10 15       4  8 12 15      2 13 16  9
 * 3 7 11 15        3 6 11 14       2  5  9 13      3 14 15  8
 * 4 8 12 16        4 5 12 13       1  3  6 10      4  5  6  7
 */

using System;

public class FillTheMatrix
{
    public static void Main(string[] args)
    {
        Console.Write("Enter the size of the matrix: ");
        int matrixSize = int.Parse(Console.ReadLine());

        Console.Write("Enter type of the matrix (A, B, C or D): ");
        char matrixType = char.Parse(Console.ReadLine());

        switch (matrixType)
        {
            case 'A':
                {
                    PrintMatrixTypeA(matrixSize);
                    break;
                }

            case 'B':
                {
                    PrintMatrixTypeB(matrixSize);
                    break;
                }

            case 'C':
                {
                    PrintMatrixTypeC(matrixSize);
                    break;
                }

            case 'D':
                {
                    PrintMatrixTypeD(matrixSize);
                    break;
                }

            default:
                {
                    Console.WriteLine("The type is not correct!");
                    break;
                }
        }
    }

    private static void PrintMatrix(int[,] matrixToPrint)
    {
        for (int row = 0; row < matrixToPrint.GetLength(0); row++)
        {
            for (int col = 0; col < matrixToPrint.GetLength(1); col++)
            {
                Console.Write(matrixToPrint[row, col] + "\t");
            }

            Console.WriteLine();
        }
    }

    private static void PrintMatrixTypeA(int matrixSize)
    {
        int[,] matrix = new int[matrixSize, matrixSize];
        int counter = 0;

        for (int col = 0; col < matrixSize; col++)
        {
            for (int row = 0; row < matrixSize; row++)
            {
                counter++;
                matrix[row, col] = counter;
            }
        }

        PrintMatrix(matrix);
    }

    private static void PrintMatrixTypeB(int matrixSize)
    {
        int[,] matrix = new int[matrixSize, matrixSize];
        int counter = 0;

        for (int col = 0; col < matrixSize; col++)
        {
            if (col % 2 != 0)
            {
                for (int row = matrixSize - 1; row >= 0; row--)
                {
                    counter++;
                    matrix[row, col] = counter;
                }
            }
            else
            {
                for (int row = 0; row < matrixSize; row++)
                {
                    counter++;
                    matrix[row, col] = counter;
                }
            }
        }

        PrintMatrix(matrix);
    }

    private static void PrintMatrixTypeC(int matrixSize)
    {
        int[,] matrix = new int[matrixSize, matrixSize];
        int counter = 0;

        for (int col = 0; col < matrixSize; col++)
        {
            for (int row = 0; row <= col; row++)
            {
                counter++;
                matrix[matrixSize - col + row - 1, row] = counter;
            }
        }

        for (int col = 1; col < matrixSize; col++)
        {
            for (int row = 0; row < matrixSize - col; row++)
            {
                counter++;
                matrix[row, row + col] = counter;
            }
        }

        PrintMatrix(matrix);
    }

    private static void PrintMatrixTypeD(int matrixSize)
    {
        int[,] matrix = new int[matrixSize, matrixSize];
        int counter = 0;
        int row = 0;
        int col = 0;

        while (counter < matrixSize * matrixSize)
        {
            // down
            while (true)
            {
                if (row < matrixSize && matrix[row, col] == 0)
                {
                    counter++;
                    matrix[row, col] = counter;
                    row++;
                }
                else
                {
                    row--;
                    col++;
                    break;
                }
            }

            // right
            while (true)
            {
                if (col < matrixSize && matrix[row, col] == 0)
                {
                    counter++;
                    matrix[row, col] = counter;
                    col++;
                }
                else
                {
                    col--;
                    row--;
                    break;
                }
            }

            // up
            while (true)
            {
                if (row >= 0 && matrix[row, col] == 0)
                {
                    counter++;
                    matrix[row, col] = counter;
                    row--;
                }
                else
                {
                    row++;
                    col--;
                    break;
                }
            }

            // left
            while (true)
            {
                if (col > 0 && matrix[row, col] == 0)
                {
                    counter++;
                    matrix[row, col] = counter;
                    col--;
                }
                else
                {
                    col++;
                    row++;
                    break;
                }
            }
        }

        PrintMatrix(matrix);
    }
}
