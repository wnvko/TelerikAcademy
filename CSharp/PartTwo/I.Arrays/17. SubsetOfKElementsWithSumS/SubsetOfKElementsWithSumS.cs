/*
 *  Write a program that reads three integer numbers N, K and S and
 *  an array of N elements from the console. Find in the array a subset
 *  of K elements that have sum S or indicate about its absence.
 */

namespace SubsetOfKElementsWithSumS
{
    using System;
    using System.Collections.Generic;

    class SubsetOfKElementsWithSumS
    {
        static void Main()
        {
            //input
            Console.Write("Input the number of elements in the array: ");
            int numberOfElements = int.Parse(Console.ReadLine());

            Console.Write("Input the nember of elements K: ");
            int elementsToSum = int.Parse(Console.ReadLine());

            Console.Write("Input the the sum to find S: ");
            int sumToFind = int.Parse(Console.ReadLine());

            int[] inputArray = new int[numberOfElements];
            for (int index = 0; index < numberOfElements; index++)
            {
                Console.Write("Element {0} = ", index + 1);
                inputArray[index] = int.Parse(Console.ReadLine());
            }

            //calculations

            //create list of arrays containing each combination of input numbers
            List<int[]> subsets = new List<int[]>();

            for (int index = 0; index < inputArray.Length; index++)
            {
                int subsetCount = subsets.Count;

                subsets.Add(new int[] { inputArray[index] });
                for (int j = 0; j < subsetCount; j++)
                {
                    int[] subsetArray = new int[subsets[j].Length + 1];
                    subsets[j].CopyTo(subsetArray, 0);
                    subsetArray[subsetArray.Length - 1] = inputArray[index];
                    subsets.Add(subsetArray);
                }
            }

            //calculate sum of each combination and print it out if = S

            bool sumExist = false;
            for (int counter = 0; counter < subsets.Count; counter++)
            {
                int lenghtOfArray = subsets[counter].Length;
                int subsetSum = 0;
                foreach (int number in subsets[counter])
                {
                    subsetSum += number;
                }

                if (subsetSum == sumToFind && lenghtOfArray==elementsToSum)
                {
                    Console.Write("Sum of ");
                    foreach (int number in subsets[counter])
                    {
                        Console.Write("{0}, ", number);
                    }
                    Console.WriteLine("is {0}", sumToFind);
                    sumExist = true;
                }
            }

            //if no subset sums the Sum inform the user
            if (!sumExist)
            {
                Console.WriteLine("There is no subset of {0} elements to sum {1}", elementsToSum, sumToFind);
            }
        }
    }
}
