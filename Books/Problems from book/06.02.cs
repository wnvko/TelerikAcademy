using System;

namespace ConsoleApplication
{
    class Chapter06Problem02
    {
        static void Main(string[] args)
        {
            Console.Write("Въведете броя на числата: ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                if ((i%3==0) && (i%7==0))
                {
                    continue;
                }
                Console.WriteLine(i);
            }
        }
    }
}
