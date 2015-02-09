/*
 * Sorting an array means to arrange its elements in increasing order. Write a program to sort an array.
 * Use the Selection sort algorithm: Find the smallest element, move it at the first position, find the
 * smallest from the rest, move it at the second position, etc.
 */

using System;
using System.Linq;

using Helper;

public class SelectionSort
{
    public static void Main(string[] args)
    {
        Console.Write("Enter the number of elements in the array: ");
        int arrayLenght = int.Parse(Console.ReadLine());
        int[] array = Arrays.GenerateRandomArray<int>(arrayLenght).ToArray();
        Arrays.PrintArray<int>("Initial array", array.ToList());

        for (int index = 0; index < arrayLenght; index++)
        {
            for (int check = index + 1; check < arrayLenght; check++)
            {
                if (array[index] > array[check])
                {
                    int buffer = array[index];
                    array[index] = array[check];
                    array[check] = buffer;
                }
            }
        }

        Arrays.PrintArray<int>("Sorted array", array.ToList());
    }
}
