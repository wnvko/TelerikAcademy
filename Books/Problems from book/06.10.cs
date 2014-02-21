using System;

namespace ConsoleApplication
{
    class Chapter06Problem10
    {
        static void Main(string[] args)
        {
            Console.Write("Въведете N: ");
            int N = int.Parse(Console.ReadLine());
            for (int i = 1; i <= N; i++)
            {
                for (int j = i; j <= i + N - 1; j++)
                {
                    Console.Write("{0}", j);
                }
                Console.WriteLine("");
            }
        }
    }
}