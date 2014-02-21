/*
 * start @ 18:30
 * 100 pt @ 19:30
 */

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaspichanNumbers
{
    using System;
    using System.Collections.Generic;

    public class KaspichanNumbers
    {
        public static List<int> ConvertTo256(ulong input)
        {
            List<int> numbers = new List<int>();
            while (input != 0U)
            {
                numbers.Add((int)(input % 256));
                input /= 256;
            }

            return numbers;
        }

        public static string ConvertToKaspichen(int input)
        {
            int leading = input / 26;
            int remaining = input % 26;
            string leadingChar = string.Empty;
            string trailingChar = string.Empty;

            trailingChar = ((char)((char)remaining + 'A')).ToString();
            if (leading != 0)
            {
                leadingChar = ((char)((char)(leading - 1) + 'a')).ToString();
            }

            return (leadingChar + trailingChar);
        }
        public static void Main()
        {
            ulong inputData = ulong.Parse(Console.ReadLine());
            List<int> inputTo256 = ConvertTo256(inputData);
            string result = string.Empty;
            for (int i = inputTo256.Count-1; i >= 0; i--)
            {
                result += ConvertToKaspichen(inputTo256[i]);
            }
            Console.WriteLine(result);
        }
    }
}
