/*
 * You are given a sequence of positive integer values written into a string, separated by spaces.
 * Write a function that reads these values from given string and calculates their sum.
 */

using System;
using System.Linq;

public class SumIntegers
{
    public static void Main(string[] args)
    {
        Console.Write("Enter some integers separated by intervals: ");
        string inputString = Console.ReadLine();

        int sum = 0;
        char[] separators = new char[] { ' ' };
        string[] numberAsString = inputString.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        sum = numberAsString.Sum(c => int.Parse(c));

        Console.WriteLine("Total sum is {0}", sum);
    }
}
