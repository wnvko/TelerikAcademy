namespace TrailingZeroesInNFactorial
{
    using System;

    public class TrailingZeroesInNFactorial
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            int inputNumber = int.Parse(Console.ReadLine());
            int trailingZeros = 0;
            int divider = 5;
            int result = inputNumber;

            while (result != 0)
            {
                trailingZeros += inputNumber / divider;
                result = inputNumber / divider;
                divider *= 5;
            }

            Console.WriteLine(trailingZeros);
        }
    }
}
