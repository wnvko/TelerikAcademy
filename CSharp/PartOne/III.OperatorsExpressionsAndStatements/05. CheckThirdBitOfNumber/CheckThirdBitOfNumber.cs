namespace CheckThirdBitOfNumber
{
    using System;

    class CheckThirdBitOfNumber
    {
        static void Main()
        {
            /*
             * Write a boolean expression for finding if the bit 3
             * (counting from 0) of a given integer is 1 or 0.
            */

            Console.Write("Enter an integer: ");
            int number = int.Parse(Console.ReadLine());
            int mask = 1;
            mask <<= 3;
            int numberWithMask = number & mask;
            numberWithMask >>= 3;
            bool result = (numberWithMask == 1 ? true : false);
            Console.WriteLine("The third digit (starting from 0) of {0} is 1: {1}", number, result);
        }
    }
}
