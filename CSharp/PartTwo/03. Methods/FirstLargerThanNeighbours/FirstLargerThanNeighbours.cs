/*
 * Write a method that returns the index of the first element in array that is larger than its
 * neighbours, or -1, if there’s no such element. Use the method from the previous exercise.
 */

using System;

public class FirstLargerThanNeighbours
{
    public static void Main(string[] args)
    {
        var myClass = new FirstLargerThanNeighbours();
        var myHelpClass = new HelperClass();

        Console.Write("Enter the number of elements in the array: ");
        int elementsCount = int.Parse(Console.ReadLine());
        int[] array = myHelpClass.GenerateRandomArray<int>(elementsCount);
        //array = new int[] { 1, 2, 3, 4, 5 };

        Console.WriteLine("Random array: ");
        myHelpClass.PrintArray(array);

        Console.WriteLine();
        Console.WriteLine(new string('-', 30));

        int result = myClass.CheckNeighbors(array);
        if (result != -1)
        {
            Console.WriteLine("First element bigger than its neighbors is {0} on position {1}.", array[result], result);
        }
        else
        {
            Console.WriteLine("There is no such element in the array!");
        }
    }

    private int CheckNeighbors(int[] inputArray)
    {
        var myLargerThanNeighbor = new LargerThanNeighbours();
        bool result;
        for (int position = 0; position < inputArray.Length; position++)
        {
            result = myLargerThanNeighbor.CheckNeighbors(position, inputArray);
            if (result)
            {
                return position;
            }
        }

        return -1;
    }
}