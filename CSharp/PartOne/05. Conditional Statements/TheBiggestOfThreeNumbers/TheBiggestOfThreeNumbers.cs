namespace TheBiggestOfThreeNumbers
{
    using System;

    public class TheBiggestOfThreeNumbers
    {
        public static void Main(string[] args)
        {
            double theBiggestNumber = double.MinValue;

            Console.Write("Enter first number: ");
            double firstNumber = double.Parse(Console.ReadLine());
            if (theBiggestNumber < firstNumber)
            {
                theBiggestNumber = firstNumber;
            }

            Console.Write("Enter second number: ");
            double secondNumber = double.Parse(Console.ReadLine());
            if (theBiggestNumber < secondNumber)
            {
                theBiggestNumber = secondNumber;
            }

            Console.Write("Enter third number: ");
            double thirdNumber = double.Parse(Console.ReadLine());
            if (theBiggestNumber < theBiggestNumber)
            {
                theBiggestNumber = thirdNumber;
            }

            Console.WriteLine("The biggest is {0}", theBiggestNumber);
        }
    }
}
