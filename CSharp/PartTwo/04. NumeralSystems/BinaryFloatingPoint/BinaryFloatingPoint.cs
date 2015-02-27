/*
 * Write a program that shows the internal binary representation of given 32-bit signed
 * floating-point number in IEEE 754 format (the C# type float).
 */

using System;
using System.Collections.Generic;

public class BinaryFloatingPoint
{
    public static void Main(string[] args)
    {
        Console.Write("Enter Float number: ");
        float userNumber = float.Parse(Console.ReadLine());

        int intPart = (int)Math.Truncate(userNumber);
        float fractionPart = userNumber - intPart;

        string signOfNumber = "0";
        if (userNumber < 0)
        {
            signOfNumber = "1";
        }

        userNumber = Math.Abs(userNumber);
        intPart = Math.Abs(intPart);
        fractionPart = Math.Abs(fractionPart);

        string intPartBin = ConvertDecToBin(intPart);
        string fractionPartBin = ConvertFractionPart(intPartBin, fractionPart);

        string numberExponent = string.Empty;
        string numberMantisa = string.Empty;

        if (userNumber > 0 && userNumber < 1)
        {
            int exponent = fractionPartBin.IndexOf('1') + 1;
            numberExponent = ConvertDecToBin(127 - exponent);
            numberMantisa = fractionPartBin.Substring(exponent - 1) + (new string('0', (exponent - 1)));
        }
        else
        {
            int exponent = intPartBin.Length - 1;
            numberExponent = ConvertDecToBin(127 + exponent);
            numberMantisa = intPartBin.Substring(1) + fractionPartBin + "0";
        }

        Console.WriteLine(new string('_', 47));
        Console.WriteLine("\nSign\tExponent\tMantisa");
        Console.WriteLine("{0,-8}{1,-16}{2}", signOfNumber, numberExponent, numberMantisa);
        Console.WriteLine();
    }

    private static string ConvertDecToBin(int inputNumber)
    {
        List<int> numberInBin = new List<int>();
        while (inputNumber != 0)
        {
            int tempValue = inputNumber % 2;
            numberInBin.Add(tempValue);
            inputNumber /= 2;
        }

        numberInBin.Reverse();
        string result = string.Join(string.Empty, numberInBin.ToArray());
        return result;
    }

    private static string ConvertFractionPart(string intPart, float fractionPart)
    {
        int lengtOfIntPart = 0;
        if (intPart != string.Empty)
        {
            lengtOfIntPart = intPart.Length;
        }

        float compareTo = 1.0f;
        List<string> numberInBin = new List<string>();

        for (int i = 0; i < 23 - lengtOfIntPart; i++)
        {
            compareTo /= 2;
            if (fractionPart >= compareTo)
            {
                numberInBin.Add("1");
                fractionPart -= compareTo;
            }
            else
            {
                numberInBin.Add("0");
            }
        }

        string result = string.Join(string.Empty, numberInBin.ToArray());
        return result;
    }
}