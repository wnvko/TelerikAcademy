/*
 * Write a program that reads two integer arrays from the console and compares them element by element.
 */

using System;
using System.Linq;

using Helper;

public class CompareArrays
{
    public static void Main()
    {
        Console.Write("Please enter the first array numbers count:");
        int firstArrayCount = int.Parse(Console.ReadLine());
        int[] firstArray = Arrays.GenerateRandomArray<int>(firstArrayCount).ToArray();
        Arrays.PrintArray<int>("First array", firstArray.ToList<int>());

        Console.Write("Please enter the second array numbers count:");
        int secondArrayCount = int.Parse(Console.ReadLine());
        int[] secondArray = Arrays.GenerateRandomArray<int>(secondArrayCount).ToArray();
        Arrays.PrintArray<int>("Second array", secondArray.ToList<int>());

        bool equalArrays = CheckArrays(firstArray, secondArray);

        Console.WriteLine("These are two equal arrays: {0}", equalArrays);
    }

    private static bool CheckArrays(int[] firstArray, int[] secondArray)
    {
        bool equalArrays = false;

        if (firstArray.Length == secondArray.Length)
        {
            equalArrays = true;
            for (int i = 0; i < firstArray.Length; i++)
            {
                if (firstArray[i] != secondArray[i])
                {
                    equalArrays = false;
                    break;
                }
            }
        }

        return equalArrays;
    }
}
