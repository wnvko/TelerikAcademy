using System;

namespace ConsoleApplication1
{
    class Chapter03Problem11
    {
        static void Main(string[] args)
        {            
            int n=5;
            int p=1;
            int i=1;
            int mask = i << p;            
            Console.WriteLine((n & mask)!=0 ? "True" : "False");
        }
    }
}
