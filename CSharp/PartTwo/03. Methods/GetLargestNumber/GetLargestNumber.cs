/*
 * Write a method GetMax() with two parameters that returns the larger of two integers. Write a
 * program that reads 3 integers from the console and prints the largest of them using the method GetMax().
 */

using System;

public class GetLargestNumber
{
    public static void Main(string[] args)
    {
        var myClass = new GetLargestNumber();

        Console.WriteLine("Enter three integers:");

        Console.Write("First: ");
        int first = int.Parse(Console.ReadLine());
        
        Console.Write("Second: ");
        int second = int.Parse(Console.ReadLine());
        
        Console.Write("Third: ");
        int third = int.Parse(Console.ReadLine());

        int biggestNumber = myClass.GetMax(first, second);
        biggestNumber = myClass.GetMax(biggestNumber, third);

        Console.WriteLine("\nThe biggest number is {0}", biggestNumber);
    }

    private int GetMax(int firstNumber, int secondNumber)
    {
        int result = firstNumber;
        if (secondNumber > result)
        {
            result = secondNumber;
        }

        return result;
    }
}
