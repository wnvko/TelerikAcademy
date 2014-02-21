using System;

namespace BookHomeworks
{
    class Chapter04Problem04
    {
        static void Main(string[] args)
        {
            double positiveNumber = 200;
            double negativeNumber = -200;
            Console.WriteLine("123456789012345678901234567890\n");
            Console.Write("{0,-10:X}", Convert.ToInt16(positiveNumber));
            Console.Write("{0, -20:F2}", positiveNumber);
            Console.WriteLine("{0,-30:F2}", negativeNumber);
        }
    }
}
