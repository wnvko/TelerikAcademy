namespace BeerTime
{
    using System;
    using System.Globalization;

    public class BeerTime
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter current time [hh:mm tt]: ");
            string input = Console.ReadLine();

            DateTime result;
            bool isCorect = DateTime.TryParseExact(input, "h:mm tt", CultureInfo.CurrentCulture, DateTimeStyles.None, out result);

            if (isCorect)
            {
                if (result.Hour <= 3 || 13 <= result.Hour)
                {
                    Console.WriteLine("beer time");
                }
                else
                {
                    Console.WriteLine("non-beer time");
                }
            }
            else
            {
                Console.WriteLine("invalid time");
            }
        }
    }
}
