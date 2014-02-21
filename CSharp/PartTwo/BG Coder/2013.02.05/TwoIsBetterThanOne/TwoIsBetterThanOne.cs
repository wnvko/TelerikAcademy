/*
 * Start 15:40
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoIsBetterThanOne
{
    class TwoIsBetterThanOne
    {
        public static void TaskOne(long a, long b)
        {
            int answer = 0;
            if (a < 10)
            {
                a = 10;
            }

            for (long i = a; i < b; i++)
            {   
                string input = i.ToString();
                for (int j = 0; j < 1 + input.Length / 2; j++)
                {
                    if (input[j] != input[input.Length - j - 1])
                    {
                        break;
                    }

                    if (input[j] != '3' && input[j] != '5')
                    {
                        break;
                    }

                    answer++;
                }
            }

            Console.WriteLine(answer);
        }

        public static void TaskTwo(int[] numbers, int p)
        {
            int answer = 0;
            Array.Sort(numbers);
            double margin = p * numbers.Length / 100.0;
            margin = Math.Round(margin);
            answer = numbers[(int)margin - 1];
            Console.WriteLine(answer);
        }

        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] inputArray = input.Split(' ');
            long A = long.Parse(inputArray[0]);
            long B = long.Parse(inputArray[1]);

            string numbersAsString = Console.ReadLine();
            string[] numbersArray = numbersAsString.Split(',');
            int[] numbers = new int[numbersArray.Length];
            for (int i = 0; i < numbersArray.Length; i++)
            {
                numbers[i] = int.Parse(numbersArray[i].Trim());
            }

            int P = int.Parse(Console.ReadLine());

            TaskOne(A, B);
            TaskTwo(numbers, P);


        }
    }
}
