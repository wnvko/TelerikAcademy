/*
 * Write a method that return the maximal element in a portion of array of integers starting at
 * given index. Using it write another method that sorts an array in ascending / descending order.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class SortingArray
{
    public static void Main(string[] args)
    {
        var myClass = new SortingArray();
        var myHelperClass = new HelperClass();

        Console.Write("Enter the length of the array: ");
        int arrayLenght = int.Parse(Console.ReadLine());
        int[] array = myHelperClass.GenerateRandomArray<int>(arrayLenght, arrayLenght * 2);

        Console.Write("Enter start position: ");
        int startPosition = int.Parse(Console.ReadLine());

        Console.Write("Enter end position: ");
        int endPosition = int.Parse(Console.ReadLine());

        Console.WriteLine();
        myHelperClass.PrintArray(array);
        Console.WriteLine();

        int maxNumberIndex = myClass.FindMaxIntInSubarray(array, startPosition, endPosition);
        Console.WriteLine("Max number is {0}", array[maxNumberIndex]);

        int[] sortedArray = myClass.SortArray(array);
        Console.WriteLine();
        Console.WriteLine("Array sorted ascending:");
        myHelperClass.PrintArray(sortedArray);
        Console.WriteLine();

        sortedArray = myClass.SortArray(array, false);
        Console.WriteLine();
        Console.WriteLine("Array sorted descending:");
        myHelperClass.PrintArray(sortedArray);
        Console.WriteLine();
    }

    private int FindMaxIntInSubarray(int[] inputArray, int startPosition, int endPosition)
    {
        int maxNumber = int.MinValue;
        int maxNumberIndex = startPosition;
        if (startPosition > endPosition || startPosition < 0 || endPosition > inputArray.Length - 1)
        {
            return -1;
        }

        for (int index = startPosition; index <= endPosition; index++)
        {
            if (inputArray[index] > maxNumber)
            {
                maxNumber = inputArray[index];
                maxNumberIndex = index;
            }
        }

        return maxNumberIndex;
    }

    private int[] SortArray(int[] inputArray, bool ascending = true)
    {
        int[] sortedArray = inputArray;
        if (ascending)
        {
            for (int index = inputArray.Length - 1; index >= 0; index--)
            {
                int maxIndex = this.FindMaxIntInSubarray(sortedArray, 0, index);
                int oldValue = sortedArray[maxIndex];
                sortedArray[maxIndex] = sortedArray[index];
                sortedArray[index] = oldValue;
            }
        }
        else
        {
            for (int index = 0; index < sortedArray.Length; index++)
            {
                int maxIndex = this.FindMaxIntInSubarray(sortedArray, index, sortedArray.Length - 1);
                int tempValue = sortedArray[maxIndex];
                sortedArray[maxIndex] = sortedArray[index];
                sortedArray[index] = tempValue;
            }
        }

        return sortedArray;
    }
}
