namespace OddOrEven
{
    using System;

    class OddOrEven
    {
        static void Main()
        {
            /*
             * Write an expression that checks if given integer is odd or even.
             */ 

            Console.Write("Enter an integer: ");
            int number = int.Parse(Console.ReadLine());
            string result = (number % 2 == 0 ? "even" : "odd");
            Console.WriteLine("{0} is {1}", number, result);
        }
    }
}
