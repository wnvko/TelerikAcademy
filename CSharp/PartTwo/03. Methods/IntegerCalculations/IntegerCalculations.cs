/*
 * Write methods to calculate minimum, maximum, average, sum and product of given set of integer
 * numbers. Use variable number of arguments.
 * 
 * Modify your last program and try to make it work for any number type, not just integer
 * (e.g. decimal, float, byte, etc.). Use generic method (read in Internet about generic methods in C#).
 */

using System;

public class IntegerCalculations
{
    public static void Main(string[] args)
    {
        IntegerCalculations myClass = new IntegerCalculations();
        HelperClass myHelpClass = new HelperClass();
        var array = myHelpClass.GenerateRandomArray<float>(20, 100);
        myClass.PrintResult(array);
    }

    private void PrintResult<T>(T[] array) where T : IComparable
    {
        HelperClass myHelpClass = new HelperClass();
        Console.WriteLine();
        Console.WriteLine("\nInput array:");
        myHelpClass.PrintArray(array);
        Console.WriteLine();
        Console.WriteLine("\nMin value = {0}", this.FindMinValue<T>(array));
        Console.WriteLine("Max value = {0}", this.FindMaxValue(array));
        Console.WriteLine("Average value = {0}", this.FindAverageValue(array));
        Console.WriteLine("Sum value = {0}", this.FindSumValue(array));
        Console.WriteLine("Product value = {0}", this.FindProductValue(array));
    }

    private T FindMinValue<T>(params T[] inputnumbers) where T : IComparable
    {
        T minValue = inputnumbers[0];
        foreach (T number in inputnumbers)
        {
            if (number.CompareTo(minValue) < 0)
            {
                minValue = number;
            }
        }

        return minValue;
    }

    private T FindMaxValue<T>(params T[] inputnumbers) where T : IComparable
    {
        T maxValue = inputnumbers[0];
        foreach (T number in inputnumbers)
        {
            if (number.CompareTo(maxValue) > 0)
            {
                maxValue = number;
            }
        }

        return maxValue;
    }

    private double FindAverageValue<T>(params T[] inputNumbers)
    {
        dynamic sumOfNumbers = this.FindSumValue<T>(inputNumbers);
        double average = sumOfNumbers / inputNumbers.Length;
        return average;
    }

    private T FindSumValue<T>(params T[] inputNumbers)
    {
        dynamic sumOfNumbers = 0;
        foreach (T number in inputNumbers)
        {
            sumOfNumbers += (dynamic)number;
        }

        return (T)sumOfNumbers;
    }

    private T FindProductValue<T>(params T[] inputNumbers)
    {
        dynamic productOfNumbers = 1;
        foreach (var number in inputNumbers)
        {
            productOfNumbers *= number;
        }

        return (T)productOfNumbers;
    }
}