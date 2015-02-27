/*
 * Write a method that reverses the digits of given decimal number.
 */

using System;
using System.Linq;

public class ReverseNumber
{
    public static void Main(string[] args)
    {
        var myClass = new ReverseNumber();

        Console.Write("Enter an integer: ");
        decimal numberToReverse = decimal.Parse(Console.ReadLine());
        Console.WriteLine();
        Console.WriteLine(new string('-', 30));

        decimal reversedNumber = myClass.ReverseInteger(numberToReverse);
        Console.WriteLine("\nReversed integer is {0}", reversedNumber);
    }

    private decimal ReverseInteger(decimal inputNumber)
    {
        string numberAsString = inputNumber.ToString();
        string reversedNumberAsString = new string(numberAsString.Reverse().ToArray());
        decimal reversedNumber = decimal.Parse(reversedNumberAsString);

        return reversedNumber;
    }
}