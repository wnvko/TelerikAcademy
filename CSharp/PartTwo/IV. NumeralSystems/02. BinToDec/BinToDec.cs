/*
 * Write a program to convert binary numbers to their decimal representation.
 */

namespace BinToDec
{
    using System;
    using System.Collections.Generic;
    class BinToDec
    {
        static void Main()
        {
            Console.Write("Enter a binary number: ");
            string binaryNumber = Console.ReadLine();
            int decNumber = 0;
            for (int index = binaryNumber.Length - 1; index >= 0; index--)
            {
                int power = binaryNumber.Length - index - 1;
                decNumber = decNumber + int.Parse(binaryNumber[index].ToString()) * (int)Math.Pow(2, power);
            }
            Console.WriteLine("\nBinary {0} is decimal {1}", binaryNumber, decNumber);
        }
    }
}
