namespace SortThreeNumbersWithNestedIfs
{
    using System;

    public class SortThreeNumbersWithNestedIfs
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter first number: ");
            double firstNumber = double.Parse(Console.ReadLine());
            Console.Write("Enter second number: ");
            double secondNumber = double.Parse(Console.ReadLine());
            Console.Write("Enter third number: ");
            double thirdNumber = double.Parse(Console.ReadLine());
            double biggestNumber = 0;
            double middleNumber = 0;
            double leastNumber = 0;

            if ((firstNumber > secondNumber) && (firstNumber > thirdNumber))
            {
                biggestNumber = firstNumber;
            }

            if ((secondNumber > firstNumber) && (secondNumber > thirdNumber))
            {
                biggestNumber = secondNumber;
            }

            if ((thirdNumber > firstNumber) && (thirdNumber > secondNumber))
            {
                biggestNumber = thirdNumber;
            }

            if ((firstNumber < secondNumber) && (firstNumber < thirdNumber))
            {
                leastNumber = firstNumber;
            }

            if ((secondNumber < firstNumber) && (secondNumber < thirdNumber))
            {
                leastNumber = secondNumber;
            }

            if ((thirdNumber < firstNumber) && (thirdNumber < secondNumber))
            {
                leastNumber = thirdNumber;
            }

            if ((firstNumber != biggestNumber) && (firstNumber != leastNumber))
            {
                middleNumber = firstNumber;
            }

            if ((secondNumber != biggestNumber) && (secondNumber != leastNumber))
            {
                middleNumber = secondNumber;
            }

            if ((thirdNumber != biggestNumber) && (thirdNumber != leastNumber))
            {
                middleNumber = thirdNumber;
            }

            Console.WriteLine(biggestNumber + " " + middleNumber + " " + leastNumber);
        }
    }
}
