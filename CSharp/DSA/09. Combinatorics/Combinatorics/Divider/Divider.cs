// download problem from here http://downloads.academy.telerik.com/svn/algo-academy/2012-10-Combinatorics/All%20problems/Problem%203.zip
using System;
using System.Collections.Generic;
using System.Linq;

public class Divider
{
    private static HashSet<int> permutations = new HashSet<int>();

    public static void Main()
    {
        int numbersCount = int.Parse(Console.ReadLine());
        int[] numbers = new int[numbersCount];

        for (int i = 0; i < numbersCount; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }

        Array.Sort(numbers);

        GetPemutations(numbers, 0, numbers.Length);
        int answer = GetMinDivider(permutations);
        Console.WriteLine(answer);
    }

    private static int GetMinDivider(HashSet<int> permutations)
    {
        int minDividersCount = int.MaxValue;
        int answer = 0;

        foreach (var number in permutations)
        {
            int maxIteration = number / 2 + 1;
            int currentDividersCount = 0;

            for (int i = 2; i < maxIteration; i++)
            {
                if (number % i == 0)
                {
                    currentDividersCount++;
                }
            }

            if (currentDividersCount < minDividersCount)
            {
                minDividersCount = currentDividersCount;
                answer = number;
            }
        }

        return answer;
    }

    private static void GetPemutations(int[] arr, int start, int n)
    {
        permutations.Add(int.Parse(string.Join("", arr.Select(m => m))));

        for (int left = n - 2; left >= start; left--)
        {
            for (int right = left + 1; right < n; right++)
            {
                if (arr[left] != arr[right])
                {
                    Swap(ref arr[left], ref arr[right]);
                    GetPemutations(arr, left + 1, n);
                }

            }

            int firstElement = arr[left];
            for (int i = left; i < n - 1; i++)
            {
                arr[i] = arr[i + 1];
            }

            arr[n - 1] = firstElement;
        }
    }

    private static void Swap(ref int first, ref int second)
    {
        int oldFirst = first;
        first = second;
        second = oldFirst;
    }
}