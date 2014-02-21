/*
 * Write a program that reads two integer numbers N and K
 * and an array of N elements from the console.
 * Find in the array those K elements that have maximal sum.
 */


namespace MaximalSum
{
    using System;

    class MaximalSum
    {
        static void Main()
        {
            //input
            Console.Write("Enter the number of elements in the array: ");
            int arrayLenght = int.Parse(Console.ReadLine());

            Console.Write("Enter the number of elements in the sum: ");
            int sumLenght = int.Parse(Console.ReadLine());

            int[] array = new int[arrayLenght];

            for (int index = 0; index < arrayLenght; index++)
            {
                Console.Write("Enter element {0} = ", (index + 1));
                array[index] = int.Parse(Console.ReadLine());
            }

            //calculations
            //sort the array
            for (int index = 0; index < arrayLenght; index++)
            {
                for (int check = index+1; check < arrayLenght; check++)
                {
                    if (array[index] < array[check])
                    {
                        int buffer = array[index];
                        array[index] = array[check];
                        array[check] = buffer;
                    }
                }
            }
            int maxSum = 0;

            for (int index = 0; index < sumLenght; index++)
            {
                maxSum += array[index];
            }
            
            //ouput
            Console.WriteLine("The maximal sum of {0} elements is {1}", sumLenght, maxSum);
        }
    }
}
