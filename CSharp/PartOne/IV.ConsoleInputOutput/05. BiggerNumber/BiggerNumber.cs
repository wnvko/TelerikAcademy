namespace BiggerNumber
{
    using System;

    class BiggerNumber
    {
        static void Main()
        {
            /*
             * Write a program that gets two numbers from the console
             * and prints the greater of them. Don’t use if statements.
             */
            
            Console.Write("Enter a number: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Enter second number: ");
            int b = int.Parse(Console.ReadLine());

            //if a>b (a-b)>>31 = 0 and (a-b) & 0 = 0
            //if a<b (a-b)>>31 = -1 and (a-b) & -1 = a-b
            int max = a - ((a - b) & ((a - b) >> 31));
            Console.WriteLine("Greater of two numbers is {0}", max);
        }
    }
}
