/*
 * Write a program that finds the sequence of maximal sum in given array.
 */

using System;
using System.Linq;

using Helper;

public class MaximalSum
{
    public static void Main(string[] args)
    {
        Console.Write("Enter the number of elements in the array: ");
        int arrayLenght = int.Parse(Console.ReadLine());
        int[] array = Arrays.GenerateRandomArray<int>(arrayLenght, -50, 50).ToArray();
        Arrays.PrintArray<int>(string.Empty, array.ToList());

        // Kadane’s Algorithm
        int endIndex = 0;
        int maxSum = 0;
        bool negativeArray = true;
        int biggestNegative = int.MinValue;

        for (int index = 0; index < array.Length; index++)
        {
            endIndex += array[index];
            if (endIndex < 0)
            {
                endIndex = 0;
            }

            if (endIndex > maxSum)
            {
                maxSum = endIndex;
            }

            if (array[index] > 0)
            {
                negativeArray = false;
            }
            else
            {
                if (array[index] > biggestNegative)
                {
                    biggestNegative = array[index];
                }
            }
        }

        if (negativeArray)
        {
            maxSum = biggestNegative;
        }

        Console.WriteLine("The largest sum of contiguous subarray is {0}", maxSum);
    }
}
