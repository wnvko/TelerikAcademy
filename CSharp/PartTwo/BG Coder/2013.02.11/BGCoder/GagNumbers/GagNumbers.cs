/*
 * start @ 23:15
 * end @ 00:00 55 pts
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GagNumbers
{
    class GagNumbers
    {
        static void Main(string[] args)
        {
            string gagNum = Console.ReadLine();
            char[] letters = gagNum.ToCharArray();
            Array.Reverse(letters);
            List<int> numbers = new List<int>();

            for (int i = 0; i < gagNum.Length; i++)
            {
                if (letters[i] == '*')
                {
                    numbers.Add(1);
                    i++;
                }
                else if (letters[i] == '&')
                {
                    numbers.Add(3);
                    i++;
                }
                else if (letters[i] == '!')
                {
                    if (letters[i + 1] == '-')
                    {
                        numbers.Add(0);
                        i++;
                    }
                    else if (letters[i + 2] == '&')
                    {
                        numbers.Add(7);
                        i += 2;
                    }
                    else if ((i + 3) < letters.Length && letters[i + 3] == '*' &&
                            (((i + 3) == letters.Length - 1) || ((i + 3) < letters.Length && letters[i + 3] == '*')) ||
                            ((i + 5) < letters.Length && letters[i + 5] == '*') ||
                            ((i + 7) < letters.Length && letters[i + 7] == '*'))
                    {
                        numbers.Add(6);
                        i += 3;
                    }
                    else
                    {
                        numbers.Add(2);
                        i += 2;
                    }
                }
                else
                {
                    if (letters[i + 1] == '&')
                    {
                        numbers.Add(4);
                        i++;
                    }
                    else if ((i + 2) < letters.Length && letters[i + 2] == '*' &&
                            (((i + 5) == letters.Length - 1) || ((i + 6) < letters.Length && letters[i + 6] != '!')))
                    {
                        numbers.Add(8);
                        i += 5;
                    }
                    else
                    {
                        numbers.Add(5);
                        i++;
                    }
                }
            }

            long finalResult = 0L;
            for (int i = 0; i < numbers.Count; i++)
            {
                finalResult = finalResult + numbers[i] * (long)Math.Pow(9, i);
            }

            Console.WriteLine(finalResult);
        }
    }
}
