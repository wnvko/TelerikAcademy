/*
 * Write a method that counts how many times given number appears in given array. Write a test
 * program to check if the method is workings correctly.
 */

using System;

public class AppearanceCount
{
    public static void Main(string[] args)
    {
        var myClass = new AppearanceCount();
        var myHelperClass = new HelperClass();

        Console.Write("Enter the number of elements in the array: ");
        int elementsCount = int.Parse(Console.ReadLine());

        int[] array = myHelperClass.GenerateRandomArray<int>(elementsCount);
        Console.WriteLine("Random array: ");
        myHelperClass.PrintArray(array);
        Console.WriteLine();

        Console.Write("Enter lookup value: ");
        int lookupValue = int.Parse(Console.ReadLine());

        int repetitions = myClass.CountRepetitions(lookupValue, array);
        Console.WriteLine();
        Console.WriteLine("{0} repeats {1} times", lookupValue, repetitions);
    }

    private int CountRepetitions(int lookupValue, int[] lookupArray)
    {
        int numberOfRepetitions = 0;
        for (int counter = 0; counter < lookupArray.Length; counter++)
        {
            if (lookupArray[counter] == lookupValue)
            {
                numberOfRepetitions++;
            }
        }

        return numberOfRepetitions;
    }
}