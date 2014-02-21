/*
 * Write a method that return the maximal element in a portion of
 * array of integers starting at given index. Using it write
 * another method that sorts an array in ascending / descending order.
 */

namespace MaxNumberInSubarray
{
    using System;
    class MaxNumberInSubarray
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
        static void Main()
        {
            Console.Write("Enter the lenght of the array: ");
            int arrayLenght = int.Parse(Console.ReadLine());
            int[] array = GenerateRandomArray(arrayLenght);

            Console.Write("Enter start possition: ");
            int startPossition = int.Parse(Console.ReadLine());

            Console.Write("Enter end possition: ");
            int endPossition = int.Parse(Console.ReadLine());
            Console.WriteLine();
            PrintArray(array);
            Console.WriteLine();
            Console.WriteLine(new string('-', 30));

            int maxNumberIndex = FindMaxIntInSubarray(array, startPossition, endPossition);
            Console.WriteLine();
            Console.WriteLine("Max number is {0}", array[maxNumberIndex]);
        }
    }
}