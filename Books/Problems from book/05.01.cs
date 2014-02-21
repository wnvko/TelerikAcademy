using System;

namespace BookHomeworks
{
    class Chapter05Problem01
    {
        static void Main(string[] args)
        {
            Console.Write("Въведете първото число: ");
            int firstNumber = int.Parse(Console.ReadLine());
            Console.Write("Въведете второто число: ");
            int secondNumber = int.Parse(Console.ReadLine());
            int theBigOne;
            if (firstNumber > secondNumber)
            {
                theBigOne = firstNumber;
                firstNumber = secondNumber;
                secondNumber = theBigOne;
            }
            Console.WriteLine("По-голямото число е {0}", secondNumber);
        }
    }
}