using System;

namespace ConsoleApplication1
{
    class Chapter01Problem10
    {
        static void Main(string[] args)
        {
            int i = 2;
            do
            {
                System.Console.WriteLine(i*(System.Math.Pow(-1,i)));
                i++;
            }
            while (i < 101);
        }
    }
}
