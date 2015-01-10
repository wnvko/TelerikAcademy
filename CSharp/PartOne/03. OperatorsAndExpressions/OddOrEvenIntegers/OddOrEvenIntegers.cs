namespace OddOrEvenIntegers
{
    using System;

    public class OddOrEvenIntegers
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter an integer: ");
            int number = int.Parse(Console.ReadLine());
            string result = number % 2 == 0 ? "even" : "odd";
            Console.WriteLine("{0} is {1}", number, result);
        }
    }
}
