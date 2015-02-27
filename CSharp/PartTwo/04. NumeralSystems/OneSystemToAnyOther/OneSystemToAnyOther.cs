/*
 * Write a program to convert from any numeral system of given base s to any other numeral system
 * of base d (2 ≤ s, d ≤ 16).
 */

using System;
using System.Collections.Generic;
using System.Linq;

public class OneSystemToAnyOther
{
    private static Dictionary<char, int> decDigits = new Dictionary<char, int>(){
        { '0', 0 },
        { '1', 1 },
        { '2', 2 },
        { '3', 3 },
        { '4', 4 },
        { '5', 5 },
        { '6', 6 },
        { '7', 7 },
        { '8', 8 },
        { '9', 9 },
        { 'A', 10 },
        { 'B', 11 },
        { 'C', 12 },
        { 'D', 13 },
        { 'E', 14 },
        { 'F', 15 },
    };
    private static List<char> othDigits = new List<char>() { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };

    public static void Main()
    {
        Console.Write("Enter the numeral base of the number to convert: ");
        int numberBase = int.Parse(Console.ReadLine());
        Console.Write("Enter the number in {0} base: ", numberBase);
        string numberToConvert = Console.ReadLine();
        Console.Write("Enter the numeral base to convert to: ");
        int newBase = int.Parse(Console.ReadLine());

        string convertedNumber = ConvertFromDec(ConvertToDec(numberToConvert, numberBase), newBase);

        Console.WriteLine("\n{0} base {1} is {2} base {3}", numberToConvert, numberBase, convertedNumber, newBase);
    }

    private static int ConvertToDec(string inputNumber, int numberBase)
    {
        int decNumber = 0;
        for (int index = inputNumber.Length - 1; index >= 0; index--)
        {
            int power = inputNumber.Length - index - 1;
            int inputNumberBase = decDigits[inputNumber[index]];
            decNumber += inputNumberBase * (int)Math.Pow(numberBase, power);
        }

        return decNumber;
    }

    private static string ConvertFromDec(int inputNumber, int numberBase)
    {
        List<char> convertedNumber = new List<char>();

        while (inputNumber != 0)
        {
            convertedNumber.Add(othDigits[inputNumber % numberBase]);
            inputNumber /= numberBase;
        }

        string result = string.Join(string.Empty, convertedNumber.ToArray().Reverse());
        return result;
    }
}