/*
 * We are given an array of integers and a number S. Write a program to find if
 * there exists a subset of the elements of the array that has a sum S.
 * Example:	arr={2, 1, 2, 4, 3, 5, 2, 6}, S=14 -> yes (1+2+5+6)
 */

namespace SubsetOfElementsWithSumS
{
    using System;
    using System.Collections.Generic;

    class SubsetOfElementsWithSumS
    {   
        static void Main()
        {
            //input
            Console.Write("Input the number of elements in the array: ");
            int numberOfElements = int.Parse(Console.ReadLine());

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
                
                subsets.Add(new int[] {inputArray[index]});
                for (int j = 0; j < subsetCount; j++)
                {
                    int[] subsetArray = new int [subsets[j].Length + 1];
                    subsets[j].CopyTo(subsetArray, 0);
                    subsetArray[subsetArray.Length - 1] = inputArray[index];
                    subsets.Add(subsetArray);
                }
            }

            //calculate sum of each combination and print it out if = S

            bool sumExist = false;
            for (int counter = 0; counter < subsets.Count; counter++)
            {
                int subsetSum = 0;
                foreach (int number in subsets[counter])
                {
                    subsetSum += number;
                }

                if (subsetSum == sumToFind)
                {
                    Console.Write("Sum of ");
                    foreach (int number in subsets[counter])
                    {
                        Console.Write("{0}, ",number);
                    }
                    Console.WriteLine("is {0}", sumToFind);
                    sumExist = true;
                }
            }

            //if no subset sums the Sum inform the user
            if (!sumExist)
            {
                Console.WriteLine("There is no subset to sum {0}", sumToFind);
            }
        }
    }
}
