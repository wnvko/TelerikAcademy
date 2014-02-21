/*
 * start 20:00
 * end   20:29
 */

namespace MultiverseCommunication
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class MultiverseCommunication
    {
        public static int ConvertInput(string input)
        {
            int returnValue = 0;
            switch (input)
            {
                case "CHU": returnValue = 0; break;
                case "TEL": returnValue = 1; break;
                case "OFT": returnValue = 2; break;
                case "IVA": returnValue = 3; break;
                case "EMY": returnValue = 4; break;
                case "VNB": returnValue = 5; break;
                case "POQ": returnValue = 6; break;
                case "ERI": returnValue = 7; break;
                case "CAD": returnValue = 8; break;
                case "K-A": returnValue = 9; break;
                case "IIA": returnValue = 10; break;
                case "YLO": returnValue = 11; break;
                case "PLA": returnValue = 12; break;
            }

            return returnValue;
        }
        public static void Main()
        {
            string inputNumber = Console.ReadLine();

            List<string> numbersAsText = new List<string>();
            Regex regexParser = new Regex(@"[\w-]{3}");
            foreach (Match match in regexParser.Matches(inputNumber))
            {
                numbersAsText.Add(match.ToString());
            }

            int[] numbersAsInt = new int[numbersAsText.Count];
            for (int i = 0; i < numbersAsText.Count; i++)
            {
                numbersAsInt[numbersAsText.Count - i - 1] = ConvertInput(numbersAsText[i]);
            }

            double result = 0d;
            for (int i = 0; i < numbersAsInt.Length; i++)
            {
                result += numbersAsInt[i] * Math.Pow(13, i);
            }

            Console.WriteLine(result);
        }
    }
}