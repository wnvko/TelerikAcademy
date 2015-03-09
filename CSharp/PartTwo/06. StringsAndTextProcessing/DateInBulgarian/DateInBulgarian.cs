/*
 * Write a program that reads a date and time given in the format: day.month.year hour:minute:second
 * and prints the date and time after 6 hours and 30 minutes (in the same format) along with the day
 * of week in Bulgarian.
 */

using System;
using System.Globalization;

public class DateInBulgarian
{
    public static void Main()
    {
        string dateAsString = TakeUserInput("Enter a date (dd.mm.yyyy hh:mm:ss):");
        string dateFormat = "dd.MM.yyyy HH:mm:ss";
        DateTime date = DateTime.ParseExact(dateAsString, dateFormat, CultureInfo.InvariantCulture);

        DateTime dateAfterOffset = date.AddHours(6.5);
        string newDate = dateAfterOffset.ToString(dateFormat);
        string dayOfWeek = dateAfterOffset.ToString("dddd", new CultureInfo("bg-BG"));
        Console.WriteLine("Time after 06:30 hours will be {0}, {1}", newDate, dayOfWeek);
    }

    private static string TakeUserInput(string adviseString)
    {
        Console.Write(adviseString);
        string input = Console.ReadLine();
        return input;
    }
}
