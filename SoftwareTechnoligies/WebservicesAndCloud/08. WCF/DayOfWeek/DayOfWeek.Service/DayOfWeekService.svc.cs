namespace DayOfWeek.Service
{
    using System;
    using System.Globalization;

    public class DayOfWeekService : IDayOfWeekService
    {
        public string GetDateDayOfWeek(DateTime date)
        {
            string dayOfWeek = date.ToString("dddd", new CultureInfo("bg-BG"));
            return dayOfWeek;
        }
    }
}
