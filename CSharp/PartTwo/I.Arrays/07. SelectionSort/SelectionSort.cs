/*
 * Sorting an array means to arrange its elements in increasing order.
 * Write a program to sort an array. Use the "selection sort" algorithm:
 * Find the smallest element, move it at the first position,
 * find the smallest from the rest, move it at the second position, etc.
 */

namespace SelectionSort
{
    using System;

    class SelectionSort
    {
        static void Main()
        {
            //input
            Console.Write("Enter the number of elements in the array: ");
            int arrayLenght = int.Parse(Console.ReadLine());
            int[] array = new int[arrayLenght];

            for (int index = 0; index < arrayLenght; index++)
            {
                Console.Write("Enter element {0} = ", (index + 1));
                array[index] = int.Parse(Console.ReadLine());
            }

            //calculations
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
            
            //ouput
            Console.WriteLine("Sorted array:");
            foreach (int number in array)
            {
                Console.WriteLine(number);
            }
        }
    }
}