/*
 * Write a program that sorts an array of integers using the Merge sort algorithm.
 */

using System;
using System.Collections.Generic;

using Helper;

public class MergeSort
{
    public static void Main()
    {
        Console.Write("Enter the number of elements to sort N: ");
        int elementsCount = int.Parse(Console.ReadLine());
        List<int> listToSort = Arrays.GenerateRandomArray<int>(elementsCount, 1, 100);
        Arrays.PrintArray<int>("Unsorted", listToSort);

        List<int> sortedList = DoMergeSort(listToSort);
        Arrays.PrintArray<int>("Sorted", sortedList);
    }

    private static List<int> DoMergeSort(List<int> listToSort)
    {
        /*
         * MergeSort method takes the input list and separates it into two list with equal length,
         * named left list and right list. Then it checks each new list if it contains more than
         * one element. If so the method recursively calls itself with each list as parameter.
         * If the list is just one element long, the bottom of recursion it is assigned to buffer list.
         * Then this lists are send to Merge method.
         * The returned sorted list will be assigned to buffer list and so on.
         */

        int middleOfList = listToSort.Count / 2;
        List<int> leftList = new List<int>();
        List<int> rightList = new List<int>();
        List<int> leftListBuffer = new List<int>();
        List<int> rightListBuffer = new List<int>();

        for (int index = 0; index < listToSort.Count; index++)
        {
            if (index < middleOfList)
            {
                leftList.Add(listToSort[index]);
            }
            else
            {
                rightList.Add(listToSort[index]);
            }
        }

        if (leftList.Count > 1)
        {
            leftListBuffer = DoMergeSort(leftList);
        }
        else
        {
            leftListBuffer = leftList;
        }

        if (rightList.Count > 1)
        {
            rightListBuffer = DoMergeSort(rightList);
        }
        else
        {
            rightListBuffer = rightList;
        }

        return Merge(leftListBuffer, rightListBuffer);
    }

    private static List<int> Merge(List<int> leftList, List<int> rightList)
    {
        List<int> mergedLists = new List<int>();
        int leftListIndex = 0;
        int rightListIndex = 0;

        while (leftListIndex < leftList.Count && rightListIndex < rightList.Count)
        {
            if (leftList[leftListIndex] < rightList[rightListIndex])
            {
                mergedLists.Add(leftList[leftListIndex]);
                leftListIndex++;
            }
            else
            {
                mergedLists.Add(rightList[rightListIndex]);
                rightListIndex++;
            }
        }

        while (leftListIndex < leftList.Count)
        {
            mergedLists.Add(leftList[leftListIndex]);
            leftListIndex++;
        }

        while (rightListIndex < rightList.Count)
        {
            mergedLists.Add(rightList[rightListIndex]);
            rightListIndex++;
        }

        return mergedLists;
    }
}
