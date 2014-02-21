using System;

namespace ConsoleApplication1
{
    class Chapter03Problem03
    {
        static void Main(string[] args)
        {
            int a = 1707;
            a = a / 100;
            a = a % 10;
            Console.WriteLine(a == 7 ? "Третата цифра на числото е 7" : "Третата цифра на числото НЕ е 7");
        }
    }
}
