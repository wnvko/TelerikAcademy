using System;

namespace ConsoleApplication1
{
    class Chapter03Problem14
    {
        static void Main(string[] args)
        {
            int k = 0;
            for (int i = 1; i <= 100; i++)
            {
                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        k++;
                    }
                    else
                    {
                    }
                }
                if (k == 0)
                {
                    Console.WriteLine(i);
                }
                else
                {
                }
                k = 0;
            }   
        }
    }
}
