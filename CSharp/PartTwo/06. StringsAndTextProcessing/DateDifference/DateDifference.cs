/*
 * Write a program that reads two dates in the format: day.month.year and calculates the number of
 * days between them.
 */

using System;
using System.Globalization;

public class DateDifference
{
    public static string TakeUserInput(string adviseString)
    {
        Console.Write(adviseString);
        string input = Console.ReadLine();
        return input;
    }

    public static void Main()
    {
        string firstDate = TakeUserInput("Enter first date (dd.mm.yyyy):");
        string secondDate = TakeUserInput("Enter second date (dd.mm.yyyy):");

        string dateFormat = "dd.MM.yyyy";

        DateTime first = DateTime.ParseExact(firstDate, dateFormat, CultureInfo.InvariantCulture);
        DateTime second = DateTime.ParseExact(secondDate, dateFormat, CultureInfo.InvariantCulture);

        int offset = (second - first).Days;
        Console.WriteLine("There are {0} days between {1} and {2}", offset, firstDate, secondDate);
    }
}
