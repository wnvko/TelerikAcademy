using System;

namespace ConsoleApplication1
{
    class Chapter03Problem13
    {
        static void Main(string[] args)
        {            
            int n = 35;
            int v = 0;
            int p = 5;
            int i = 1;
            int mask = i << p;            
            Console.WriteLine(((v == 0) ? (n & (~mask)) : (n|mask)));
        }
    }
}
