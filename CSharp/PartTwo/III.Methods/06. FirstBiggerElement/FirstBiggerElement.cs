/*
 * Write a method that returns the index of the first element in
 * array that is bigger than its neighbors, or -1, if there’s no such element.
 * -Use the method from the previous exercise.
 */

namespace FirstBiggerElement
{
    using System;
    class FirstBiggerElement
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
        static int CheckNeighbors(int possition, int[] inputArray)
        {
            if (possition < 0 || possition >= inputArray.Length)
            {
                return -1;
            }
            if (possition == 0 || possition == inputArray.Length - 1)
            {
                return -1;
            }
            if (inputArray[possition] > inputArray[possition - 1] && inputArray[possition] > inputArray[possition + 1])
            {
                return possition;
            }
            else
            {
                return -1;
            }
        }

        static void Main(string[] args)
        {
            Console.Write("Enter the number of elements in the array: ");
            int elementsCount = int.Parse(Console.ReadLine());
            int[] array = GenerateRandomArray(elementsCount);
            Console.WriteLine("Random array: ");
            PrintArray(array);
            Console.WriteLine();
            Console.WriteLine(new string('-', 30));
            
            Console.Write("");
            int result = 0;
            for (int counter = 0; counter < array.Length; counter++)
            {
                result = CheckNeighbors(counter, array);
                if (result != -1)
                {
                    break;
                }
            }

            if (result != -1)
            {
                Console.WriteLine("First element bigger than its neighbors is {0} on possition {1}.", array[result], result);
            }
            else
            {
                Console.WriteLine("There is no such element in the array!");
            }
        }
    }
}