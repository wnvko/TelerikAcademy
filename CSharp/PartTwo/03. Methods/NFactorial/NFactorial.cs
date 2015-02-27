/*
 * Write a program to calculate n! for each n in the range [1..100].
 * Hint: Implement first a method that multiplies a number represented as array of digits by given
 * integer number.
 */

using System;

public class NFactorial
{
    public static void Main(string[] args)
    {
        var myClass = new NFactorial();
        var myHelpClass = new HelperClass();
        Console.Write("Enter an int to calculate factorial from: ");
        int number = int.Parse(Console.ReadLine());

        int[] numberFactoriel = new int[] { 1 };
        for (int index = 1; index <= number; index++)
        {
            numberFactoriel = myClass.ProductBigIntegers(myClass.IntToArray(index), numberFactoriel);
        }

        long startTime = DateTime.UtcNow.Ticks;

        Console.WriteLine();
        myHelpClass.PrintArray(numberFactoriel);
        Console.WriteLine();
        
        long endTime = DateTime.UtcNow.Ticks;
        double elapsedTime = (endTime - startTime) / 100000.0;
        
        Console.WriteLine("\nCalculation of {0}! have taken {1} s", number, elapsedTime);
    }

    private int[] IntToArray(int inputNumber)
    {
        string numberAsString = inputNumber.ToString();
        int[] resultArray = new int[numberAsString.Length];
        for (int index = numberAsString.Length - 1; index >= 0; index--)
        {
            resultArray[index] = inputNumber % 10;
            inputNumber /= 10;
        }

        return resultArray;
    }

    private int[] ProductBigIntegers(int[] firstNumber, int[] secondNumber)
    {
        var mySumBigInt = new MySpace.NumberAsArray();
        int[] result = new int[1] { 0 };
        int numberLenght = firstNumber.Length;
        int[] counter = new int[numberLenght];
        int possitionInNumber = 0;
        counter[numberLenght - 1] = 1;

        while (true)
        {
            possitionInNumber = numberLenght - 1;
            while (counter[possitionInNumber] <= firstNumber[possitionInNumber])
            {
                result = mySumBigInt.SumBigIntegers(result, secondNumber);
                counter[possitionInNumber]++;
            }

            counter[possitionInNumber]++;

            while (counter[possitionInNumber] > firstNumber[possitionInNumber])
            {
                counter[possitionInNumber] = 0;
                firstNumber[possitionInNumber] = 9;
                possitionInNumber--;

                if (possitionInNumber < 0)
                {
                    return result;
                }

                counter[possitionInNumber] = counter[possitionInNumber] + 1;
            }
        }
    }
}
