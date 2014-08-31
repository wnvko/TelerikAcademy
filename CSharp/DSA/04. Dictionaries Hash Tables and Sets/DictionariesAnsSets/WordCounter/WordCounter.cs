using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class WordCounter
{
    private const string testDataFileLocation = @"..\..\TestData.txt";

    static void Main()
    {
        IList<string> inputData = GetData();
        IDictionary<string, int> numbersAppearenceCount = CountWords(inputData);
        PrintResult(numbersAppearenceCount);
    }

    private static IList<string> GetData()
    {
        Console.WriteLine("Start reading the file...");

        StreamReader tr = new StreamReader(testDataFileLocation);
        string lineOfText = string.Empty;
        List<string> inputData = new List<string>();

        using (tr)
        {
            while ((lineOfText = tr.ReadLine()) != null)
            {
                string[] currentLineWords = lineOfText.Split(new char[] { ' ', '.', ',' }, StringSplitOptions.RemoveEmptyEntries);
                inputData.AddRange(currentLineWords);
            }
        }

        return inputData;
    }

    private static IDictionary<string, int> CountWords(IList<string> inputData)
    {
        IDictionary<string, int> numbersAppearenceCount = new Dictionary<string, int>();
        foreach (string word in inputData)
        {
            string wordLowerCase = word.ToLower();
            if (!numbersAppearenceCount.ContainsKey(wordLowerCase))
            {
                numbersAppearenceCount[wordLowerCase] = 0;
            }

            numbersAppearenceCount[wordLowerCase]++;
        }

        return numbersAppearenceCount;
    }

    private static void PrintResult(IDictionary<string, int> numbersAppearenceCount)
    {
        var appearencesOrdered = numbersAppearenceCount.OrderBy(w => w.Value);
        foreach (var pair in appearencesOrdered)
        {
            if (pair.Key.Length > 7)
            {
                Console.WriteLine("{0}\t-->\t{1} times", pair.Key, pair.Value);

            }
            else
            {
                Console.WriteLine("{0}\t\t-->\t{1} times", pair.Key, pair.Value);
            }
        }
    }
}
