using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemOne
{
    class Program
    {
        public static void ParseStrangeNumber(string input)
        {
            ulong result = 0L;
            List<int> currentNumber = new List<int>();
            for (int i = input.Length-1; i >= 0; i--)
            {
                switch (input[i])
                {
                    case 'f':
                        {
                            currentNumber.Add(0);
                            break;
                        }
                    case 'N':
                        {
                            currentNumber.Add(1);
                            i -= 2;
                            break;
                        }
                    case 'C':
                        {
                            currentNumber.Add(2);
                            i -= 3;
                            break;
                        }
                    case 'L':
                        {
                            currentNumber.Add(3);
                            i -= 6;
                            break;
                        }
                    case 'Q':
                        {
                            currentNumber.Add(4);
                            i -= 5;
                            break;
                        }
                    case 'E':
                        {
                            currentNumber.Add(5);
                            i -= 3;
                            break;
                        }
                    case 'T':
                        {
                            currentNumber.Add(6);
                            i--;
                            break;
                        }
                }
            }

            for (int i = 0; i < currentNumber.Count; i++)
            {
                result = result + (ulong)currentNumber[i] * (ulong)Math.Pow(7, i);
            }

            Console.WriteLine(result);
        }
        static void Main(string[] args)
        {
            string inputNumber = Console.ReadLine();
            ParseStrangeNumber(inputNumber);
        }
    }
}
