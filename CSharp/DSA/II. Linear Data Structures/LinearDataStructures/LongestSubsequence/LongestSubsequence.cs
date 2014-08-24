using System;
using System.Collections.Generic;
using System.Linq;

public class LongestSubsequence
{
    public static List<int> LongestSubsequenceOfEqualNumbers(List<int> input)
    {
        if (input.Count == 0)
        {
            return new List<int>();
        }

        List<List<int>> appereanceCounter = new List<List<int>>();
        appereanceCounter.Add(new List<int> { input[0] });

        for (int i = 1; i < input.Count; i++)
        {
            if (input[i] != input[i - 1])
            {
                appereanceCounter.Add(new List<int>());
            }

            appereanceCounter[appereanceCounter.Count - 1].Add(input[i]);
        }

        int numberOfRepeats = appereanceCounter.Max(x => x.Count);
        List<int> result = appereanceCounter.FirstOrDefault(x => x.Count == numberOfRepeats);
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