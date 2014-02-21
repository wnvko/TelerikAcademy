using System;

namespace ConsoleApplication
{
    class Chapter06Problem03
    {
        static void Main(string[] args)
        {
            Console.Write("Въведете броя на числата: ");
            int n = int.Parse(Console.ReadLine());
            int max = int.MinValue;
            int min = int.MaxValue;
            for (int i = 1; i <= n; i++)
            {
                Console.Write("Въведете число №{0}: ", i);
                int currentNumber = int.Parse(Console.ReadLine());
                if (currentNumber > max)
                {
                    max = currentNumber;
                }
                if (currentNumber < min)
                {
                    min = currentNumber;
                }
            } 
            Console.WriteLine("Най-голямото число е {0}", max);
            Console.WriteLine("Най-малкото число е {0}", min);
        }
    }
}
