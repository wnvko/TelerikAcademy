namespace NumbersFromOneToN
{
    using System;

    public class NumbersFromOneToN
    {
        public static void Main(string[] args)
        {
            Console.Write("Please enter a number: ");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("{0}", (i + 1));
            }
        }
    }
}
