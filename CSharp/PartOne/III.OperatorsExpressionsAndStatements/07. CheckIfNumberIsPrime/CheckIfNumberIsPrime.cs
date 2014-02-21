namespace CheckIfNumberIsPrime
{
    using System;

    class CheckIfNumberIsPrime
    {
        static void Main()
        {
            /*
             * Write an expression that checks if given positive integer
             * number n (n ≤ 100) is prime. E.g. 37 is prime.
             */

            Console.Write("Enter a possitive number (<100) ");
            int numberToCheck = int.Parse(Console.ReadLine());
            double counter = Math.Sqrt(numberToCheck);
            bool isPrime = true;

            //check if the number is divideable to any number between 2 and square root of number 
            for (int i = 2; i < counter; i++)
            {
                if (numberToCheck % i == 0)
                {
                    isPrime = false;
                    break;
                }
            }
            Console.WriteLine("{0} is prime: {1}", numberToCheck, isPrime);
        }
    }
}
