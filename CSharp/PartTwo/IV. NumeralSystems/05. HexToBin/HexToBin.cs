/*
 * Write a program to convert hexadecimal numbers to binary numbers (directly).
 */

namespace HexToBin
{
    using System;
    using System.Collections.Generic;
    class HexToBin
    {
        static void Main()
        {
            Console.Write("Enter a hexadecimal number: ");
            string hexNumber = Console.ReadLine();
            string binNumber = "";
            string tempNumber = "";

            foreach (var number in hexNumber)
            {
                switch (number)
                {
                    case '0':
                        {
                            tempNumber = "0000";
                            break;
                        }
                    case '1':
                        {
                            tempNumber = "0001";
                            break;
                        }
                    case '2':
                        {
                            tempNumber = "0010";
                            break;
                        }
                    case '3':
                        {
                            tempNumber = "0011";
                            break;
                        }
                    case '4':
                        {
                            tempNumber = "0100";
                            break;
                        }
                    case '5':
                        {
                            tempNumber = "0101";
                            break;
                        }
                    case '6':
                        {
                            tempNumber = "0110";
                            break;
                        }
                    case '7':
                        {
                            tempNumber = "0111";
                            break;
                        }
                    case '8':
                        {
                            tempNumber = "1000";
                            break;
                        }
                    case '9':
                        {
                            tempNumber = "1001";
                            break;
                        }
                    case 'A':
                        {
                            tempNumber = "1010";
                            break;
                        }
                    case 'B':
                        {
                            tempNumber = "1011";
                            break;
                        }
                    case 'C':
                        {
                            tempNumber = "1100";
                            break;
                        }
                    case 'D':
                        {
                            tempNumber = "1101";
                            break;
                        }
                    case 'E':
                        {
                            tempNumber = "1110";
                            break;
                        }
                    case 'F':
                        {
                            tempNumber = "1111";
                            break;
                        }
                }
                binNumber = binNumber + tempNumber;
            }
            Console.WriteLine("\nHexadecimal {0} is decimal {1}", hexNumber, binNumber);
        }
    }
}
