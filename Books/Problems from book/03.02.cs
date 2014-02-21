using System;

namespace ConsoleApplication1
{
    class Chapter03Problem02
    {
        static void Main(string[] args)
        {
            int a = 35;
            Console.WriteLine(a%5==0&&a%7==0 ? "Дели се на 5 и 7" : "Не се дели на 5 и 7");
        }
    }
}
