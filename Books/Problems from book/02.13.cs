using System;

namespace ConsoleApplication1
{
    class Chapter02Problem13
    {
        static void Main(string[] args)
        {
            int a = 5;
            Console.WriteLine("a = "+a);
            int b = 3;
            Console.WriteLine("b = "+b);
            int c = b;
            b = a;
            a = c;
            Console.WriteLine("a = " + a);
            Console.WriteLine("b = " + b);
        }
    }
}
