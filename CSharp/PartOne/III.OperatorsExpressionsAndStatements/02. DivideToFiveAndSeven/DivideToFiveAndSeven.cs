namespace DivideToFiveAndSeven
{
    using System;

    class DivideToFiveAndSeven
    {
        static void Main()
        {
            /*
             * Write a boolean expression that checks for given integer
             * if it can be divided (without remainder) by 7 and 5 in the same time.
             */

            Console.Write("Enter an integer:");
            int number = int.Parse(Console.ReadLine());
            string result = ((number % 7 == 0) && (number % 5 == 0) ? "Yes" : "No");
            Console.WriteLine("{0} can be divided to 7 and 5 without reminder: {1}", number, result);
        }
    }
}
