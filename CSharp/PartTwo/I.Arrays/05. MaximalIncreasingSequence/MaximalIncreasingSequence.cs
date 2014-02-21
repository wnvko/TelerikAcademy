/*
 * Write a program that finds the maximal increasing sequence in an array.
 * Example: {3, 2, 3, 4, 2, 2, 4} -> {2, 3, 4}.
 */

namespace MaximalIncreasingSequence
{
    using System;

    class MaximalIncreasingSequence
    {
        static void Main()
        {
            //input
            Console.Write("Enter the numbers in array: ");
            int arrayCount = int.Parse(Console.ReadLine());
            int[] arrayNumbers = new int[arrayCount];

            for (int index = 0; index < arrayCount; index++)
            {
                Console.Write("Enter number on position {0}: ", index + 1);
                arrayNumbers[index] = int.Parse(Console.ReadLine());
            }

            //calculation
            int numberOfIterations = 1;
            int bestIteration = 0;
            int startNumber = 0;
            int bestNumber = 0;

            for (int index = 0; index < arrayCount - 1; index++)
            {
                if (arrayNumbers[index] < arrayNumbers[index + 1])
                {
                    startNumber = index + 1 - numberOfIterations;
                    numberOfIterations++;
                    continue;
                }
                if (numberOfIterations > bestIteration)
                {
                    bestIteration = numberOfIterations;
                    bestNumber = startNumber;
                    numberOfIterations = 1;
                }
            }

            //output
            Console.WriteLine("The most long sequence of increasing numbers in the array is:");
            for (int index = 0; index < bestIteration; index++)
            {
                Console.WriteLine(arrayNumbers[bestNumber + index]);
            }
        }
    }
}
