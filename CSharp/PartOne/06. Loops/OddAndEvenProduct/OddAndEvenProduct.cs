namespace OddAndEvenProduct
{
    using System;

    public class OddAndEvenProduct
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter the numbers ");
            string[] numbers = Console.ReadLine().Split(' ');

            int oddProduct = 1;
            int evenProduct = 1;

            for (int number = 0; number < numbers.Length; number++)
            {
                int curentNumber = int.Parse(numbers[number]);
                if (number % 2 == 0)
                {
                    evenProduct *= curentNumber;
                }
                else
                {
                    oddProduct *= curentNumber;
                }
            }

            if (oddProduct == evenProduct)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
