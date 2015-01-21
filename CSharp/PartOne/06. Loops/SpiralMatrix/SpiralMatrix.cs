namespace SpiralMatrix
{
    using System;

    public class SpiralMatrix
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter N: ");
            int inputNumber = int.Parse(Console.ReadLine());

            int finalNumber = inputNumber * inputNumber;
            int[,] matrix = new int[inputNumber, inputNumber];
            int row = 0;
            int column = 0;
            int currentNumber = 0;

            while (true)
            {
                // Print numbers right
                while (true)
                {
                    currentNumber++;
                    if (currentNumber > finalNumber)
                    {
                        break;
                    }

                    matrix[row, column] = currentNumber;
                    column++;

                    if ((column > inputNumber - 1) || (matrix[row, column] != 0))
                    {
                        column--;
                        break;
                    }
                }

                row++;

                // Print numbers down
                while (true)
                {
                    currentNumber++;
                    if (currentNumber > finalNumber)
                    {
                        break;
                    }

                    matrix[row, column] = currentNumber;
                    row++;

                    if ((row > inputNumber - 1) || (matrix[row, column] != 0))
                    {
                        row--;
                        break;
                    }
                }

                column--;

                // Print numbers left
                while (true)
                {
                    currentNumber++;
                    if (currentNumber > finalNumber)
                    {
                        break;
                    }

                    matrix[row, column] = currentNumber;
                    column--;

                    if ((column < 0) || (matrix[row, column] != 0))
                    {
                        column++;
                        break;
                    }
                }

                row--;

                // Print numbers up
                while (true)
                {
                    currentNumber++;
                    if (currentNumber > finalNumber)
                    {
                        break;
                    }

                    matrix[row, column] = currentNumber;
                    row--;

                    if ((row < 0) || (matrix[row, column] != 0))
                    {
                        row++;
                        break;
                    }
                }

                if (currentNumber >= finalNumber)
                {
                    break;
                }

                column++;
            }

            // Print the matrix
            for (int i = 0; i < inputNumber; i++)
            {
                Console.Write("|");
                for (int j = 0; j < inputNumber; j++)
                {
                    Console.Write("{0:000}|", matrix[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}
