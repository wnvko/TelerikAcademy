/*
 * Write a program that sorts an array of integers using the merge sort algorithm (find it in Wikipedia).
 */

namespace MergeSort
{
    using System;
    using System.Collections.Generic;

    class MergeSortMetod
    {
        static List<int> sortedList = new List<int>();

        static List<int> MergeSort(List<int> listToSort)
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
                MergeSort(leftList);
                leftListBuffer = sortedList;
            }
            else
            {
                leftListBuffer = leftList;
            }

            if (rightList.Count > 1)
            {
                MergeSort(rightList);
                rightListBuffer = sortedList;
            }
            else
            {
                rightListBuffer = rightList;
            }

            sortedList = Merge(leftListBuffer, rightListBuffer);
            return sortedList;
        }

        static List<int> Merge(List<int> leftList, List<int> rightList)
        {
            List<int> mergedLists = new List<int>();
            int leftListIndex = 0;
            int rightListIndex = 0;

            //merge and sort left and right lists
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

            //add the left list items if there are any
            while (leftListIndex < leftList.Count)
            {
                mergedLists.Add(leftList[leftListIndex]);
                leftListIndex++;
            }

            //add the right list items if there are any
            while (rightListIndex < rightList.Count)
            {
                mergedLists.Add(rightList[rightListIndex]);
                rightListIndex++;
            }
            return mergedLists;
        }

        static void Main()
        {
            //input
            Console.Write("Enter the number of elements to sort N: ");
            int N = int.Parse(Console.ReadLine());


            //calculation
            //creates a list of N random numbers from 1 to 100
            List<int> listToSort = new List<int>();
            Random rnd = new Random();
            for (int i = 0; i < N; i++)
            {
                listToSort.Add(rnd.Next(100));
            }

            List<int> sortedList = new List<int>();
            sortedList = MergeSort(listToSort);

            //ouput
            Console.WriteLine("\nUnsorted list");
            foreach (int number in listToSort)
            {
                Console.Write("{0}, ", number);
            }

            Console.WriteLine("\n\nSorted list");
            foreach (int number in sortedList)
            {
                Console.Write("{0}, ", number);
            }
            Console.WriteLine();
        }
    }
}
