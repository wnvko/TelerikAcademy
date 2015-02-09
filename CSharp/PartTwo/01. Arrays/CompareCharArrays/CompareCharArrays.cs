/*
 * Write a program that compares two char arrays lexicographically (letter by letter).
 */

using System;
using System.Linq;

using Helper;

public class CompareCharArrays
{
    public enum Comparer
    {
        Equal = 0,
        First = 1,
        Second = 2,
    }

    public static void Main(string[] args)
    {
        Console.Write("Please enter the first array numbers count:");
        int firstArrayCount = int.Parse(Console.ReadLine());
        char[] firstArray = Arrays.GenerateRandomArray<char>(firstArrayCount, (int)'a', (int)'z').ToArray();
        Arrays.PrintArray<char>("First array", firstArray.ToList<char>());

        Console.Write("Please enter the second array numbers count:");
        int secondArrayCount = int.Parse(Console.ReadLine());
        char[] secondArray = Arrays.GenerateRandomArray<char>(secondArrayCount, (int)'a', (int)'z').ToArray();
        Arrays.PrintArray<char>("Second array", secondArray.ToList<char>());

        CheckArrays(firstArray, secondArray);
    }

    private static void CheckArrays(char[] firstArray, char[] secondArray)
    {
        int shortestArrayLenght = int.MaxValue;
        Comparer first = Comparer.Equal;

        if (firstArray.Length > secondArray.Length)
        {
            shortestArrayLenght = secondArray.Length;
        }
        else
        {
            shortestArrayLenght = firstArray.Length;
        }

        for (int letter = 0; letter < shortestArrayLenght; letter++)
        {
            if (firstArray[letter] < secondArray[letter])
            {
                first = Comparer.First;
                break;
            }
            else if (firstArray[letter] > secondArray[letter])
            {
                first = Comparer.Second;
                break;
            }
        }

        switch (first)
        {
            case Comparer.Equal:
                if (firstArray.Length > secondArray.Length)
                {
                    Console.WriteLine("Second array is first");
                }
                else if (firstArray.Length < secondArray.Length)
                {
                    Console.WriteLine("First array is first");
                }
                else
                {
                    Console.WriteLine("These are two equal arrays");
                }

                break;
            case Comparer.First:
                Console.WriteLine("First array is first");
                break;
            case Comparer.Second:
                Console.WriteLine("Second array is first");
                break;
            default:
                break;
        }
    }
}
