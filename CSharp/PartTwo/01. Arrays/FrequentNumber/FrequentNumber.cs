/*
 * Write a program that finds the most frequent number in an array.
 */

using System;
using System.Collections.Generic;
using System.Linq;

using Helper;

public class FrequentNumber
{
    public static void Main(string[] args)
    {
        Console.Write("Enter the number of elements in the array: ");
        int arrayLenght = int.Parse(Console.ReadLine());
        int[] array = Arrays.GenerateRandomArray<int>(arrayLenght, 1, 5).ToArray();
        Arrays.PrintArray<int>(string.Empty, array.ToList());

        Dictionary<int, int> iterations = new Dictionary<int, int>();
        for (int index = 0; index < array.Length; index++)
        {
            if (!iterations.ContainsKey(array[index]))
            {
                iterations[array[index]] = 0;
            }

            iterations[array[index]]++;
        }

        int repeatCount = iterations.Max(num => num.Value);
        int mostFrequentNumber = iterations.FirstOrDefault(num => num.Value == repeatCount).Key;

        Console.WriteLine("The most frequent number is {0} - {1} times", mostFrequentNumber, repeatCount);
    }
}
