using System;

namespace BookHomeworks
{
    class Chapter04Problem10
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Въведете броя на числата");
            int count = int.Parse(Console.ReadLine());
            for (int i = 1; i <= count; i++)
            {
                Console.WriteLine("Въведете число №{0}", i);
                int bufer = int.Parse(Console.ReadLine());
                bufer = bufer + bufer;
                if (i == count)
                {
                    Console.WriteLine("Сумата от числата е {0}", bufer);
                }
            }
        }
    }
}
