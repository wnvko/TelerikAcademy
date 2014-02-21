/*
 * Write a program that sorts an array of strings using the quick sort algorithm (find it in Wikipedia).
 */


namespace QuicksortMethod
{
    using System;
    using System.Collections.Generic;

    class QuicksortMethod
    {
        static List<int> QuickSort(List<int> listToSort, int lenghtOfList)
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
                leftListTemp = QuickSort(leftList, placeToUse);
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
                rightListTemp = QuickSort(rightList, lenghtOfList - placeToUse - 1);
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

        static List<int> SwapTwoElements(List<int> listToSwap, int elementA, int elementB)
        {
            int temp = listToSwap[elementA];
            listToSwap[elementA] = listToSwap[elementB];
            listToSwap[elementB] = temp;

            return listToSwap;
        }

        static void Main(string[] args)
        {
            //input
            Console.Write("Enter the number of elements to sort N: ");
            int N = int.Parse(Console.ReadLine());


            //calculation
            //creates a list of N random numbers from 1 to 100
            List<int> listToSort = new List<int>() { 10, 8, 6, 9, 12, 1, 16 };
            Random rnd = new Random();
            for (int i = 0; i < N; i++)
            {
                listToSort.Add(rnd.Next(100));
            }

            List<int> sortedList = new List<int>();
            int listLenght = listToSort.Count;
            sortedList = QuickSort(listToSort, listLenght);

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