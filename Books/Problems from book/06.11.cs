using System;

namespace ConsoleApplication
{
    class Chapter06Problem11
    {
        static void Main(string[] args)
        {
            Console.Write("Въведете N: ");
            int N = int.Parse(Console.ReadLine());
            Console.WriteLine("{0}! е с {1} броя 0", N, (N / 5));//броят на нулите се увеличава с една на всеки пети множител!
        }
    }
}