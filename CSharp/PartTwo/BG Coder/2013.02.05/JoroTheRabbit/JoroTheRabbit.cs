/*
 * Start 11:45
 * @12:20 5 pts
 * End 12:40 @75 pts.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoroTheRabbit
{
    
    class JoroTheRabbit
    {
        public static int[] ConvertInputToNumbers(string input)
        {
            string[] terenAsStringArray = input.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            int[] terrenNumbers = new int[terenAsStringArray.Length];

            for (int i = 0; i < terenAsStringArray.Length; i++)
            {
                terrenNumbers[i] = int.Parse(terenAsStringArray[i].Trim());
            }

            return terrenNumbers;
        }
        public static int JumpsCounter(int[] input)
        {
            int maxJumps = int.MinValue;
            for (int start = 0; start < input.Length; start++ )
            {
                for (int step = 1; step < input.Length; step++)
                {
                    int currentPosition = input[start];
                    bool[] visited = new bool[input.Length];
                    int jumps = 1;
                    visited[start] = true;
                    int toStepOn = start + step;
                    while (true)
                    {
                        if (toStepOn >= input.Length)
                        {
                            toStepOn = toStepOn - input.Length;
                        }

                        if (!visited[toStepOn] && currentPosition < input[toStepOn])
                        {
                            visited[toStepOn] = true;
                            currentPosition = input[toStepOn];
                            jumps++;
                            toStepOn = toStepOn + step;
                        }
                        else
                        {
                            if (jumps > maxJumps)
                            {
                                maxJumps = jumps;
                            }

                            break;
                        }
                    }
                }
            }

            return maxJumps;
        }

        static void Main(string[] args)
        {
            string terenAsString = Console.ReadLine();
            int[] terenNumbers = ConvertInputToNumbers(terenAsString);
            int finalResult = JumpsCounter(terenNumbers);
            Console.WriteLine(finalResult);
        }
    }
}
