using System;

namespace BookHomeworks
{
    class Chapter04Problem11
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Въведете броя на числата");
            int count = int.Parse(Console.ReadLine());
            for (int i = 1; i <= count; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
