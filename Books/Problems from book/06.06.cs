using System;

namespace ConsoleApplication
{
    class Chapter06Problem06
    {
        static void Main(string[] args)
        {
            Console.Write("Въведете броя на числата: ");
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            int fibonachiN = 1;
            int fibonachiNminusOne = 0;
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("{0}-то число на Фибоначи е: {1}", i, fibonachiN);
                fibonachiN = fibonachiN + fibonachiNminusOne;
                fibonachiNminusOne = fibonachiN - fibonachiNminusOne;
                sum = sum + fibonachiNminusOne;
            }
            Console.WriteLine("Сумата от първите {0} числа на Фибоначи е: {1}", n, sum);
        }
    }
}
