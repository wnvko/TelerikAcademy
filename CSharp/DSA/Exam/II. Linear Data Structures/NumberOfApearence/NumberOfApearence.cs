﻿using System;
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

    public static void CalculateNemberOfAppereance(List<int> input)
    {
        SortedDictionary<int, int> appereanceCounter = new SortedDictionary<int, int>();

        foreach (var item in input)
        {
            if (appereanceCounter.ContainsKey(item))
            {
                appereanceCounter[item]++;
            }
            else
            {
                appereanceCounter.Add(item, 1);
            }
        }

        foreach (var pair in appereanceCounter)
        {
            Console.WriteLine("{0} -> {1} time(s)", pair.Key, pair.Value);
        }
    }

    public static void Main()
    {
        List<int> inputData = InputList();
        CalculateNemberOfAppereance(inputData);
    }
}
