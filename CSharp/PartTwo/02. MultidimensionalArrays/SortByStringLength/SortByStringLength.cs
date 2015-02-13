/*
 * You are given an array of strings. Write a method that sorts the array by the length of its
 * elements (the number of characters composing them).
 */

using System;
using System.Text;

public class SortByStringLength
{
    private static Random random = new Random();

    public static void Main(string[] args)
    {
        Console.Write("Enter the number of strings in the array: ");
        int numberOfStrings = int.Parse(Console.ReadLine());

        string[] stringArray = GenerateRandomStringArray(numberOfStrings);
        Console.WriteLine("Input array:");
        PrintArray(stringArray);

        Console.WriteLine("\n\nSorted array:");
        SelectionSort(stringArray);
        PrintArray(stringArray);
    }

    private static string[] GenerateRandomStringArray(int arrayLenght)
    {
        string[] randomArray = new string[arrayLenght];

        for (int possition = 0; possition < arrayLenght; possition++)
        {
            int lenght = random.Next(1, 30);
            StringBuilder randomString = new StringBuilder();
            for (int character = 0; character < lenght; character++)
            {
                char nextLeter = (char)random.Next(65, 90);
                randomString.Append(nextLeter);
            }

            randomArray[possition] = randomString.ToString();
        }

        return randomArray;
    }

    private static string[] SelectionSort(string[] inputArray)
    {
        string[] returnArray = inputArray;
        for (int index = 0; index < returnArray.Length; index++)
        {
            for (int check = index + 1; check < returnArray.Length; check++)
            {
                if (returnArray[index].Length > returnArray[check].Length)
                {
                    string tempValue = returnArray[index];
                    returnArray[index] = returnArray[check];
                    returnArray[check] = tempValue;
                }
            }
        }

        return returnArray;
    }

    private static void PrintArray(string[] inputArray)
    {
        for (int possition = 0; possition < inputArray.Length; possition++)
        {
            Console.WriteLine(inputArray[possition]);
        }
    }
}
