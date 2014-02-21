/*
 * Write a program to convert decimal numbers to their binary representation.
 */

namespace DecToBin
{
    using System;
    using System.Collections.Generic;
    class DecToBin
    {
        static void Main()
        {
            Console.Write("Enter an integer: ");
            int numberInDec = int.Parse(Console.ReadLine());
            Console.WriteLine("\n{0} in binary is:", numberInDec);
            
            List<int> numberInBin = new List<int>();
            while(numberInDec != 0)
            {
                int tempValue = numberInDec % 2;
                numberInBin.Add(tempValue);
                numberInDec /= 2;
            }
            numberInBin.Reverse();
            
            foreach (var binary in numberInBin)
            {
                Console.Write(binary);
            }
            Console.WriteLine();
        }
    }
}
