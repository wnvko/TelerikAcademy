/*Write a program, that reads from the console an array of N integers
 * and an integer K, sorts the array and using the method Array.BinSearch()
 * finds the largest number in the array which is ≤ K.
 */

namespace BinSearch
{
    using System;
    using System.Collections.Generic;
    class BinSearch
    {
        static Random rnd = new Random();
        static int[] GenerateRandomArray(int arrayLenght)
        {
            int maxNumberInMatrix = 100;
            int[] randomArray = new int[arrayLenght];

            for (int possition = 0; possition < arrayLenght; possition++)
            {
                randomArray[possition] = rnd.Next(maxNumberInMatrix);
            }

            return randomArray;
        }

        static void PrintArray(int[] inputArray)
        {
            for (int possition = 0; possition < inputArray.Length; possition++)
            {
                if (possition % 10 == 0 && possition > 0)
                {
                    Console.WriteLine();
                }
                Console.Write("{0}\t", inputArray[possition]);
            }
        }

        static int[] SelectionSort(int[] inputArray)
        {
            int[] returnArray = inputArray;
            for (int index = 0; index < returnArray.Length; index++)
            {
                for (int check = index + 1; check < returnArray.Length; check++)
                {
                    if (returnArray[index] > returnArray[check])
                    {
                        int tempValue = returnArray[index];
                        returnArray[index] = returnArray[check];
                        returnArray[check] = tempValue;
                    }
                }
            }
            return returnArray;
        }
        static void Main()
        {
            Console.Write("Enter the size of the array N: ");
            int arrayLenght = int.Parse(Console.ReadLine());
            Console.Write("Enter number to find K: ");
            int lookUpNumber = int.Parse(Console.ReadLine());

            int[] lookUpArray = GenerateRandomArray(arrayLenght);

            Console.WriteLine("\nStart array:");
            PrintArray(lookUpArray);
            Console.WriteLine();
            Console.WriteLine(new string('-', 74));
            Console.WriteLine();

            int[] sortedArray = SelectionSort(lookUpArray);

            Console.WriteLine("\nSorted array:");
            PrintArray(sortedArray);
            Console.WriteLine(new string('-', 74));
            Console.WriteLine();

            int possition = Array.BinarySearch(lookUpArray, lookUpNumber);
            if (possition >= 0)
            {
                Console.WriteLine("The largest number less or equal to {0} is {1},", lookUpNumber, sortedArray[possition]);
                Console.WriteLine("on possition {0} in the sorted array.", possition+1);
            }
            else
            {
                possition = (-1) * possition - 2;
                Console.WriteLine("The largest number less or equal to {0} is {1},", lookUpNumber, sortedArray[possition]);
                Console.WriteLine("on possition {0} in the sorted array.", possition+1);
            }
        }
    }
}
