/*
 * Write a program that sorts an array of strings using the Quick sort algorithm.
 */

using System;
using System.Collections.Generic;

using Helper;

public class QuickSort
{
    public static void Main(string[] args)
    {
        Console.Write("Enter the number of elements to sort N: ");
        int elementsCount = int.Parse(Console.ReadLine());
        List<int> listToSort = Arrays.GenerateRandomArray<int>(elementsCount);
        Arrays.PrintArray<int>("Unsorted", listToSort);

        List<int> sortedList = QuickSortMethod(listToSort, elementsCount);
        Arrays.PrintArray<int>("Sorted", sortedList);
    }

    private static List<int> QuickSortMethod(List<int> listToSort, int lenghtOfList)
    {
        List<int> sortedList = new List<int>();
        int middleOfList = lenghtOfList / 2;
        int pivotValue = listToSort[middleOfList];
        int placeToUse = 0;

        SwapTwoElements(listToSort, middleOfList, lenghtOfList - 1);

        for (int index = 0; index < lenghtOfList - 1; index++)
        {
            if (listToSort[index] <= pivotValue)
            {
                SwapTwoElements(listToSort, index, placeToUse);
                placeToUse++;
            }
        }

        List<int> leftList = new List<int>();
        List<int> rightList = new List<int>();
        List<int> leftListTemp = new List<int>();
        List<int> rightListTemp = new List<int>();
        SwapTwoElements(listToSort, placeToUse, lenghtOfList - 1);

        for (int index = 0; index < placeToUse; index++)
        {
            leftList.Add(listToSort[index]);
        }

        if (leftList.Count > 1)
        {
            leftListTemp = QuickSortMethod(leftList, placeToUse);
        }
        else
        {
            leftListTemp = leftList;
        }

        for (int index = placeToUse + 1; index < lenghtOfList; index++)
        {
            rightList.Add(listToSort[index]);
        }

        if (rightList.Count > 1)
        {
            rightListTemp = QuickSortMethod(rightList, lenghtOfList - placeToUse - 1);
        }
        else
        {
            rightListTemp = rightList;
        }

        sortedList.AddRange(leftListTemp);
        sortedList.Add(pivotValue);
        sortedList.AddRange(rightListTemp);
        return sortedList;
    }

    private static List<int> SwapTwoElements(List<int> listToSwap, int elementA, int elementB)
    {
        int oldValue = listToSwap[elementA];
        listToSwap[elementA] = listToSwap[elementB];
        listToSwap[elementB] = oldValue;

        return listToSwap;
    }
}
