namespace InfiniteConvergentSeries
{
    using System;

    public class TestInfiniteConvergentSeries
    {
        public static void Main(string[] args)
        {
            // sum of 1 + 1/2 + 1/4 + 1/8 + 1/16 + …
            // start = 1; step = 2
            double firstSum = Sum.CalculateSum(1, 2, false, 0, (x, y) => Sum.NextMember(x, y));
            Console.WriteLine(firstSum);

            // sum of 1 + 1/2! + 1/3! + 1/4! + 1/5! + …
            double secondSum = Sum.CalculateSum(1, 2, false, 1, (x, y) => Sum.NextMember(x, y));
            Console.WriteLine(secondSum);

            // sum of 1 + 1/2 - 1/4 + 1/8 - 1/16 + … 
            double thirdSum = Sum.CalculateSum(1, 2, true, 0, (x, y) => Sum.NextMember(x, y));
            Console.WriteLine(thirdSum);
        }
    }
}
