/*
 * Write a program to convert binary numbers to hexadecimal numbers (directly).
 */

namespace BinToHex
{
    using System;
    using System.Collections.Generic;
    class BinToHex
    {
        static void Main()
        {
            Console.Write("Enter a binary number: ");
            string binNumber = Console.ReadLine();
            string hexNumber = "";
            string tempNumber = "";
            int leadingZerosCount = 4 - binNumber.Length % 4;
            if (leadingZerosCount==4)
            {
                leadingZerosCount = 0;
            }
            for (int index = 0; index < leadingZerosCount; index++)
            {
                binNumber = "0" + binNumber;
            }

            for (int index = 0; index < binNumber.Length; index += 4)
            {
                tempNumber = binNumber.Substring(index, 4);
                switch(tempNumber)
                {
                    case "0000":
                        {
                            tempNumber = "0";
                            break;
                        }
                    case "0001":
                        {
                            tempNumber = "1";
                            break;
                        }
                    case "0010":
                        {
                            tempNumber = "2";
                            break;
                        }
                    case "0011":
                        {
                            tempNumber = "3";
                            break;
                        }
                    case "0100":
                        {
                            tempNumber = "4";
                            break;
                        }
                    case "0101":
                        {
                            tempNumber = "5";
                            break;
                        }
                    case "0110":
                        {
                            tempNumber = "6";
                            break;
                        }
                    case "0111":
                        {
                            tempNumber = "7";
                            break;
                        }
                    case "1000":
                        {
                            tempNumber = "8";
                            break;
                        }
                    case "1001":
                        {
                            tempNumber = "9";
                            break;
                        }
                    case "1010":
                        {
                            tempNumber = "A";
                            break;
                        }
                    case "1011":
                        {
                            tempNumber = "B";
                            break;
                        }
                    case "1100":
                        {
                            tempNumber = "C";
                            break;
                        }
                    case "1101":
                        {
                            tempNumber = "D";
                            break;
                        }
                    case "1110":
                        {
                            tempNumber = "E";
                            break;
                        }
                    case "1111":
                        {
                            tempNumber = "F";
                            break;
                        }
                }
                hexNumber = hexNumber + tempNumber;
            }
            Console.WriteLine("\nBinary {0} is Hexadecimal {1}", binNumber, hexNumber);
        }
    }
}
