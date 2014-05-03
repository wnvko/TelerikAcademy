using System;
using System.Collections.Generic;
using System.Linq;

public class LongestSubsequence
{
    public static List<int> LongestSubsequenceOfEqualNumbers(List<int> input)
    {
        SortedDictionary<int, int> appereanceCounter = new SortedDictionary<int, int>();

        for (int i = 0; i < input.Count; i++)
        {
            if (appereanceCounter.ContainsKey(input[i]))
            {
                appereanceCounter[input[i]]++;
            }
            else
            {
                appereanceCounter.Add(input[i], 1);
            }
        }

        var numberOfRepeats = appereanceCounter.Values.Max();
        var mostFrequentValue = appereanceCounter.FirstOrDefault(x => x.Value == numberOfRepeats).Key;

        List<int> result = new List<int>();
        for (int i = 0; i < numberOfRepeats; i++)
        {
            result.Add(mostFrequentValue);
        }

        return result;
    }

    public static void Main()
    {
        Console.WriteLine("Please enter some numbers");
        Console.WriteLine("Enter empty line to finish");

        List<int> inputData = new List<int>();

        while (true)
        {
            string currentInput = Console.ReadLine();
            if (currentInput == string.Empty)
            {
                break;
            }

            inputData.Add(int.Parse(currentInput));
        }

        List<int> result = LongestSubsequenceOfEqualNumbers(inputData);
    }
}