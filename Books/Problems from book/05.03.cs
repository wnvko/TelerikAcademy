using System;

namespace BookHomeworks
{
    class Chapter05Problem03
    {
        static void Main(string[] args)
        {
            Console.Write("Въведете първото число: ");
            int firstNumber = int.Parse(Console.ReadLine());
            Console.Write("Въведете второто число: ");
            int secondNumber = int.Parse(Console.ReadLine());
            Console.Write("Въведете третото число: ");
            int thirdNumber = int.Parse(Console.ReadLine());
            int theBiggestOne;
            if (firstNumber > secondNumber)
            {
                if (firstNumber > thirdNumber)
                {
                    theBiggestOne = firstNumber;
                }
                else
                {
                    theBiggestOne = thirdNumber;
                }
            }
            else
            {
                if (secondNumber > thirdNumber)
                {
                    theBiggestOne = secondNumber;
                }
                else
                {
                    theBiggestOne = thirdNumber;
                }
            }
            Console.WriteLine("Най-голямото число е {0}", theBiggestOne);
        }
    }
}