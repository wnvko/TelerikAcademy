/*
 * Write a method that counts how many times given number
 * appears in given array. Write a test program to check
 * if the method is working correctly.
 */

namespace SameItemInArray
{
    using System;
    using System.Collections.Generic;
    public class SameItemInArray
    {
        static Random rnd = new Random();
        public static int[] GenerateRandomArray(int numberOfItems)
        {
            int maxNumberInArray = numberOfItems / 3;
            int[] randomArray = new int[numberOfItems];

            for (int counter = 0; counter < numberOfItems; counter++)
            {
                randomArray[counter] = rnd.Next(maxNumberInArray);
            }

            return randomArray;
        }
        public static void PrintArray(int[] inputArray)
        {
            for (int counter = 0; counter < inputArray.Length; counter++)
            {
                Console.Write("{0}\t", inputArray[counter]);
            }
        }

        public static int CountRepetitions(int lookupValue, int[] lookupArray)
        {
            int numberOfRepetitions = 0;
            for (int counter = 0; counter < lookupArray.Length; counter++)
            {
                if (lookupArray[counter] == lookupValue)
                {
                    numberOfRepetitions++;
                }
            }
            return numberOfRepetitions;
        }
        public static void Main()
        {
            Console.Write("Enter the number of elements in the array: ");
            int elementsCount = int.Parse(Console.ReadLine());
            int[] array = GenerateRandomArray(elementsCount);
            Console.WriteLine("Random array: ");
            PrintArray(array);
            Console.WriteLine(new string('-', 30));

            Console.Write("Enter lookup value: ");
            int lookupValue = int.Parse(Console.ReadLine());

            int repetitions = CountRepetitions(lookupValue, array);
            Console.WriteLine(new string('-', 30));
            Console.WriteLine("{0} repeats {1} times", lookupValue, repetitions);
        }
    }
}
