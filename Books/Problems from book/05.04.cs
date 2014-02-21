using System;

namespace BookHomeworks
{
    class Chapter05Problem04
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
            int theMidleOne;
            int theSmalestOne;
            if (firstNumber > secondNumber)
            {
                if (firstNumber > thirdNumber)
                {
                    if (secondNumber > thirdNumber)
                    {
                        theBiggestOne = firstNumber;
                        theMidleOne = secondNumber;
                        theSmalestOne = thirdNumber;
                    }
                    else
                    {
                        theBiggestOne = firstNumber;
                        theMidleOne = thirdNumber;
                        theSmalestOne = secondNumber;
                    }
                }
                else
                {
                    theBiggestOne = thirdNumber;
                    theMidleOne = firstNumber;
                    theSmalestOne = secondNumber;
                }
            }
            else
            {
                if (secondNumber > thirdNumber)
                {
                    if (firstNumber > thirdNumber)
                    {
                        theBiggestOne = secondNumber;
                        theMidleOne = firstNumber;
                        theSmalestOne = thirdNumber;
                    }
                    else
                    {
                        theBiggestOne = secondNumber;
                        theMidleOne = thirdNumber;
                        theSmalestOne = firstNumber;
                    }
                }
                else
                {
                    theBiggestOne = thirdNumber;
                    theMidleOne = secondNumber;
                    theSmalestOne = firstNumber;
                }
            }
            Console.WriteLine("Числата от най-голямото до най-малкото са:");
            Console.WriteLine(theBiggestOne);
            Console.WriteLine(theMidleOne);
            Console.WriteLine(theSmalestOne);
        }
    }
}