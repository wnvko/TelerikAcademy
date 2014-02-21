namespace Neurons
{
    using System;

    class Neurons
    {
        static void Main()
        {
            int rows = 0;
            int columns = 0;
            int numbersCount = 0;
            uint[] inputNumbers = new uint[32];
            uint[] outputNumbers = new uint[32];

            //acceept input data
            for (int i = 0; i < 32; i++)
            {
                uint currentNumber = 0;
                string inputAsText = Console.ReadLine();
                bool finishInput = uint.TryParse(inputAsText, out currentNumber);
                if (!finishInput)
                {
                    break;
                }
                inputNumbers[i] = currentNumber;
                outputNumbers[i] = inputNumbers[i];
                numbersCount++;
            }

            //find neurons
            for (rows = 0; rows <= numbersCount; rows++)
            {
                int neuronStart = 0;
                int neuronEnd = 0;

                for (columns = 0; columns < 32; columns++)
                {
                    uint mask = 1;
                    mask = mask << columns;
                    uint check = inputNumbers[rows] & mask;
                    check = check >> columns;

                    if ((check == 1) && (neuronStart < neuronEnd))
                    {
                        for (int j = neuronStart; j < neuronEnd; j++)
                        {
                            outputNumbers[rows] = outputNumbers[rows] | (1u << j);
                        }
                    }

                    if (check == 1)
                    {
                        neuronStart = columns + 1;
                        outputNumbers[rows] = outputNumbers[rows] & (~mask);
                    }
                    else if (neuronStart > 0)
                    {
                        neuronEnd = columns + 1;
                    }
                }
            }

            //printout the result
            int counter = 0;
            while (counter < numbersCount)
            {
                Console.WriteLine(outputNumbers[counter]);
                counter++;
            }
        }
    }
}