using System;
using System.Collections.Generic;

class OddApearenceCounter
{
    static void Main()
    {
        IList<string> inputData = GetData();
        IDictionary<string, int> numbersAppearenceCount = CountWords(inputData);
        PrintResult(numbersAppearenceCount);
    }

    private static IList<string> GetData()
    {
        Console.WriteLine("Enter some words: ");

        IList<string> inputData = new List<string>();
        while (true)
        {
            string currentValue = Console.ReadLine();

            if (currentValue == string.Empty)
            {
                break;
            }

            inputData.Add(currentValue);
        }

        return inputData;
    }

    private static IDictionary<string, int> CountWords(IList<string> inputData)
    {
        IDictionary<string, int> numbersAppearenceCount = new Dictionary<string, int>();
        foreach (string word in inputData)
        {
            if (!numbersAppearenceCount.ContainsKey(word))
            {
                numbersAppearenceCount[word] = 0;
            }

            numbersAppearenceCount[word]++;
        }

        return numbersAppearenceCount;
    }

    private static void PrintResult(IDictionary<string, int> numbersAppearenceCount)
    {
        foreach (var pair in numbersAppearenceCount)
        {
            if (pair.Value % 2 != 0)
            {
                Console.WriteLine("{0}\t-->\t{1} times", pair.Key, pair.Value);
            }
        }
    }
}
