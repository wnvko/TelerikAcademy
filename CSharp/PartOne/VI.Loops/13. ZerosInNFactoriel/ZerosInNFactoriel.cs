namespace ZerosInNFactoriel
{
    using System;

    class ZerosInNFactoriel
    {
        static void Main()
        {
            /*
             * * Write a program that calculates for given N how many trailing
             * zeros present at the end of the number N!. Examples:
             * N = 10 -> N! = 3628800 -> 2
             * N = 20 -> N! = 2432902008176640000 -> 4
             * Does your program work for N = 50 000?
             * Hint: The trailing zeros in N! are equal to the number of its prime
             * divisors of value 5. Think why!
             */
            
            Console.Write("Enter a number: ");
            int inputNumber = int.Parse(Console.ReadLine());

            int fiveCount = inputNumber / 5;
            int trailingZeros = fiveCount;

            Console.WriteLine("{0}! has {1} trailing zeros!", inputNumber, trailingZeros);
        }
    }
}
