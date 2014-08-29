using System;
using System.Collections.Generic;

public class RemoveNegative
{
    public static void Main(string[] args)
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

        List<int> onlyPossitive = new List<int>();
        for (int i = 0; i < inputData.Count; i++)
        {
            if (inputData[i] > 0)
            {
                onlyPossitive.Add(inputData[i]);
            }
        }

        foreach (var item in onlyPossitive)
        {
            Console.WriteLine(item);
        }
    }
}