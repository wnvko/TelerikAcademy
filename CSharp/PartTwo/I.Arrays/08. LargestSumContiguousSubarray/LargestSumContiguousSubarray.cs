/*
 * Write a program that finds the sequence of maximal sum in given array.
 * Example:	{2, 3, -6, -1, 2, -1, 6, 4, -8, 8} -> {2, -1, 6, 4}
 * Can you do it with only one loop (with single scan through the elements of the array)?
 * 
 * Solved with the help of Kadane’s Algorithm - http://www.geeksforgeeks.org/largest-sum-contiguous-subarray/
 */

namespace LargestSumContiguousSubarray
{
    using System;

    class LargestSumContiguousSubarray
    {
        static void Main(string[] args)
        {
            //input
            Console.Write("Enter the number of elements in the array: ");
            int arrayLenght = int.Parse(Console.ReadLine());
            int[] array = new int[arrayLenght];

            for (int index = 0; index < array.Length; index++)
            {
                Console.Write("Enter element {0} = ", (index + 1));
                array[index] = int.Parse(Console.ReadLine());
            }

            //calculations

            //Kadane’s Algorithm

            int endIndex = 0;
            int maxSum = 0;
            bool negativeArray = true; //check if all values are negative
            int biggestNegative = int.MinValue; //stores the biggest negative value. In case of all values are negative this will be the max sum
            
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

            //ouput
            Console.WriteLine("The largest sum of contiguous subarray is {0}", maxSum);
        }
    }
}
