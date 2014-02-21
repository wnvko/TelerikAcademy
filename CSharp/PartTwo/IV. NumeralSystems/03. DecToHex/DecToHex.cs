/*
 * Write a program to convert decimal numbers to their hexadecimal representation.
 */

namespace DecToHex
{
    using System;
    using System.Collections.Generic;
    class DecToHex
    {
        static void Main()
        {
            Console.Write("Enter an integer: ");
            int numberInDec = int.Parse(Console.ReadLine());
            Console.Write("\n{0} in hexadecimal is: ", numberInDec);

            List<string> numberInHex = new List<string>();
            while (numberInDec != 0)
            {
                int tempValue = numberInDec % 16;
                switch (tempValue)
                {
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                    case 7:
                    case 8:
                    case 9:
                        {
                            numberInHex.Add(""+tempValue);
                            break;
                        }
                    case 10:
                        {
                            numberInHex.Add("A");
                            break;
                        }
                    case 11:
                        {
                            numberInHex.Add("B");
                            break;
                        }
                    case 12:
                        {
                            numberInHex.Add("C");
                            break;
                        }
                    case 13:
                        {
                            numberInHex.Add("D");
                            break;
                        }
                    case 14:
                        {
                            numberInHex.Add("E");
                            break;
                        }
                    case 15:
                        {
                            numberInHex.Add("F");
                            break;
                        }
                }
                numberInDec /= 16;
            }
            numberInHex.Reverse();

            foreach (var hex in numberInHex)
            {
                Console.Write(hex);
            }
            Console.WriteLine();
        }
    }
}
