namespace BiggestOutOfThree
{
    using System;

    class BiggestOutOfThree
    {
        static void Main()
        {
            /*
             * Write a program that finds the biggest of three
             * integers using nested if statements.
             */
            
            Console.Write("Enter first number: ");
            int firstNumber = int.Parse(Console.ReadLine());
            Console.Write("Enter second number: ");
            int secondNumber = int.Parse(Console.ReadLine());
            Console.Write("Enter third number: ");
            int thirdNumber = int.Parse(Console.ReadLine());
            if (firstNumber > secondNumber)
            {
                if (firstNumber > thirdNumber)
                {
                    Console.WriteLine("The bigest is {0}", firstNumber);
                }
                else
                {
                    if (secondNumber > thirdNumber)
                    {
                        Console.WriteLine("The bigest is {0}", secondNumber);
                    }
                    else
                    {
                        Console.WriteLine("The bigest is {0}", thirdNumber);
                    }
                }
            }
            else
            {
                if (secondNumber > thirdNumber)
                {
                    Console.WriteLine("The bigest is {0}", secondNumber);
                }
                else
                {
                    Console.WriteLine("The bigest is {0}", thirdNumber);
                }
            }
        }
    }
}