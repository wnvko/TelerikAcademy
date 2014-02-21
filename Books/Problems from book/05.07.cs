using System;

namespace BookHomeworks
{
    class Chapter05Problem07
    {
        static void Main(string[] args)
        {
            Console.Write("Въведете първото число: ");
            int firstNumber = int.Parse(Console.ReadLine());
            int max = firstNumber;
            Console.Write("Въведете второто число: ");
            int secondNumber = int.Parse(Console.ReadLine());
            max = (max > secondNumber ? max : secondNumber);
            Console.Write("Въведете третото число: ");
            int thirdNumber = int.Parse(Console.ReadLine());
            max = (max > thirdNumber ? max : thirdNumber);
            Console.Write("Въведете четвъртото число: ");
            int fourthNumber = int.Parse(Console.ReadLine());
            max = (max > fourthNumber ? max : fourthNumber);
            Console.Write("Въведете петото число: ");
            int fifthNumber = int.Parse(Console.ReadLine());
            max = (max > fifthNumber ? max : fifthNumber);
            Console.WriteLine("\nНай-голямото число е {0}", max);
        }
    }
}