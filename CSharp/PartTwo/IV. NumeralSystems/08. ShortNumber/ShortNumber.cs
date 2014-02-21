/*
 * Write a program that shows the binary representation of
 * given 16-bit signed integer number (the C# type short).
 */

namespace ShortNumber
{
    using System;
    using System.Collections.Generic;
    class ShortNumber
    {
        static string ConvertPositiveNumber(int inputNumber)
        {
            List<string> shortNumber = new List<string>();
            for (int index = 0; index < 16; index++)
            {
                if (inputNumber == 0)
                {
                    shortNumber.Add(inputNumber.ToString());
                }
                else
                {
                    shortNumber.Add((inputNumber % 2).ToString());
                    inputNumber /= 2;
                }
            }
            shortNumber.Reverse();
            string result = string.Join("", shortNumber.ToArray());
            return result;
        }
        static string ConvertNegativeNumber(int inputNumber)
        {
            inputNumber += 32768;
            List<string> shortNumber = new List<string>();
            for (int index = 0; index < 16; index++)
            {
                if (index == 15)
                {
                    shortNumber.Add("1");
                    break;
                }
                if (inputNumber == 0)
                {
                    shortNumber.Add(inputNumber.ToString());
                }
                else
                {
                    shortNumber.Add((inputNumber % 2).ToString());
                    inputNumber /= 2;
                }
            }
            shortNumber.Reverse();
            string result = string.Join("", shortNumber.ToArray());
            return result;
        }
        static void Main()
        {
            Console.Write("Enter an integer (-32 768 to 32 767): ");
            int userNumber = int.Parse(Console.ReadLine());
            string convertedNumber = "";

            if (userNumber <0)
            {
                convertedNumber = ConvertNegativeNumber(userNumber);
            }
            else
            {
                convertedNumber = ConvertPositiveNumber(userNumber);
            }
            Console.WriteLine("\nBinary representation of Short {0} is:\n", userNumber);
            Console.WriteLine(convertedNumber);
        }
    }
}
