using System;
using System.Collections.Generic;

public class NumberOfApearence
{
    public static List<int> InputList()
    {
        Console.WriteLine("Please enter some numbers in range [0..1000]");
        Console.WriteLine("Enter empty line to finish");

        List<int> inputData = new List<int>();

        while (true)
        {
            string currentInput = Console.ReadLine();
            if (currentInput == string.Empty)
            {
                break;
            }

            int value = int.Parse(currentInput);

            if (value < 0 || value > 1000)
            {
                Console.WriteLine("Not valid input");
                continue;
            }

            inputData.Add(value);
        }

        return inputData;
    }

    public static SortedDictionary<int, int> CalculateNemberOfAppereance(List<int> input)
    {
        SortedDictionary<int, int> appereanceCounter = new SortedDictionary<int, int>();

        foreach (var item in input)
        {
            if (!appereanceCounter.ContainsKey(item))
            {
                appereanceCounter.Add(item, 0);
            }

            appereanceCounter[item]++;
        }

        return appereanceCounter;
    }

    public static void PrintResult(SortedDictionary<int, int> appereanceCounter)
    {
        foreach (var pair in appereanceCounter)
        {
            Console.WriteLine("{0} -> {1} time(s)", pair.Key, pair.Value);
        }
    }

    public static void Main()
    {
        List<int> inputData = InputList();
        SortedDictionary<int, int> appereanceCounter = CalculateNemberOfAppereance(inputData);
        PrintResult(appereanceCounter);
    }
}