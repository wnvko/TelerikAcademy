/*
 * start @19:30
 * 100 pt @20:47
 */

namespace GreedyDwarf
{
    using System;
    using System.Collections.Generic;

    public class GreedyDwarf
    {
        public static List<int> StringToNumbers(string input)
        {
            List<int> result = new List<int>();
            char[] separators = new char[] { ',', ' ' };
            string[] temp = input.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            foreach (var number in temp)
            {
                result.Add(int.Parse(number));
            }

            return result;
        }

        public static int CalculateSum(List<int> map, List<int> patern)
        {
            int sum = 0;
            int mapCount = map.Count;
            int paterncount = patern.Count;
            int currentValey = 0;
            int currentPatern = 0;
            bool[] isVisited = new bool[mapCount];

            while (true)
            {
                if (currentValey >= 0 && currentValey < mapCount && !isVisited[currentValey])
                {
                    sum += map[currentValey];
                    isVisited[currentValey] = true;
                }
                else
                {
                    break;
                }

                if (currentPatern == paterncount)
                {
                    currentPatern = 0;
                }

                currentValey += patern[currentPatern];
                currentPatern++;
            }

            return sum;
        }

        public static void Main()
        {
            string valeyMapAsString = Console.ReadLine();
            List<int> valeyMap = new List<int>();
            valeyMap = StringToNumbers(valeyMapAsString);

            int valeyCount = int.Parse(Console.ReadLine());
            List<List<int>> paterns = new List<List<int>>();

            for (int i = 0; i < valeyCount; i++)
            {
                List<int> patern = new List<int>();
                patern = StringToNumbers(Console.ReadLine());
                paterns.Add(patern);
            }

            int maxSum = int.MinValue;
            for (int i = 0; i < paterns.Count; i++)
            {
                int sum = CalculateSum(valeyMap, paterns[i]);
                if (sum > maxSum)
                {
                    maxSum = sum;
                }
            }

            Console.WriteLine(maxSum);
        }
    }
}
