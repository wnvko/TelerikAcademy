namespace GreaterOutOfTwo
{
    using System;

    class GreaterOutOfTwo
    {
        static void Main()
        {
            /*
             * Write an if statement that examines two integer variables
             * and exchanges their values if the first one is greater than the second one.
             */

            Console.Write("Enter first number: ");
            int firstNumber = int.Parse(Console.ReadLine());
            Console.Write("Enter second number: ");
            int secondNumber = int.Parse(Console.ReadLine());
            if (firstNumber > secondNumber)
            {
                int buffer = secondNumber;
                secondNumber = firstNumber;
                firstNumber = buffer;
                Console.WriteLine("First number is greater than second number");
                Console.WriteLine("First number - {0}", firstNumber);
                Console.WriteLine("Second number = {0}", secondNumber);
            }
            else
            {
                Console.WriteLine("First number is not greater than second number");
                Console.WriteLine("First number - {0}", firstNumber);
                Console.WriteLine("Second number = {0}", secondNumber);
            }
        }
    }
}