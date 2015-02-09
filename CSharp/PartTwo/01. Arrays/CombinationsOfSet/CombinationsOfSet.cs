/*
 * Write a program that reads two numbers N and K and generates all the combinations of K distinct elements from the set [1..N].
 */

using System;
using System.Collections.Generic;

public class CombinationsOfSet
{
    public static void Main(string[] args)
    {
        Console.Write("Enter the number of variations: ");
        int numberOfVariations = int.Parse(Console.ReadLine());

        Console.Write("Enter the number of elements: ");
        int numberOfElements = int.Parse(Console.ReadLine());

        List<int> inputData = new List<int>();

        for (int index = 0; index < numberOfVariations; index++)
        {
            inputData.Add(index + 1);
        }

        var combinations = CalculateCombinations(0, numberOfElements, inputData);

        foreach (var item in combinations)
        {
            Console.WriteLine(item);
        }
    }

    private static IEnumerable<string> CalculateCombinations(int start, int level, List<int> list)
    {
        List<int> innerList = list;
        for (int i = start; i < innerList.Count; i++)
        {
            if (level == 1)
            {
                yield return string.Format("{0}", innerList[i]);
            }
            else
            {
                foreach (string combination in CalculateCombinations(i + 1, level - 1, innerList))
                {
                    yield return string.Format("{0} {1}", innerList[i], combination);
                }
            }
        }
    }
}
