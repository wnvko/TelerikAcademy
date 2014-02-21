namespace BiggestOutOfFive
{
    using System;

    class BiggestOutOfFive
    {
        static void Main()
        {
            /*
             * Write a program that finds the greatest of given 5 variables.
             */

            double biggestNumber = double.MinValue;
            
            //receives and checks first number
            Console.Write("Enter first number: ");
            double firstNumber = double.Parse(Console.ReadLine());
            if (firstNumber > biggestNumber)
            {
                biggestNumber = firstNumber;
            }

            //receives and checks secondnumber
            Console.Write("Enter second number: ");
            double secondNumber = double.Parse(Console.ReadLine());
            if (secondNumber> biggestNumber)
            {
                biggestNumber = secondNumber;
            }

            //receives and checks thirdnumber
            Console.Write("Enter third number: ");
            double thirdNumber = double.Parse(Console.ReadLine());
            if (thirdNumber> biggestNumber)
            {
                biggestNumber = thirdNumber;
            }

            //receives and checks fourth
            Console.Write("Enter fourth number: ");
            double fourthNumber = double.Parse(Console.ReadLine());
            if (fourthNumber > biggestNumber)
            {
                biggestNumber = fourthNumber;
            }

            //receives and checks fifth
            Console.Write("Enter fifth number: ");
            double fifthNumber = double.Parse(Console.ReadLine());
            if (fifthNumber > biggestNumber)
            {
                biggestNumber = fifthNumber;
            }
            Console.WriteLine("The biggest number is {0}", biggestNumber);
        }
    }
}
