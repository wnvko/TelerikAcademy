/*
 * Write a program that extracts from a given text all dates that match the format DD.MM.YYYY.
 * Display them in the standard date format for Canada.
 */

using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading;

public class DatesFromTextInCanada
{
    public static void Main()
    {
        Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-CA", false);
        string textToCheck = "There are some dates in text like 10.12.2013, or even 15.03.1815 and some in future - 22.01.2150!";

        string dateFormat = "dd.MM.yyyy";

        Console.WriteLine(textToCheck);
        Console.WriteLine("\nAll the dates in text are: \n");

        Regex dateFinder = new Regex(@"[\d+]{2}\.[\d+]{2}\.[\d+]{4}");
        foreach (Match date in dateFinder.Matches(textToCheck))
        {
            DateTime someDate = DateTime.ParseExact(date.ToString(), dateFormat, new CultureInfo("fr-CA"));
            Console.WriteLine("{0}.{1}.{2}", someDate.Day, someDate.Month, someDate.Year);
        }
    }
}
