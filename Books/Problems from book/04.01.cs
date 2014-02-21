using System;

namespace BookHomeworks
{
    class Chapter04Problem01
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Въведете три числа");
            Console.Write("a = ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("b = ");
            int b = int.Parse(Console.ReadLine());
            Console.Write("c = ");
            int c = int.Parse(Console.ReadLine());            
            Console.WriteLine("Сумата на числата {0}, {1} и {2} е " + (a + b + c), a, b, c);
        }
    }
}
