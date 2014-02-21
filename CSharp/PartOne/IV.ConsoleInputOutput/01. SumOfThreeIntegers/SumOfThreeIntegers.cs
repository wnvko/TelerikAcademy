namespace SumOfThreeIntegers
{
    using System;

    class SumOfThreeIntegers
    {
        static void Main()
        {
            /*
             * Write a program that reads 3 integer numbers from the console and prints their sum.
             */
            
            Console.WriteLine("Please enter three integers.");
            Console.Write("a = ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("b = ");
            int b = int.Parse(Console.ReadLine());
            Console.Write("c = ");
            int c = int.Parse(Console.ReadLine());
            Console.WriteLine("{0} + {1} + {2} = {3}", a, b, c, (a + b + c));
        }
    }
}
