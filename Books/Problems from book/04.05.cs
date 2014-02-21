using System;

namespace BookHomeworks
{
    class Chapter04Problem05
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Въведете долната граница");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Въведете горната граница");
            int b = int.Parse(Console.ReadLine());
            int n = 0; //брой числа делящи се на пет в интервала [a;b]
            n = n + (a % 5 == 0 ? 1 : 0);
            n = n + (b % 5 == 0 ? 1 : 0);
            n = n + (a == 0 ? -1 : 0);
            n = n + (b == 0 ? -1 : 0);
            if (a > b)
            {
                n = n + (a - b - 1) / 5;
            }
            else
            {
                n = n + (b - a - 1) / 5;
            }
            Console.WriteLine("В интервала {0} - {1} има точно {2} числа, които се делят на пет без остатък!", a, b, n);
        }
    }
}
