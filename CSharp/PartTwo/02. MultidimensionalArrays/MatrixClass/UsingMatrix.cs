/*
 * Write a class Matrix, to hold a matrix of integers. Overload the operators for adding, subtracting
 * and multiplying of matrices, indexer for accessing the matrix content and ToString().
 */

namespace Matrix
{
    using System;

    public class UsingMatrix
    {
        private static Random random = new Random();

        public static void Main()
        {
            Console.Write("Input number of rows: ");
            int rowsCount = int.Parse(Console.ReadLine());

            Console.Write("Input number of columns: ");
            int colsCount = int.Parse(Console.ReadLine());

            Matrix first = new Matrix(rowsCount, colsCount);
            first = RandomMatrix(first);

            Matrix second = new Matrix(rowsCount, colsCount);
            second = RandomMatrix(second);

            Matrix secondMultiply = new Matrix(colsCount, rowsCount);
            secondMultiply = RandomMatrix(secondMultiply);

            Console.WriteLine("First matrix:");
            Console.WriteLine(first.ToString());

            Console.WriteLine("\nSecond matrix:");
            Console.WriteLine(second.ToString());

            Console.WriteLine("\nSecond matrix (multiply):");
            Console.WriteLine(secondMultiply.ToString());

            Matrix sum = first + second;
            Matrix difference = first - second;
            Matrix multiply = first * secondMultiply;

            Console.WriteLine("\nSum:");
            Console.WriteLine(sum.ToString());

            Console.WriteLine("\nDifference:");
            Console.WriteLine(difference.ToString());

            Console.WriteLine("\nProduct:");
            Console.WriteLine(multiply.ToString());
        }

        private static Matrix RandomMatrix(Matrix input)
        {
            int maxNumberInMatrix = input.Rows * input.Cols * 2;
            Matrix result = new Matrix(input.Rows, input.Cols);
            for (int row = 0; row < result.Rows; row++)
            {
                for (int col = 0; col < result.Cols; col++)
                {
                    result[row, col] = random.Next(maxNumberInMatrix);
                }
            }

            return result;
        }
    }
}