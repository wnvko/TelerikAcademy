using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            int dateDay = int.Parse(Console.ReadLine());
            int dateMonth = int.Parse(Console.ReadLine());
            int dateYear = int.Parse(Console.ReadLine());

            DateTime result = new DateTime(dateYear, dateMonth, dateDay).AddDays(1);
            Console.WriteLine("{0:F0}.{1:F0}.{2:F0}", result.Day,result.Month,result.Year);
        }
    }
}
