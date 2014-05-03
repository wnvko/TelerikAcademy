namespace SumAndAverage
{
    using System;
    using System.Collections.Generic;

    public class SumAndAverage
    {
        public static void Main()
        {
            Console.WriteLine("Please enter some numbers");
            Console.WriteLine("Enter empty line to finish");

            List<int> inputData = new List<int>();
            int sum = 0;

            while (true)
            {
                string currentInput = Console.ReadLine();
                if (currentInput == string.Empty)
                {
                    break;
                }

                inputData.Add(int.Parse(currentInput));
                sum += inputData[(inputData.Count - 1)];
            }

            Console.WriteLine("The sum of elements is: {0}", sum);
            Console.WriteLine("The average of elements is: {0}", sum / inputData.Count);
        }
    }
}
