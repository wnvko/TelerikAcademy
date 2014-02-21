namespace ChangeTreeBits
{
    using System;

    class ChangeTreeBits
    {
        static void Main()
        {
            /*
             * Write a program that exchanges bits 3, 4 and 5
             * with bits 24, 25 and 26 of given 32-bit unsigned integer.
             */
            
            Console.Write("Please enter a number:");
            int number = int.Parse(Console.ReadLine());

            //take bits from possition 3,4 and 5
            int mask = 1;
            
            //check the 3rd bit of number
            mask = mask << 3;
            int maskPossition3 = mask & number;
            int bitPossition3 = maskPossition3 >> 3;

            //check the 4th bit of number
            mask = 1;
            mask = mask << 4;
            int maskPossition4 = mask & number;
            int bitPossition4 = maskPossition4 >> 4;

            //check the 5th bit of number
            mask = 1;
            mask = mask << 5;
            int maskPossition5 = mask & number;
            int bitPossition5 = maskPossition5 >> 5;
            mask = 1;

            //take bits from possition 24,25 and 26
            //check the 24th bit of number
            mask = mask << 24;
            int maskPossition24 = mask & number;
            int bitPossition24 = maskPossition24 >> 24;

            //check the 25th bit of number
            mask = 1;
            mask = mask << 25;
            int maskPossition25 = mask & number;
            int bitPossition25 = maskPossition25 >> 25;

            //check the 26th bit of number
            mask = 1;
            mask = mask << 26;
            int maskPossition26 = mask & number;
            int bitPossition26 = maskPossition26 >> 26;

            //switch bits 3 and 24
            if (bitPossition3 != bitPossition24)
            {
                if (bitPossition3 > 0)
                {
                    mask = 1;
                    mask = mask << 3;
                    number = (~mask) & number;
                    mask = 1;
                    mask = mask << 24;
                    number = mask | number;
                }
                else
                {
                    mask = 1;
                    mask = mask << 3;
                    number = mask | number;
                    mask = 1;
                    mask = mask << 24;
                    number = (~mask) & number;
                }
            }

            //switch bits 4 and 25
            if (bitPossition4 != bitPossition25)
            {
                if (bitPossition4 > 0)
                {
                    mask = 1;
                    mask = mask << 4;
                    number = (~mask) & number;
                    mask = 1;
                    mask = mask << 25;
                    number = mask | number;
                }
                else
                {
                    mask = 1;
                    mask = mask << 4;
                    number = mask | number;
                    mask = 1;
                    mask = mask << 25;
                    number = (~mask) & number;
                }
            }

            //switch bits 5 and 26
            if (bitPossition5 != bitPossition26)
            {
                if (maskPossition5 > 0)
                {
                    mask = 1;
                    mask = mask << 5;
                    number = (~mask) & number;
                    mask = 1;
                    mask = mask << 26;
                    number = mask | number;
                }
                else
                {
                    mask = 1;
                    mask = mask << 5;
                    number = mask | number;
                    mask = 1;
                    mask = mask << 26;
                    number = (~mask) & number;
                }
            }
            Console.WriteLine(number);
        }
    }
}