namespace DayOfWeek.ConsoleClient
{
    using System;
    using System.Text;
    using DayOfWeekService.Proxy;

    public class DayOfWeekConsoleClient
    {
        static void Main(string[] args)
        {
            var dayOfWeek = string.Empty;
            using (var client = new DayOfWeekServiceClient())
            {
                dayOfWeek = client.GetDateDayOfWeek(DateTime.Today);
            }

            // Change the encoding of the console in order to show Cyrillic letters 
            var currentEncoding = Console.OutputEncoding;
            Console.OutputEncoding = Encoding.Unicode;

            Console.WriteLine(dayOfWeek);

            // Restore the console encoding as it was
            Console.OutputEncoding = currentEncoding;
        }
    }
}
