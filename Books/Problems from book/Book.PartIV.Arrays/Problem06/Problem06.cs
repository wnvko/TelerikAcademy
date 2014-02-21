namespace Problem06
{
    using System;

    class Problem06
    {
        static void Main()
        {
            //input
            Console.WriteLine("Enter the numbers in array: ");
            int arrayCount = int.Parse(Console.ReadLine());
            int[] arrayNumbers = new int[arrayCount];

            for (int index = 0; index < arrayCount; index++)
            {
                Console.Write("Enter number on position {0}: ", index + 1);
                arrayNumbers[index] = int.Parse(Console.ReadLine());
            }

            //calculation
            int numberOfIterations = 1;
            int bestIteration = 0;
            int startNumber = 0;
            int bestNumber = 0;

            for (int index = 0; index < arrayCount; index++)
            {
                for (int check = index + 1; check < arrayCount; check++)
                {
                    if (arrayNumbers[index] < arrayNumbers[check])
                    {
                        startNumber = index;
                        numberOfIterations++;
                        continue;
                    }
                    else
                    {
                        break;
                    }
                    if (numberOfIterations > bestIteration)
                    {
                        bestIteration = numberOfIterations;
                        bestNumber = startNumber;
                    }
                }
            }

            //output
            Console.WriteLine("The most long sequence of consecutive numbers in the array is:");
            Console.WriteLine(bestNumber);
            for (int index = bestNumber; index < arrayCount; index++)
            {
                if (bestNumber < arrayNumbers[index])
                {
                    Console.WriteLine(arrayNumbers[index]);
                }
            }
        }
    }
}