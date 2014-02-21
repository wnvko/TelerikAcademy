namespace IsThirdDigitSeven
{
    using System;

    class IsThirdDigitSeven
    {
        static void Main()
        {
            /*
             * Write an expression that checks for given integer if
             * its third digit (right-to-left) is 7. E. g. 1732 -> true.
            */

            Console.Write("Enter an integer: ");
            int number = int.Parse(Console.ReadLine());
            
            string result = ((number % 1000 >= 700) && (number % 1000 < 800)) ? "Yes": "No";
            Console.WriteLine("The third digit of {0} is 7: {1}", number, result);
        }
    }
}
