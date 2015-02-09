namespace ExchangeIfGreater
{
    using System;

    public class ExchangeIfGreater
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter first number: ");
            int firstNumber = int.Parse(Console.ReadLine());

            Console.Write("Enter second number: ");
            int secondNumber = int.Parse(Console.ReadLine());

            if (firstNumber > secondNumber)
            {
                int buffer = secondNumber;
                secondNumber = firstNumber;
                firstNumber = buffer;
            }

            Console.WriteLine(firstNumber + " " + secondNumber);
        }
    }
}
