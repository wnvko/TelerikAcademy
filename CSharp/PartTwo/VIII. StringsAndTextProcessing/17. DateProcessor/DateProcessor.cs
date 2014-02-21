/*
 * Write a program that reads a date and time given in the
 * format: day.month.year hour:minute:second and prints the
 * date and time after 6 hours and 30 minutes (in the same
 * format) along with the day of week in Bulgarian.
 */

namespace DateProcessor
{
    using System;
    using System.Globalization;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    public class DateProcessor
    {
        public static string TakeUserInput(string adviseString)
        {
            Console.WriteLine(adviseString);
            string userExpression = Console.ReadLine();
            return userExpression;
        }

        public static void Main()
        {
            string dateAsString = TakeUserInput("Enter a date (dd.mm.yyyy hh:mm:ss):");
            string dateFormat = "dd.MM.yyyy HH:mm:ss";
            DateTime date = DateTime.ParseExact(dateAsString, dateFormat, CultureInfo.InvariantCulture);
            DateTime offset = date.AddHours(6.5);
            Thread.CurrentThread.CurrentCulture = new CultureInfo("bg-BG", false);
            Console.WriteLine("Time after 06:30 hours will be {0}, {1}", offset, offset.DayOfWeek);
        }
    }
}
