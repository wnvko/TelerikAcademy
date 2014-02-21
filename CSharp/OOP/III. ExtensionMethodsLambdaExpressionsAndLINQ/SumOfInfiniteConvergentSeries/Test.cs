/*
 * By using delegates develop an universal static method to calculate the sum of infinite
 * convergent series with given precision depending on a function of its term. By using proper
 * functions for the term calculate with a 2-digit precision the sum of the infinite series:
 *      1 + 1/2 + 1/4 + 1/8 + 1/16 + …
 *      1 + 1/2! + 1/3! + 1/4! + 1/5! + …
 *      1 + 1/2 - 1/4 + 1/8 - 1/16 + … 
 */

namespace SumOfInfiniteConvergentSeries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class Test
    {
        static void Main()
        {
            // sum of 1 + 1/2 + 1/4 + 1/8 + 1/16 + …
            // start = 1; step = 2
            double firstSum = Sum.CalculateSum(1, 2, false,0, (x, y) => Sum.NextMember(x, y));
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