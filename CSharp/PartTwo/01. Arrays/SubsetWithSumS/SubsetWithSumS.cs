/*
 * We are given an array of integers and a number S.
 * Write a program to find if there exists a subset of the elements of the array that has a sum S.
 */

using System;
using System.Linq;
using System.Text;

using Helper;

public class SubsetWithSumS
{
    public static void Main(string[] args)
    {
        Console.Write("Input the number of elements in the array: ");
        int numberOfElements = int.Parse(Console.ReadLine());

        int[] inputArray = Arrays.GenerateRandomArray<int>(numberOfElements).ToArray();
        Arrays.PrintArray<int>(string.Empty, inputArray.ToList());

        Console.Write("Input the the sum to find S: ");
        int sumToFind = int.Parse(Console.ReadLine());

        for (int bin = 0; bin < 1 << numberOfElements; bin++)
        {
            int sum = 0;
            StringBuilder equation = new StringBuilder();
            for (int pos = 0; pos < numberOfElements; pos++)
            {
                bool bitAtPos = CheckBit(bin, pos);
                if (bitAtPos)
                {
                    sum += inputArray[pos];
                    equation.Append(inputArray[pos]);
                    equation.Append(" + ");
                }
            }

            if (sum == sumToFind)
            {
                string eq = equation.ToString();
                Console.WriteLine("{0} = {1}", sumToFind, eq.Remove(eq.Length - 3));
            }
        }
    }

    private static bool CheckBit(int bin, int pos)
    {
        int mask = 1 << pos;
        return (bin & mask) > 0;
    }
}