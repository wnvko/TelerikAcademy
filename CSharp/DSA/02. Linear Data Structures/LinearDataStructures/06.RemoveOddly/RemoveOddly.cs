using System;
using System.Collections.Generic;

public class RemoveOddly
{
    public static List<int> RemoveOddApear(List<int> input)
    {
        Dictionary<int, bool> checkApearence = new Dictionary<int, bool>();
        foreach (var item in input)
        {
            if (checkApearence.ContainsKey(item))
            {
                checkApearence[item] = !checkApearence[item];
            }
            else
            {
                checkApearence.Add(item, true);
            }
        }

        List<int> result = new List<int>();
        foreach (var item in input)
        {
            if (!checkApearence[item])
            {
                result.Add(item);
            }
        }

        return result;
    }

    public static void PrintList(List<int> listToPrint)
    {
        foreach (var item in listToPrint)
        {
            Console.WriteLine(item);
        }
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

        List<int> oddlyItems = RemoveOddApear(inputData);
        PrintList(oddlyItems);
    }
}
