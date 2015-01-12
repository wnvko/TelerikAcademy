namespace NumberComparer
{
    using System;

    public class NumberComparer
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Enter second number: ");
            int b = int.Parse(Console.ReadLine());

            int max = a - ((a - b) & ((a - b) >> 31));
            Console.WriteLine("Greater of two numbers is {0}", max);
        }
    }
}
