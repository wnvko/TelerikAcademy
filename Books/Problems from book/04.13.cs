using System;

namespace BookHomeworks
{
    class Chapter04Problem13
    {
        static void Main(string[] args)
        {
            double checkNumber = 0;
            double oldCheckNumber = 0;
            while (true)
            {
                int i = 1;
                oldCheckNumber = checkNumber;
                checkNumber = checkNumber + (1 / i);
                i++;
                if (oldCheckNumber - checkNumber <= 0.001)
                {
                    Console.WriteLine("—умата е: {0}", checkNumber);
                    break;
                }
            }
        }
    }
}
