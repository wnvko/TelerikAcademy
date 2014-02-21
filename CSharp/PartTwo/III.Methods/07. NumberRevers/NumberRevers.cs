/*
 * Write a method that reverses the digits of given decimal number.
 * Example: 256 -> 652.
 */

namespace NumberRevers
{
    using System;
    class NumberRevers
    {
        static int ReverseInteger(int inputNumber)
        {
            int reversedNumber = 0;
            while (inputNumber != 0)
            {
                reversedNumber = reversedNumber * 10 + inputNumber % 10;
                inputNumber = inputNumber / 10;
            }
            return reversedNumber;
        }
        static void Main()
        {
            Console.Write("Enter an integer: ");
            int numberToReverse = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine(new string('-', 30));
            
            int reversedNumber = ReverseInteger(numberToReverse);
            Console.WriteLine("\nReversed integer is {0}", reversedNumber);
        }
    }
}
