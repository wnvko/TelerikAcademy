using System;

namespace BookHomeworks
{
    class Chapter03Problem16
    {
        static void Main(string[] args)
        {
            int number = 469;
            int p = 2;
            int q = 7;
            int k = 2;
            int leftBit;
            int rightBit;
            for (int i = 0; i < k; i++)
            {
                leftBit = ((number >> ((q - i - 1)) & 1) == 0 ? 0 : 1);
                rightBit = ((number >> ((p + i - 1)) & 1) == 0 ? 0 : 1);
                if (leftBit != rightBit)
                {
                    number = (leftBit == 0) ? (number + (1 << (q - i - 1)) - (1 << (p + i - 1))) : (number - (1 << (q - i - 1)) + (1 << (p + i - 1)));
                }
            }
            Console.WriteLine(number);
        }

    }
}
