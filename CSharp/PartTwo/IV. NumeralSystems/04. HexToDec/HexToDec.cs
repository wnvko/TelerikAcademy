/*
 * Write a program to convert hexadecimal numbers to their decimal representation.
 */

namespace HexToDec
{
    using System;
    using System.Collections.Generic;
    class HexToDec
    {
        static void Main()
        {
            Console.Write("Enter a hexadecimal number: ");
            string hexNumber = Console.ReadLine();
            int decNumber = 0;
            for (int index = hexNumber.Length - 1; index >= 0; index--)
            {
                int power = hexNumber.Length - index - 1;
                int hexNumberBase = 0;
                switch(hexNumber[index])
                {
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                        {
                            hexNumberBase = int.Parse(hexNumber[index].ToString());
                            break;
                        }
                    case 'A':
                        {
                            hexNumberBase = 10;
                            break;
                        }
                    case 'B':
                        {
                            hexNumberBase = 11;
                            break;
                        }
                    case 'C':
                        {
                            hexNumberBase = 12;
                            break;
                        }
                    case 'D':
                        {
                            hexNumberBase = 13;
                            break;
                        }
                    case 'E':
                        {
                            hexNumberBase = 14;
                            break;
                        }
                    case 'F':
                        {
                            hexNumberBase = 15;
                            break;
                        }
                }
                decNumber = decNumber + hexNumberBase * (int)Math.Pow(16, power);
            }
            Console.WriteLine("\nHexadecimal {0} is decimal {1}", hexNumber, decNumber);
        }
    }
}
