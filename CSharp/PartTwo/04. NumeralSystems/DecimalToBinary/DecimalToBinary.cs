/*
 * Write a program to convert decimal numbers to their binary representation.
 */

using System;
using System.Collections.Generic;

public class DecimalToBinary
{
    public static void Main(string[] args)
    {
        Console.Write("Enter an integer: ");
        int numberInDec = int.Parse(Console.ReadLine());
        Console.WriteLine("\n{0} in binary is:", numberInDec);

        List<int> numberInBin = new List<int>();
        while (numberInDec != 0)
        {
            int theValue = numberInDec % 2;
            numberInBin.Add(theValue);
            numberInDec /= 2;
        }

        numberInBin.Reverse();

        foreach (var binary in numberInBin)
        {
            Console.Write(binary);
        }

        Console.WriteLine();
    }
}
