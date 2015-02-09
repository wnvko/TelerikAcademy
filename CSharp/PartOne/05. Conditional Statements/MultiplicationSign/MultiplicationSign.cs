namespace MultiplicationSign
{
    using System;

    public class MultiplicationSign
    {
        public static void Main(string[] args)
        {
            int minusCount = 0;
            bool isZero = false;

            Console.Write("Enter first number: ");
            int firstNumber = int.Parse(Console.ReadLine());
            CheckNumber(ref minusCount, ref isZero, firstNumber);

            Console.Write("Enter second number: ");
            int secondNumber = int.Parse(Console.ReadLine());
            CheckNumber(ref minusCount, ref isZero, secondNumber);

            Console.Write("Enter third number: ");
            int thirdNumber = int.Parse(Console.ReadLine());
            CheckNumber(ref minusCount, ref isZero, thirdNumber);

            if (isZero)
            {
                Console.WriteLine(0);
                return;
            }

            if (minusCount % 2 == 0)
            {
                Console.WriteLine("+");
            }
            else
            {
                Console.WriteLine("-");
            }
        }

        private static void CheckNumber(ref int minusCount, ref bool isZero, int theNumber)
        {
            if (theNumber < 0)
            {
                minusCount++;
            }

            if (theNumber == 0)
            {
                isZero = true;
            }
        }
    }
}
