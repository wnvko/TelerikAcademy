/*
 * Write a program that finds the most frequent number in an array.
 * Example:	{4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3} -> 4 (5 times)
 */


namespace MostFrequentNumber
{
    using System;
    using System.Collections.Generic;

    class MostFrequentNumber
    {
        static void Main()
        {
            //input
            Console.Write("Enter the number of elements in the array: ");
            int arrayLenght = int.Parse(Console.ReadLine());
            int[] array = new int[arrayLenght];

            for (int index = 0; index < array.Length; index++)
            {
                Console.Write("Enter element {0} = ", (index + 1));
                array[index] = int.Parse(Console.ReadLine());
            }

            //calculations

            List<int> differentItems = new List<int>();
            List<int> numberOfIterations = new List<int>();
            int maxIteration = 0;
            int mostFrequentNumber = 0;

            differentItems.Add(array[0]);
            numberOfIterations.Add(1);

            for (int index = 1; index < array.Length; index++)
			{
                for (int count = 0; count < differentItems.Count; count++)
			    {
                    if (array[index] == differentItems[count])
                    {
                        numberOfIterations[count]++;
                    }
                    else
                    {
                        differentItems.Add(array[index]);
                        numberOfIterations.Add(1);
                    }
                }
			}
            for (int count = 0; count < numberOfIterations.Count; count++)
			{
                if (maxIteration < numberOfIterations[count])
                {
                    maxIteration = numberOfIterations[count];
                    mostFrequentNumber = differentItems[count];
                }
			}

            //ouput
            Console.WriteLine("The most frequent number is {0} - {1} times", mostFrequentNumber, maxIteration);
        }
    }
}
