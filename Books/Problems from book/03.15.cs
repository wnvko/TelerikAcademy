using System;

namespace ConsoleApplication1
{
    class Chapter03Problem15
    {
        static void Main(string[] args)
        {
            int number = 255;            
            int bufer3 = number >> 2;            
            bufer3 = ((bufer3 & 1) == 0 ? 0 : 1);            
            int bufer4 = number >> 3;
            bufer4 = ((bufer4 & 1) == 0 ? 0 : 1);            
            int bufer5 = number >> 4;
            bufer5 = ((bufer5 & 1) == 0 ? 0 : 1);            
            int bufer24 = number >> 23;
            bufer24 = ((bufer24 & 1) == 0 ? 0 : 1);            
            int bufer25 = number >> 24;
            bufer25 = ((bufer25 & 1) == 0 ? 0 : 1);            
            int bufer26 = number >> 25;
            bufer26 = ((bufer26 & 1) == 0 ? 0 : 1);
            if (bufer3 == bufer24)
            {
            }
            else
            {
                if (bufer3 == 0)
                {
                    number = number + 4 - 16777216;
                    Console.WriteLine(number);
                }
                else
                {
                    number = number + 16777216 - 4;
                    Console.WriteLine(number);
                }
            }
            if (bufer4 == bufer25)
            {
            }
            else
            {
                if (bufer4 == 0)
                {
                    number = number + 8 - 33554432;
                    Console.WriteLine(number);
                }
                else
                {
                    number = number - 8 + 33554432;
                    Console.WriteLine(number);
                }
            }
            if (bufer5 == bufer26)
            {
            }
            else
            {
                if (bufer5 == 0)
                {
                    number = number + 16 - 67108864;
                    Console.WriteLine(number);
                }
                else
                {
                    number = number - 16 + 67108864;
                    Console.WriteLine(number);
                }
            }
            Console.WriteLine(number);
        }
    }
}
