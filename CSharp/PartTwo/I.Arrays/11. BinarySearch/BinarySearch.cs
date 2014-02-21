/*
 * Write a program that finds the index of given element in a sorted
 * array of integers by using the binary search algorithm (find it in Wikipedia).
 */

namespace BinarySearch
{
    using System;

    class BinarySearch
    {
        static void Main()
        {
            //input
            Console.Write("Enter the value of element to be found (0 - 1998): ");
            int valueToFind = int.Parse(Console.ReadLine());
            int[] sortedArray = new int[1000];
            for (int index = 0; index < sortedArray.Length; index++)
            {
                sortedArray[index] = index * 2;
            }

            //calculations
            //Binary Search Algorithm
            int upperIndex = sortedArray.Length - 1;
            int lowerIndex = 0;
            int indexToCheck = 0;

            while (lowerIndex <= upperIndex)
            {
                indexToCheck = (upperIndex - lowerIndex) / 2 + lowerIndex;
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

            //output
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
}