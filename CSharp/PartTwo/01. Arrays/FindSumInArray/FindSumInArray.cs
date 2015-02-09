/*
 * Write a program that finds in given array of integers a sequence of given sum S (if present).
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Helper;

public class FindSumInArray
{
    public static void Main(string[] args)
    {
        Console.Write("Enter the number of elements in the array: ");
        int arrayLenght = int.Parse(Console.ReadLine());
        int[] array = Arrays.GenerateRandomArray<int>(arrayLenght).ToArray();
        Arrays.PrintArray<int>(string.Empty, array.ToList());

        Console.Write("Enter the sum S: ");
        int sumToFind = int.Parse(Console.ReadLine());

        bool sequenceDoNotExist = true;
        for (int index = 0; index < array.Length; index++)
        {
            int currentSum = array[index];
            if (currentSum == sumToFind)
            {
                Console.WriteLine("S = {0}", currentSum);
                continue;
            }

            for (int check = index + 1; check < array.Length; check++)
            {
                currentSum += array[check];
                if (currentSum == sumToFind)
                {
                    sequenceDoNotExist = false;
                    Console.Write("S = {0}", array[index]);
                    for (int i = index + 1; i <= check; i++)
                    {
                        Console.Write(" + {0}", array[i]);
                    }

                    Console.WriteLine();
                }

                if (currentSum > sumToFind)
                {
                    break;
                }
            }
        }

        if (sequenceDoNotExist)
        {
            Console.WriteLine("There is no such sequence in this array!");
        }
    }
}
