using System;

namespace BookHomeworks
{
    class Chapter04Problem06
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Въведете едно число");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Въведете второ число");
            int b = int.Parse(Console.ReadLine());
            int max = a - ((a - b) & ((a - b) >> 31));
            Console.WriteLine("По-голямото от двете числа е {0}", max);
        }
    }
}
