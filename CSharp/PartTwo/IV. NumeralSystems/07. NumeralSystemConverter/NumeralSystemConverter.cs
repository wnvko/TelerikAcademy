/*
 * Write a program to convert from any numeral system of
 * given base s to any other numeral system of base
 * d (2 ≤ s, d ≤  16).
 */

namespace NumeralSystemConverter
{
    using System;
    using System.Collections.Generic;
    class NumeralSystemConverter
    {
        static int ConvertToDec(string inputNumber, int numberBase)
        {
            int decNumber = 0;
            for (int index = inputNumber.Length - 1; index >= 0; index--)
            {
                int power = inputNumber.Length - index - 1;
                int inputNumberBase = 0;
                switch (inputNumber[index])
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
                            inputNumberBase = int.Parse(inputNumber[index].ToString());
                            break;
                        }
                    case 'A':
                        {
                            inputNumberBase = 10;
                            break;
                        }
                    case 'B':
                        {
                            inputNumberBase = 11;
                            break;
                        }
                    case 'C':
                        {
                            inputNumberBase = 12;
                            break;
                        }
                    case 'D':
                        {
                            inputNumberBase = 13;
                            break;
                        }
                    case 'E':
                        {
                            inputNumberBase = 14;
                            break;
                        }
                    case 'F':
                        {
                            inputNumberBase = 15;
                            break;
                        }
                }
                decNumber = decNumber + inputNumberBase * (int)Math.Pow(numberBase, power);
            }
            return decNumber;
        }
        static string ConvertFromDec(int inputNumber, int numberBase)
        {
            List<string> convertedNumber = new List<string>();

            while (inputNumber != 0)
            {
                int tempValue = inputNumber % numberBase;
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
                            convertedNumber.Add("" + tempValue);
                            break;
                        }
                    case 10:
                        {
                            convertedNumber.Add("A");
                            break;
                        }
                    case 11:
                        {
                            convertedNumber.Add("B");
                            break;
                        }
                    case 12:
                        {
                            convertedNumber.Add("C");
                            break;
                        }
                    case 13:
                        {
                            convertedNumber.Add("D");
                            break;
                        }
                    case 14:
                        {
                            convertedNumber.Add("E");
                            break;
                        }
                    case 15:
                        {
                            convertedNumber.Add("F");
                            break;
                        }
                }
                inputNumber /= numberBase;
            }

            string result = "";
            foreach (var number in convertedNumber)
            {
                result = number + result;
            }

            return result;
        }
        static void Main()
        {
            Console.Write("Enter the numeral base of the number to convert: ");
            int numberBase = int.Parse(Console.ReadLine());
            Console.Write("Enter the number in {0} base: ", numberBase);
            string numberToConvert = Console.ReadLine();
            Console.Write("Enter the numeral base to convert to: ");
            int newBase = int.Parse(Console.ReadLine());

            string convertedNumber = ConvertFromDec(ConvertToDec(numberToConvert, numberBase), newBase);

            Console.WriteLine("\n{0} base {1} is {2} base {3}", numberToConvert, numberBase, convertedNumber, newBase);
        }
    }
}
