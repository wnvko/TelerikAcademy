using System;

public class Permutations
{
    private static int[] array;
    private static int elementsCount;

    public static void Main()
    {
        elementsCount = GetInput();
        array = new int[elementsCount];
        FillArray(array);
        Generate(array, 0);
    }

    private static void Generate(int[] array, int k)
    {
        if (k >= array.Length)
        {
            PrintResult(array);
        }
        else
        {
            Generate(array, k + 1);
            for (int i = k + 1; i < array.Length; i++)
            {
                Swap(ref array[k], ref array[i]);
                Generate(array, k + 1);
                Swap(ref array[k], ref array[i]);
            }
        }

        return;
    }

    private static void FillArray(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = i + 1;
        }
    }

    private static void Swap(ref int first, ref int second)
    {
        int oldFirst = first;
        first = second;
        second = oldFirst;
    }

    private static void PrintResult(int[] array)
    {
        foreach (var num in array)
        {
            Console.Write(num + "\t");
        }

        Console.WriteLine();
    }

    private static int GetInput()
    {
        Console.Write("Please enter number of loops (>10 is not ok): ");
        int numberOfLoops = int.Parse(Console.ReadLine());
        return Math.Min(10, numberOfLoops);
    }
}
