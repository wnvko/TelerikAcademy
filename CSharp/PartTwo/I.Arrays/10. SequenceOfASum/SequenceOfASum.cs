/*
 * Write a program that finds in given array of integers
 * a sequence of given sum S (if present).
 * Example: {4, 3, 1, 4, 2, 5, 8}, S=11 -> {4, 2, 5}	
 */


namespace SequenceOfASum
{
    using System;

    class SequenceOfASum
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
            Console.Write("Enter the sum S: ");
            int sumToFind = int.Parse(Console.ReadLine());

            //calculations

            bool noSequence = true;
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
                        noSequence = false;
                        Console.Write("S = {0}", array[index]);
                        for (int i = index+1; i <= check; i++)
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
            
            //ouput
            if (noSequence)
            {
                Console.WriteLine("There is no such sequence in this array!");
            }
        }
    }
}
