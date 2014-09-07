using System;
using System.Collections.Generic;

public class CmbinationsWithRepetiotions
{
    private static int n;
    private static int k;
    private static int[] array;

    static void Main()
    {
        k = GetInput("elemets (k)");
        n = GetInput("elements in the set (n): ");
        array = new int[k];
        Generate(0, 0);
    }

    static void Generate(int index, int start)
    {
        if (index >= k)
        {
            PrintResult(array);
        }
        else
        {
            for (int i = start; i < n; i++)
            {
                array[index] = i;
                Generate(index + 1, i);
            }
        }
    }

    private static void PrintResult(int[] array)
    {
        Console.WriteLine(string.Join(", ", array));
    }

    private static int GetInput(string input)
    {
        Console.Write("Please enter number of {0}: ", input);
        int userInput = int.Parse(Console.ReadLine());
        return userInput;
    }
}
