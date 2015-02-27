/*
 * Write a program to convert hexadecimal numbers to their decimal representation.
 */

using System;

public class HexadecimalToDecimal
{
    public static void Main(string[] args)
    {
        Console.Write("Enter a hexadecimal number: ");
        string hexNumber = Console.ReadLine().ToUpper();
        int decNumber = 0;
        for (int index = hexNumber.Length - 1; index >= 0; index--)
        {
            int power = hexNumber.Length - index - 1;
            int hexNumberBase = GetBase(hexNumber, index);
            decNumber += hexNumberBase * (int)Math.Pow(16, power);
        }

        Console.WriteLine("\nHexadecimal {0} is decimal {1}", hexNumber, decNumber);
    }

    private static int GetBase(string hexNumber, int index)
    {
        int hexNumberBase = 0;
        switch (hexNumber[index])
        {
            case 'A':
                hexNumberBase = 10;
                break;
            case 'B':
                hexNumberBase = 11;
                break;
            case 'C':
                hexNumberBase = 12;
                break;
            case 'D':
                hexNumberBase = 13;
                break;
            case 'E':
                hexNumberBase = 14;
                break;
            case 'F':
                hexNumberBase = 15;
                break;
            default:
                hexNumberBase = int.Parse(hexNumber[index].ToString());
                break;
        }

        return hexNumberBase;
    }
}
