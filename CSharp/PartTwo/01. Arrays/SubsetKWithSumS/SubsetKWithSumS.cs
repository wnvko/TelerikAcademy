/*
 * Write a program that reads three integer numbers N, K and S and an array of N elements from the console.
 * Find in the array a subset of K elements that have sum S or indicate about its absence.
 */

using System;
using System.Linq;
using System.Text;

using Helper;

public class SubsetKWithSumS
{
    public static void Main(string[] args)
    {
        Console.Write("Input the number of elements in the array: ");
        int numberOfElements = int.Parse(Console.ReadLine());

        int[] inputArray = Arrays.GenerateRandomArray<int>(numberOfElements).ToArray();
        Arrays.PrintArray<int>(string.Empty, inputArray.ToList());

        Console.Write("Input the the sum to find S: ");
        int sumToFind = int.Parse(Console.ReadLine());

        Console.Write("Input the the sum to find S: ");
        int numCount = int.Parse(Console.ReadLine());
        bool found = false;

        for (int bin = 0; bin < 1 << numberOfElements; bin++)
        {
            int sum = 0;
            StringBuilder equation = new StringBuilder();
            int elements = 0;
            for (int pos = 0; pos < numberOfElements; pos++)
            {
                bool bitAtPos = CheckBit(bin, pos);
                if (bitAtPos)
                {
                    elements++;
                    sum += inputArray[pos];
                    equation.Append(inputArray[pos]);
                    equation.Append(" + ");
                }
            }

            if (sum == sumToFind && elements == numCount)
            {
                string eq = equation.ToString();
                Console.WriteLine("{0} = {1}", sumToFind, eq.Remove(eq.Length - 3));
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("No such sum!");
        }
    }

    private static bool CheckBit(int bin, int pos)
    {
        int mask = 1 << pos;
        return (bin & mask) > 0;
    }
}
