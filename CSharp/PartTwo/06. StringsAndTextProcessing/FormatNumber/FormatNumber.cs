﻿/*
 * Write a program that reads a number and prints it as a decimal number, hexadecimal number,
 * percentage and in scientific notation.
 * Format the output aligned right in 15 symbols.
 */

using System;

public class FormatNumber
{
    public static void Main()
    {
        string userInput = TakeUserInput("Entet an integer:");
        int userNumber = int.Parse(userInput);

        Console.WriteLine("{0,15:F2}", userNumber);
        Console.WriteLine("{0,15:X}", userNumber);
        Console.WriteLine("{0,15:P2}", userNumber);
        Console.WriteLine("{0,15:E2}", userNumber);
    }

    public static string TakeUserInput(string adviseString)
    {
        Console.WriteLine(adviseString);
        string input = Console.ReadLine();
        return input;
    }
}
