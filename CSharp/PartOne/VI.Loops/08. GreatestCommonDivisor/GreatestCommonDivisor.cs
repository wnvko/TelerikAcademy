namespace GreatestCommonDivisor
{
    using System;

    class GreatestCommonDivisor
    {
        static void Main()
        {
            /*
             * Write a program that calculates the greatest common divisor (GCD)
             * of given two numbers. Use the Euclidean algorithm (find it in Internet).
             */
            
            Console.Write("Enter first number: ");
            int firstNumber = int.Parse(Console.ReadLine());
            Console.Write("Enter second number: ");
            int secondNumber = int.Parse(Console.ReadLine());

            //initialize two variables to safe the numbers
            int biggerNumber = 0;
            int smallerNumber = 0;

            if (firstNumber > secondNumber)
            {
                biggerNumber = firstNumber;
                smallerNumber = secondNumber;
            }
            else
            {
                biggerNumber = secondNumber;
                smallerNumber = firstNumber;
            }

            int buffer = 0;

            //apply Euclidean algorithm
            while (biggerNumber >= smallerNumber)
            {
                biggerNumber -= smallerNumber;

                if (biggerNumber == 0)
                {
                    break;
                }

                if (biggerNumber < smallerNumber)
                {
                    buffer = biggerNumber;
                    biggerNumber = smallerNumber;
                    smallerNumber = buffer;
                }
            }
            Console.WriteLine("The graetest common divisor of {0} and {1} is {2}", firstNumber, secondNumber, smallerNumber);
        }
    }
}
