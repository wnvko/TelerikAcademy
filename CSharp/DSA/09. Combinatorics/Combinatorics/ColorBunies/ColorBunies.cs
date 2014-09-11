// download problem from here http://downloads.academy.telerik.com/svn/algo-academy/2012-10-Combinatorics/All%20problems/Problem%202.zip
using System;
using System.Collections.Generic;
using System.Linq;

public class ColorBunies
{
    public static void Main(string[] args)
    {
        int buniesAsked = int.Parse(Console.ReadLine());
        var uniqueAnswers = new Dictionary<int, int>();

        for (int i = 0; i < buniesAsked; i++)
        {
            int currentAnswer = int.Parse(Console.ReadLine());
            if (!uniqueAnswers.ContainsKey(currentAnswer))
            {
                uniqueAnswers[currentAnswer] = -1;
            }

            uniqueAnswers[currentAnswer]++;
        }

        long minNumberBunies = 0;
        foreach (var uniqueAnswer in uniqueAnswers)
        {
            minNumberBunies += ((uniqueAnswer.Key + 1) * (uniqueAnswer.Value / (uniqueAnswer.Key + 1) + 1));
        }

        Console.WriteLine(minNumberBunies);
    }
}