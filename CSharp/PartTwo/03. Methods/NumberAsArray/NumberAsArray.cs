/*
 * Write a method that adds two positive integer numbers represented as arrays of digits (each
 * array element arr[i] contains a digit; the last digit is kept in arr[0]). Each of the numbers
 * that will be added could have up to 10 000 digits.
 */

namespace MySpace
{

    using System;
    using System.Linq;
    using System.Collections.Generic;


    public class NumberAsArray
    {
        public static void Main(string[] args)
        {
            var myClass = new NumberAsArray();
            var myHelpClass = new HelperClass();

            Console.Write("Enter the length of first integer: ");
            int firstIntLenght = int.Parse(Console.ReadLine());

            Console.Write("Enter the length of second integer: ");
            int secondIntLenght = int.Parse(Console.ReadLine());

            int[] firstNumber = myHelpClass.GenerateRandomArray<int>(firstIntLenght, 10);
            int[] secondNumber = myHelpClass.GenerateRandomArray<int>(secondIntLenght, 10);

            //// Hardcode values
            // firstNumber = new int[6] { 1, 2, 3, 4, 5, 6 };
            // secondNumber = new int[3] { 7, 8, 9 };

            int pad = 0;
            int lengthDifference = firstIntLenght - secondIntLenght;

            Console.WriteLine();
            Console.Write("First number:");
            pad = Console.CursorLeft + 4;
            if (lengthDifference < 0)
            {
                pad += Math.Abs(lengthDifference * 2);
            }

            Console.SetCursorPosition(pad, Console.CursorTop);
            myHelpClass.PrintArray(firstNumber);

            Console.WriteLine();
            Console.Write("Second number:");
            pad = Console.CursorLeft + 3;
            if (lengthDifference > 0)
            {
                pad += Math.Abs(lengthDifference * 2);
            }

            Console.SetCursorPosition(pad, Console.CursorTop);
            myHelpClass.PrintArray(secondNumber);
            Console.WriteLine();

            int[] resultNumber = myClass.SumBigIntegers(firstNumber, secondNumber);
            Console.Write("Result number:");
            pad = Console.CursorLeft + 3;
            Console.SetCursorPosition(pad, Console.CursorTop);
            myHelpClass.PrintArray(resultNumber);
            Console.WriteLine();
        }

        public int[] SumBigIntegers(int[] firstNumber, int[] secondNumber)
        {
            int[] longer = firstNumber.Length > secondNumber.Length ? firstNumber : secondNumber;
            int[] shorter = firstNumber.Length <= secondNumber.Length ? firstNumber : secondNumber;
            int resultLenght = longer.Length + 1;

            int temp = 0;
            int counter = resultLenght - 2;
            int lenghtDifference = longer.Length - shorter.Length;
            int[] resultNumber = new int[resultLenght];

            for (int pos = counter; pos >= 0; pos--)
            {
                if (pos - lenghtDifference >= 0)
                {
                    temp = longer[pos] + shorter[pos - lenghtDifference] + temp;
                }
                else
                {
                    temp = longer[pos] + temp;
                }

                if (temp < 10)
                {
                    resultNumber[pos + 1] = temp;
                    temp = 0;
                }
                else
                {
                    resultNumber[pos + 1] = temp % 10;
                    temp = 1;
                }
            }

            if (temp != 0)
            {
                resultNumber[0] = temp;
            }
            else
            {
                List<int> trimmed = resultNumber.ToList();
                trimmed.RemoveAt(0);
                resultNumber = trimmed.ToArray();
            }

            return resultNumber;
        }
    }
}