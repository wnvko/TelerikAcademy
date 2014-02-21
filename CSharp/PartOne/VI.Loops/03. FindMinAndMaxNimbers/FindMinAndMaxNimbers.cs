namespace FindMinAndMaxNimbers
{
    using System;

    class FindMinAndMaxNimbers
    {
        static void Main()
        {
            /*
             * Write a program that reads from the console a sequence
             * of N integer numbers and returns the minimal and maximal of them.
             */
            
            Console.Write("Enter the count of numbers: ");
            int countOfNumbers = int.Parse(Console.ReadLine());

            int maxNumber = int.MinValue;
            int minNumber = int.MaxValue;
                
            for (int i = 0; i < countOfNumbers; i++)
            {
                Console.Write("Enter number {0}: ", i+1);
                int currentNumber = int.Parse(Console.ReadLine());
                if (currentNumber > maxNumber)
                {
                    maxNumber = currentNumber;
                }
                if (currentNumber < minNumber)
                {
                    minNumber = currentNumber;
                }
            }
            Console.WriteLine("max nuber is {0}", maxNumber);
            Console.WriteLine("min nuber is {0}", minNumber);
        }
    }
}
