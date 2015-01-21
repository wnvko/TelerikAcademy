namespace CalculateGCD
{
    using System;

    public class CalculateGCD
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter first number: ");
            int firstNumber = Math.Abs(int.Parse(Console.ReadLine()));

            Console.Write("Enter second number: ");
            int secondNumber = Math.Abs(int.Parse(Console.ReadLine()));

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

            Console.WriteLine(smallerNumber);
        }
    }
}
