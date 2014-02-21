namespace SortArrayDescending
{
    using System;
    class SortArrayDescending
    {
        static Random rnd = new Random();
        static int[] GenerateRandomArray(int numberOfItems)
        {
            int maxNumberInArray = numberOfItems * 2;
            int[] randomArray = new int[numberOfItems];

            for (int counter = 0; counter < numberOfItems; counter++)
            {
                randomArray[counter] = rnd.Next(maxNumberInArray);
            }
            return randomArray;
        }
        static void PrintArray(int[] inputArray)
        {
            for (int counter = 0; counter < inputArray.Length; counter++)
            {
                Console.Write("{0}\t", inputArray[counter]);
            }
        }

        static int FindMaxIntInSubarray(int[] inputArray, int startPossition, int endPossition)
        {
            int maxNumber = int.MinValue;
            int maxNumberIndex = startPossition;
            if (startPossition > endPossition || startPossition < 0 || endPossition > inputArray.Length - 1)
            {
                return 0;
            }
            for (int index = startPossition; index <= endPossition; index++)
            {
                if (inputArray[index] > maxNumber)
                {
                    maxNumber = inputArray[index];
                    maxNumberIndex = index;
                }
            }
            return maxNumberIndex;
        }
        static int[] SortDescending(int[] inputArray)
        {
            int[] sortedArray = inputArray;
            for (int index = 0; index < sortedArray.Length; index++)
            {
                int maxIndex = FindMaxIntInSubarray(sortedArray, index, sortedArray.Length - 1);
                int tempValue = sortedArray[maxIndex];
                sortedArray[maxIndex] = sortedArray[index];
                sortedArray[index] = tempValue;
            }
            return sortedArray;
        }
        static void Main()
        {
            Console.Write("Enter the lenght of the array: ");
            int arrayLenght = int.Parse(Console.ReadLine());
            int[] array = GenerateRandomArray(arrayLenght);
            Console.WriteLine();
            PrintArray(array);
            Console.WriteLine();
            Console.WriteLine(new string('-', 30));

            int[] sortedArray = SortDescending(array);
            Console.WriteLine();
            Console.WriteLine("Array sorted descending:");
            PrintArray(sortedArray);
        }
    }
}