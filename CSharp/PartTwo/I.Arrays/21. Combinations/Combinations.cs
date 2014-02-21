/*
 * Write a program that reads two numbers N and K and generates
 * all the combinations of K distinct elements from the set [1..N].
 * Example:	N = 5, K = 2 -> {1, 2}, {1, 3}, {1, 4}, {1, 5}, {2, 3}, {2, 4}, {2, 5}, {3, 4}, {3, 5}, {4, 5}
 */

namespace Combinations
{
    using System;
    using System.Collections.Generic;

    class Combinations
    {
        private static IEnumerable<string> CalculateCombinations(int start, int level, List<int> list)
        {
            List<int> innerList = list;
            for (int i = start; i < innerList.Count; i++)
                if (level == 1)
                {
                    yield return string.Format("{0}", innerList[i]);
                }
                else
                {
                    foreach (string combination in CalculateCombinations(i + 1, level - 1, innerList))
                    {
                        yield return String.Format("{0} {1}", innerList[i], combination);
                    }
                }
        }

        static void Main(string[] args)
        {
            //input
            Console.Write("Enter the number of variations: ");
            int numberOfVariations = int.Parse(Console.ReadLine());

            Console.Write("Enter the number of elements: ");
            int numberOfElements = int.Parse(Console.ReadLine());

            List<int> inputData = new List<int>();

            for (int index = 0; index < numberOfVariations; index++)
            {
                inputData.Add(index + 1);
            }

            //calculations
            var combinations = CalculateCombinations(0, numberOfElements, inputData);

            //output
            foreach (var item in combinations)
            {
                Console.WriteLine(item);
            }
        }
    }
}
