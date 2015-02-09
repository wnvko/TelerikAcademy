/*
 * Write a program that finds the maximal sequence of equal elements in an array.
 */

using System;
using System.Linq;

using Helper;

public class MaximalSequence
{
    public static void Main(string[] args)
    {
        Console.Write("Enter the numbers in array: ");
        int arrayCount = int.Parse(Console.ReadLine());
        int[] arrayNumbers = Arrays.GenerateRandomArray<int>(arrayCount, 1, 5).ToArray();
        Arrays.PrintArray<int>(string.Empty, arrayNumbers.ToList());

        int numberOfIterations = 1;
        int bestIteration = 0;
        int startNumber = 0;
        int bestNumber = arrayNumbers[0];

        for (int index = 0; index < arrayCount - 1; index++)
        {
            if (arrayNumbers[index] == arrayNumbers[index + 1])
            {
                numberOfIterations++;

                if (index != arrayCount - 2)
                {
                    continue;
                }
            }

            if (numberOfIterations > bestIteration)
            {
                bestIteration = numberOfIterations;
                startNumber = index + 1 - numberOfIterations;
            }

            numberOfIterations = 1;
        }

        Console.WriteLine("The most long sequence of equal numbers in the array is:");
        for (int index = startNumber; index < bestIteration + startNumber; index++)
        {
            Console.WriteLine(arrayNumbers[index]);
        }
    }
}
