/*
 * Write a program that finds the index of given element in a sorted array of integers by using the Binary search algorithm.
 */

using System;
using System.Linq;

using Helper;

public class BinarySearch
{
    public static void Main(string[] args)
    {
        Console.Write("Enter the value of element to be found (0 - 2 000): ");
        int valueToFind = int.Parse(Console.ReadLine());
        int[] sortedArray = Arrays.GenerateRandomArray<int>(100, 0, 2000).ToArray();
        Array.Sort(sortedArray);
        Arrays.PrintArray<int>(string.Empty, sortedArray.ToList());

        int upperIndex = sortedArray.Length - 1;
        int lowerIndex = 0;
        int indexToCheck = 0;

        while (lowerIndex <= upperIndex)
        {
            indexToCheck = ((upperIndex - lowerIndex) / 2) + lowerIndex;
            if (valueToFind == sortedArray[indexToCheck])
            {
                break;
            }
            else if (valueToFind > sortedArray[indexToCheck])
            {
                lowerIndex = indexToCheck + 1;
            }
            else if (valueToFind < sortedArray[indexToCheck])
            {
                upperIndex = indexToCheck - 1;
            }
        }

        if (lowerIndex <= upperIndex)
        {
            Console.WriteLine("The value of {0} element is {1}", indexToCheck, sortedArray[indexToCheck]);
        }
        else
        {
            Console.WriteLine("There is no element with value of {0}", valueToFind);
        }
    }
}
