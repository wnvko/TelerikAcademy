/*
 * Start 10:55
 * @ 11:35 45 pts.
 * @ 11:40 65 pts.
 * End 11:45 @ 100 pts.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DurankulakNumbers
{
    class DurankulakNumbers
    {
        public static List<string> KaspichanToArray(string input)
        {
            int numbersCount = input.Length;
            List<string> kaspichList = new List<string>();
            for (int number = numbersCount - 1; number >= 0; number -= 2)
            {
                if (number - 1 >= 0)
                {
                    if (Char.IsUpper(input[number - 1]))
                    {
                        kaspichList.Add(input[number].ToString());
                        number++;
                    }
                    else
                    {
                        kaspichList.Add(input[number - 1].ToString() + input[number]);
                    }
                }
                else
                {
                    kaspichList.Add(input[number].ToString());
                }
            }

            return kaspichList;
        }

        public static int ParseSingleNumber(string input)
        {
            int leftNumber = 0;
            int rightNumber = 0;
            if (input.Length > 1)
            {
                rightNumber = input[1] - 'A';
                leftNumber = input[0] - 'a' + 1;
            }
            else
            {
                rightNumber = input[0] - 'A';
            }

            leftNumber *= 26;
            int result = rightNumber + leftNumber;
            return result;
        }

        public static long ParseKaspichan(List<string> input)
        {
            long result = 0;
            for (int number = 0; number < input.Count; number++)
            {
                result = result + ParseSingleNumber(input[number]) * (long)Math.Pow(168, number);
            }
            return result;
        }
        static void Main(string[] args)
        {
            string kaspichanNumber = Console.ReadLine();
            List<string> kaspichanList = KaspichanToArray(kaspichanNumber);
            long finalresult = ParseKaspichan(kaspichanList);
            Console.WriteLine(finalresult);
        }
    }
}
