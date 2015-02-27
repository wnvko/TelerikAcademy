/*
 * Write a program to convert hexadecimal numbers to binary numbers (directly).
 */

using System;
using System.Collections.Generic;

public class HexadecimalToBinary
{
    private static Dictionary<char, string> hexDigits = new Dictionary<char, string>(){
        {'0',"0000"},
        {'1',"0001"},
        {'2',"0010"},
        {'3',"0011"},
        {'4',"0100"},
        {'5',"0101"},
        {'6',"0110"},
        {'7',"0111"},
        {'8',"1000"},
        {'9',"1001"},
        {'A',"1010"},
        {'B',"1011"},
        {'C',"1100"},
        {'D',"1101"},
        {'E',"1110"},
        {'F',"1111"},
    };

    public static void Main(string[] args)
    {
        Console.Write("Enter a hexadecimal number: ");
        string hexNumber = Console.ReadLine().ToUpper();

        string binNumber = "";
        foreach (var number in hexNumber)
        {
            
            binNumber = binNumber + hexDigits[number];
        }

        Console.WriteLine("\nHexadecimal {0} is decimal {1}", hexNumber, binNumber);
    }
}