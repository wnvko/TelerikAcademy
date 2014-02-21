namespace InfiniteSeriesSum
{
    using System;

    class InfiniteSeriesSum
    {
        static void Main()
        {
            /*
             * Write a program to calculate the sum (with accuracy of 0.001): 1 + 1/2 - 1/3 + 1/4 - 1/5 + ...
             */

            double sumOfSeries = 1;
            double buffer = 0;
            int i = 1;
            while (true)
            {
                i++;
                buffer = sumOfSeries;
                sumOfSeries = sumOfSeries + (Math.Pow(-1.0,i) / i);
                Console.WriteLine(i);
                if (Math.Abs(sumOfSeries - buffer) < 0.001)
                {
                    Console.WriteLine("The sum is {0:F3}",sumOfSeries);
                    break;
                }
            }
        }
    }
}
