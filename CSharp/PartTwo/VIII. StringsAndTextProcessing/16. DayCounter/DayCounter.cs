/*
 * Write a program that reads two dates in the format:
 * day.month.year and calculates the number of days between them.
 * Example:
 * 
 * Enter the first date: 27.02.2006
 * Enter the second date: 3.03.2004
 * Distance: 4 days
 */

namespace DayCounter
{
    using System;
    using System.Globalization;

    public class DayCounter
    {
        public static string TakeUserInput(string adviseString)
        {
            Console.WriteLine(adviseString);
            string userExpression = Console.ReadLine();
            return userExpression;
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
}