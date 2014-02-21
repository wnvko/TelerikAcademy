using System;

namespace ConsoleApplication
{
    class Chapter06Problem17
    {
        static void Main(string[] args)
        {
            Console.Write("Въведете първото число: ");
            int firstNumber= int.Parse(Console.ReadLine());
            Console.Write("Въведете второто число: ");
            int secondNumber = int.Parse(Console.ReadLine());
            int greatestCommonDivider = 0;
            int buffer = 1;
            if (secondNumber > firstNumber)
            {
                buffer= firstNumber;
                firstNumber = secondNumber;
                secondNumber = buffer;
            }
            Console.Write("Най-голямото общо кратно на {0} и {1} е ", firstNumber, secondNumber);
            if (firstNumber % secondNumber == 0)
            {
                greatestCommonDivider = secondNumber;
            }
            else
            {
                while (buffer != 0)
                {
                    greatestCommonDivider = buffer;
                    buffer = firstNumber % secondNumber;
                    firstNumber = secondNumber;
                    secondNumber = buffer;
                }
            }
            Console.WriteLine(greatestCommonDivider);
        }
    }
}