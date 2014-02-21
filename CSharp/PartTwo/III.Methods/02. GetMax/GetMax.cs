/*Write a method GetMax() with two parameters that returns the bigger of two integers.
 * Write a program that reads 3 integers from the console and prints
 * the biggest of them using the method GetMax().
 */

namespace GetMax
{
    using System;
    class GetMax
    {
        static int GetMaxNumber(int firstNumber, int secondNumber)
        {
            int result = firstNumber;
            if (secondNumber > firstNumber)
            {
                result = secondNumber;
            }
            return result;
        }
        static void Main()
        {
            Console.WriteLine("Enter three integers:");
            Console.Write("First: ");
            int first = int.Parse(Console.ReadLine());
            Console.Write("Second: ");
            int second = int.Parse(Console.ReadLine());
            Console.Write("Third: ");
            int third = int.Parse(Console.ReadLine());

            int biggestNumber = GetMaxNumber(first, second);
            biggestNumber = GetMaxNumber(biggestNumber, third);

            Console.WriteLine("\nThe biggest number is {0}", biggestNumber);
        }
    }
}
