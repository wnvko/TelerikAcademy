using System;
using System.Collections.Generic;

class NumbersAppearenceCounter
{
    static void Main()
    {
        IList<double> inputData = GetData();
        IDictionary<double, int> numbersAppearenceCount = CountNumbers(inputData);
        PrintResult(numbersAppearenceCount);
    }

    private static IList<double> GetData()
    {
        Console.WriteLine("Enter some numbers: ");
        bool inputIsOver = false;

        IList<double> inputData = new List<double>();
        while (!inputIsOver)
        {
            double result;
            inputIsOver = !double.TryParse(Console.ReadLine(), out result);

            if (inputIsOver)
            {
                break;
            }

            inputData.Add(result);
        }

        return inputData;
    }

    private static IDictionary<double, int> CountNumbers(IList<double> inputData)
    {
        IDictionary<double, int> numbersAppearenceCount = new Dictionary<double, int>();
        foreach (double number in inputData)
        {
            if (!numbersAppearenceCount.ContainsKey(number))
            {
                numbersAppearenceCount[number] = 0;
            }

            numbersAppearenceCount[number]++;
        }

        return numbersAppearenceCount;
    }

    private static void PrintResult(IDictionary<double, int> numbersAppearenceCount)
    {
        foreach (var pair in numbersAppearenceCount)
        {
            Console.WriteLine("{0}\t-->\t{1} times", pair.Key, pair.Value);
        }
    }
}
