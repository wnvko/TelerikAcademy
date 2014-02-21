using System;

namespace ConsoleApplication
{
    class Chapter06Problem18
    {
        static void Main(string[] args)
        {
            Console.Write("Въведете число: ");
            int count= int.Parse(Console.ReadLine());
            int[,] numbers = new int[count, count];
            int row, column;
            int currentNumber = count * count;
            if (count % 2 == 0)
            {
                row = count / 2;
                column = count / 2 - 1;
                for (int i = 0; i < count; i++)
                {
                    if (i % 2 != 0)
                    {
                        for (int j = 0; j < i; j++)
                        {
                            numbers[row, column] = currentNumber;
                            currentNumber--;
                            column++;
                        }
                        for (int j = 0; j < i; j++)
                        {
                            numbers[row, column] = currentNumber;
                            currentNumber--;
                            row--;
                        }
                    }
                    else
                    {
                        for (int j = 0; j < i; j++)
                        {
                            numbers[row, column] = currentNumber;
                            currentNumber--;
                            column--;
                        }
                        for (int j = 0; j < i; j++)
                        {
                            numbers[row, column] = currentNumber;
                            currentNumber--;
                            row++;
                        }
                    }
                }
            }
            else
            {
                row = count / 2;
                column = count / 2;
                for (int i = 0; i < count; i++)
                {
                    if (i % 2 != 0)
                    {
                        for (int j = 0; j < i; j++)
                        {
                            numbers[row, column] = currentNumber;
                            currentNumber--;
                            column--;
                        }
                        for (int j = 0; j < i; j++)
                        {
                            numbers[row, column] = currentNumber;
                            currentNumber--;
                            row++;
                        }
                    }
                    else
                    {
                        for (int j = 0; j < i; j++)
                        {
                            numbers[row, column] = currentNumber;
                            currentNumber--;
                            column++;
                        }
                        for (int j = 0; j < i; j++)
                        {
                            numbers[row, column] = currentNumber;
                            currentNumber--;
                            row--;
                        }
                    }
                }
            }
            for (int i = count - 1; i >= 0; i--)
            {
                numbers[0, i] = currentNumber;
                currentNumber--;
            }
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    Console.Write("" + numbers[i, j] + " ");
                }
                Console.WriteLine("");
            }
        }
    }
}