/*
 * Write a program to convert decimal numbers to their hexadecimal representation.
 */

using System;
using System.Collections.Generic;

public class DecimalToHexadecimal
{
    private static List<char> hexDigits = new List<char>() { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };

    public static void Main(string[] args)
    {
        Console.Write("Enter an integer: ");
        int numberInDec = int.Parse(Console.ReadLine());
        Console.Write("\n{0} in hexadecimal is: ", numberInDec);

        List<char> numberInHex = new List<char>();
        while (numberInDec != 0)
        {
            int tempValue = numberInDec % 16;
            numberInHex.Add(hexDigits[tempValue]);
            numberInDec /= 16;
        }

        numberInHex.Reverse();

        foreach (char hex in numberInHex)
        {
            Console.Write(hex);
        }

        Console.WriteLine();
    }
}
