namespace TheBiggestOfFiveNumbers
{
    using System;

    public class TheBiggestOfFiveNumbers
    {
        public static void Main(string[] args)
        {
            double biggestNumber = double.MinValue;

            Console.Write("Enter first number: ");
            double firstNumber = double.Parse(Console.ReadLine());
            biggestNumber = CheckNumber(biggestNumber, firstNumber);

            Console.Write("Enter second number: ");
            double secondNumber = double.Parse(Console.ReadLine());
            biggestNumber = CheckNumber(biggestNumber, secondNumber); 

            Console.Write("Enter third number: ");
            double thirdNumber = double.Parse(Console.ReadLine());
            biggestNumber = CheckNumber(biggestNumber, thirdNumber); 

            Console.Write("Enter fourth number: ");
            double fourthNumber = double.Parse(Console.ReadLine());
            biggestNumber = CheckNumber(biggestNumber, fourthNumber); 

            Console.Write("Enter fifth number: ");
            double fifthNumber = double.Parse(Console.ReadLine());
            biggestNumber = CheckNumber(biggestNumber, fifthNumber); 

            Console.WriteLine("The biggest number is {0}", biggestNumber);
        }

        private static double CheckNumber(double biggestNuberNow, double numberToCheck)
        {
            if (numberToCheck > biggestNuberNow)
            {
                biggestNuberNow = numberToCheck;
            }

            return biggestNuberNow;
        }
    }
}
