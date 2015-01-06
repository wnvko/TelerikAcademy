namespace TelerikAcademyExam2013._12._27
{
    using System;
    using System.Globalization;
    using System.Threading;

    class PrintNexDay
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            int dateDay = int.Parse(Console.ReadLine());
            int dateMonth = int.Parse(Console.ReadLine());
            int dateYear = int.Parse(Console.ReadLine());
            
            string dateAsString = "" + dateMonth + "." + dateDay + "." + dateYear;
            DateTime inputDate = Convert.ToDateTime(dateAsString);
            DateTime nextDay = inputDate.AddDays(1);
            Console.WriteLine("{0:F0}.{1:F0}.{2:F0}", nextDay.Day, nextDay.Month, nextDay.Year);
        }
    }
}