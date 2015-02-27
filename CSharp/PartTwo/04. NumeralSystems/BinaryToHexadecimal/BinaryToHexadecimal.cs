/*
 * Write a program to convert binary numbers to hexadecimal numbers (directly).
 */

using System;
using System.Collections.Generic;

public class BinaryToHexadecimal
{
    private static Dictionary<string, char> binDigits = new Dictionary<string, char>()
    {
        { "0000", '0' },
        { "0001", '1' },
        { "0010", '2' },
        { "0011", '3' },
        { "0100", '4' },
        { "0101", '5' },
        { "0110", '6' },
        { "0111", '7' },
        { "1000", '8' },
        { "1001", '9' },
        { "1010", 'A' },
        { "1011", 'B' },
        { "1100", 'C' },
        { "1101", 'D' },
        { "1110", 'E' },
        { "1111", 'F' },
    };

    public static void Main(string[] args)
    {
        Console.Write("Enter a binary number: ");
        string binNumber = Console.ReadLine();
        string hexNumber = string.Empty;

        int leadingZerosCount = 4 - (binNumber.Length % 4);
        if (leadingZerosCount == 4)
        {
            leadingZerosCount = 0;
        }

        binNumber = new string('0', leadingZerosCount) + binNumber;

        for (int index = 0; index < binNumber.Length; index += 4)
        {
            hexNumber = hexNumber + binDigits[binNumber.Substring(index, 4)];
        }

        Console.WriteLine("\nBinary {0} is Hexadecimal {1}", binNumber, hexNumber);
    }
}
