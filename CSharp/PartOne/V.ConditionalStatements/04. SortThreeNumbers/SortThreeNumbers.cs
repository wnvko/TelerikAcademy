namespace SortThreeNumbers
{
    using System;


    class SortThreeNumbers
    {
        static void Main()
        {
            /*
             * Sort 3 real values in descending order using nested if statements.
             */

            Console.Write("Enter first number: ");
            double firstNumber = double.Parse(Console.ReadLine());
            Console.Write("Enter second number: ");
            double secondNumber = double.Parse(Console.ReadLine());
            Console.Write("Enter third number: ");
            double thirdNumber = double.Parse(Console.ReadLine());
            double biggestNumber = 0;
            double middleNumber = 0;
            double leastNumber = 0;
            
            //finds the biggest number
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

            //finds the least number
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
            
            //finds the middle number
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
            Console.WriteLine("The biggest number is {0}", biggestNumber);
            Console.WriteLine("The middle number is {0}", middleNumber);
            Console.WriteLine("The least number is {0}", leastNumber);
        }
    }
}
