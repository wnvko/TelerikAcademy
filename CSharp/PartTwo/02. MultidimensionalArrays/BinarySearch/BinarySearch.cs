/*
 * Write a program, that reads from the console an array of N integers and an integer K, sorts the
 * array and using the method Array.BinSearch() finds the largest number in the array which is ≤ K.
 */

using System;

public static class BinarySearch
{
    private static Random random = new Random();

    public static void Main(string[] args)
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

        int[] sortedArray = BinarySearch.SelectionSort<int>(lookUpArray);

        Console.WriteLine("\nSorted array:");
        PrintArray(sortedArray);

        Console.WriteLine(new string('-', 74));
        Console.WriteLine();

        int possition = Array.BinarySearch(lookUpArray, lookUpNumber);
        if (possition >= 0)
        {
            Console.WriteLine("The largest number less or equal to {0} is {1},", lookUpNumber, sortedArray[possition]);
            Console.WriteLine("on position {0} in the sorted array.", possition + 1);
        }
        else
        {
            possition = ((-1) * possition) - 2;
            Console.WriteLine("The largest number less or equal to {0} is {1},", lookUpNumber, sortedArray[possition]);
            Console.WriteLine("on position {0} in the sorted array.", possition + 1);
        }
    }

    private static int[] GenerateRandomArray(int arrayLenght)
    {
        int maxNumberInMatrix = 100;
        int[] randomArray = new int[arrayLenght];

        for (int possition = 0; possition < arrayLenght; possition++)
        {
            randomArray[possition] = random.Next(maxNumberInMatrix);
        }

        return randomArray;
    }

    private static void PrintArray(int[] inputArray)
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

    private static T[] SelectionSort<T>(this T[] inputArray) where T : IComparable
    {
        T[] returnArray = inputArray;
        for (int index = 0; index < returnArray.Length; index++)
        {
            for (int check = index + 1; check < returnArray.Length; check++)
            {
                if (returnArray[index].CompareTo(returnArray[check]) > 0)
                {
                    T tempValue = returnArray[index];
                    returnArray[index] = returnArray[check];
                    returnArray[check] = tempValue;
                }
            }
        }

        return returnArray;
    }
}
