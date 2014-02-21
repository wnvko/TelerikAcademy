/*
 * Write a method that checks if the element at given position in
 * given array of integers is bigger than its two neighbors
 * (when such exist).
 */

namespace CheckNeighborsInArray
{
    using System;
    class CheckNeighborsInArray
    {
        static Random rnd = new Random();
        static int[] GenerateRandomArray(int numberOfItems)
        {
            int maxNumberInArray = numberOfItems / 3;
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
        static void CheckNeighbors(int possition, int[] inputArray)
        {
            if (possition < 0 || possition >= inputArray.Length)
            {
                Console.WriteLine("This possition is outside array!");
                return;
            }
            if (possition == 0 || possition == inputArray.Length - 1)
            {
                Console.WriteLine("This element has only one neightbor!");
                return;
            }
            if (inputArray[possition] > inputArray[possition - 1] && inputArray[possition] > inputArray[possition + 1])
            {
                Console.WriteLine("Element at possition {0} ({1}) is bigger than it's neighbors ({2} and {3})", possition, inputArray[possition], inputArray[possition - 1], inputArray[possition + 1]);
            }
            else
            {
                Console.WriteLine("Element at possition {0} ({1}) is not bigger than it's neighbors ({2} and {3})", possition, inputArray[possition], inputArray[possition - 1], inputArray[possition + 1]);
            }
        }

        static void Main()
        {
            Console.Write("Enter the number of elements in the array: ");
            int elementsCount = int.Parse(Console.ReadLine());
            int[] array = GenerateRandomArray(elementsCount);
            Console.WriteLine("Random array: ");
            PrintArray(array);
            Console.WriteLine(new string('-', 30));

            Console.Write("Enter lookup possition: ");
            int lookupPossition = int.Parse(Console.ReadLine());
            CheckNeighbors(lookupPossition, array);
        }
    }
}
