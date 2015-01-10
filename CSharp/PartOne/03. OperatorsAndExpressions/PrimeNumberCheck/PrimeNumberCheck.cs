namespace PrimeNumberCheck
{
    using System;

    public class PrimeNumberCheck
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter a positive number (<100) ");
            int numberToCheck = int.Parse(Console.ReadLine());
            double counter = Math.Sqrt(numberToCheck);
            bool isPrime = true;

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
