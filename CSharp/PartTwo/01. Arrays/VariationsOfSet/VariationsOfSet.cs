﻿/*
 * Write a program that reads two numbers N and K and generates all the variations of K elements from the set [1..N].
 */

using System;
using System.Collections.Generic;

public class VariationsOfSet
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

        var variations = CalculateVariations(0, numberOfElements, inputData);

        foreach (var item in variations)
        {
            Console.WriteLine(item);
        }
    }

    private static IEnumerable<string> CalculateVariations(int start, int level, List<int> list)
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
                foreach (string variation in CalculateVariations(0, level - 1, innerList))
                {
                    yield return string.Format("{0} {1}", innerList[i], variation);
                }
            }
        }
    }
}
