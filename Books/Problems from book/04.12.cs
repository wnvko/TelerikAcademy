using System;

namespace BookHomeworks
{
    class Chapter04Problem12
    {
        static void Main(string[] args)
        {
            double firstNumber = 0;
            double secondNumber = 1;
            Console.WriteLine(firstNumber);
            Console.WriteLine(secondNumber);
            for (int i = 1; i <= 98; i++)
            {
                double fibonachi = firstNumber + secondNumber;
                firstNumber = secondNumber;
                secondNumber = fibonachi;
                Console.WriteLine(fibonachi);
            }
        }
    }
}
