namespace BitsExchange
{
    using System;

    public class BitsExchange
    {
        public static void Main(string[] args)
        {
            Console.Write("Please enter a number:");
            int number = int.Parse(Console.ReadLine());

            int bitPosition3 = CheckBitAtPosition(number, 3);
            int bitPosition4 = CheckBitAtPosition(number, 4);
            int bitPosition5 = CheckBitAtPosition(number, 5);

            int bitPosition24 = CheckBitAtPosition(number, 24);
            int bitPosition25 = CheckBitAtPosition(number, 25);
            int bitPosition26 = CheckBitAtPosition(number, 26);

            number = SwitchBits(number, bitPosition3, bitPosition24, 3, 24);
            number = SwitchBits(number, bitPosition4, bitPosition25, 4, 25);
            number = SwitchBits(number, bitPosition5, bitPosition26, 5, 26);

            Console.WriteLine(number);
        }

        private static int SwitchBits(int number, int firstBit, int secondBit, int firstBitPos, int secondBitPos)
        {
            int mask = 1;
            if (firstBit != secondBit)
            {
                if (firstBit > 0)
                {
                    mask = 1;
                    mask = mask << firstBitPos;
                    number = (~mask) & number;
                    mask = 1;
                    mask = mask << secondBitPos;
                    number = mask | number;
                }
                else
                {
                    mask = 1;
                    mask = mask << firstBitPos;
                    number = mask | number;
                    mask = 1;
                    mask = mask << secondBitPos;
                    number = (~mask) & number;
                }
            }

            return number;
        }

        private static int CheckBitAtPosition(int number, int position)
        {
            int mask = 1;
            mask = mask << position;
            int maskAtPossition = mask & number;
            int bitAtPossition = maskAtPossition >> position;
            return bitAtPossition;
        }
    }
}
