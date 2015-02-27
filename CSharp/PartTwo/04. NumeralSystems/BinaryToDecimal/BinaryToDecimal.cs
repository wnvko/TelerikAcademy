/*
 * Write a program to convert binary numbers to their decimal representation.
 */

using System;

public class BinaryToDecimal
{
    public static void Main(string[] args)
    {
        Console.Write("Enter a binary number: ");
        string binaryNumber = Console.ReadLine();

        int decNumber = 0;
        for (int index = binaryNumber.Length - 1; index >= 0; index--)
        {
            int power = binaryNumber.Length - index - 1;
            if (binaryNumber[index] == '1')
            {
                decNumber = decNumber + (1 << power);
            }
        }

        Console.WriteLine("\nBinary {0} is decimal {1}", binaryNumber, decNumber);
    }
}
