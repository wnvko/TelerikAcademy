namespace DataEvaluator
{
    using System;

    public class Printer
    {
        public void PrintStatistics(double[] input, int count)
        {
            double inputMaxValue = Double.MinValue;
            for (int i = 0; i < count; i++)
            {
                if (input[i] > inputMaxValue)
                {
                    inputMaxValue = input[i];
                }
            }

            Print(inputMaxValue);
            
            double inputMinValue = Double.MaxValue;
            for (int i = 0; i < count; i++)
            {
                if (input[i] < inputMinValue)
                {
                    inputMinValue = input[i];
                }
            }

            Print(inputMinValue);

            double inputSum = 0;
            for (int i = 0; i < count; i++)
            {
                inputSum += input[i];
            }

            double inputAverage = inputSum / count;
            Print(inputAverage);
        }

        public static void Print(double inputToPrint)
        {
            // Do something...
        }
    }
}