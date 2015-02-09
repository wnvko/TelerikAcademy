/*
 * Write a program that reads two integer numbers N and K and an array of N elements from the console.
 * Find in the array those K elements that have maximal sum.
 */

using System;
using System.Linq;

using Helper;

public class MaximalKSum
{
    public static void Main(string[] args)
    {
        Console.Write("Enter the number of elements in the array: ");
        int arrayLenght = int.Parse(Console.ReadLine());
        int[] array = Arrays.GenerateRandomArray<int>(arrayLenght).ToArray();
        Arrays.PrintArray<int>(string.Empty, array.ToList());

        Console.Write("Enter the number of elements in the sum: ");
        int sumLenght = int.Parse(Console.ReadLine());

        Array.Sort(array);
        Array.Reverse(array);
        int maxSum = 0;

        for (int index = 0; index < sumLenght; index++)
        {
            maxSum += array[index];
        }

        Console.WriteLine("The maximal sum of {0} elements is {1}", sumLenght, maxSum);
    }
}
