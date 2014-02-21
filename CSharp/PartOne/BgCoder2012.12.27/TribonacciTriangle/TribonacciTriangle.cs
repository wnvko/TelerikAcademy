namespace TribonacciTriangle
{
    using System;

    class TribonacciTriangle
    {
        static void Main()
        {
            long firstTribonacci = long.Parse(Console.ReadLine());
            long secondTribonacci = long.Parse(Console.ReadLine());
            long thirdTribonacci = long.Parse(Console.ReadLine());
            int numberOfRows = int.Parse(Console.ReadLine());

            int countOfTribonacci = (numberOfRows + 1) * numberOfRows / 2;
            long[] tribonacci = new long[countOfTribonacci];
            tribonacci[0] = firstTribonacci;
            tribonacci[1] = secondTribonacci;
            tribonacci[2] = thirdTribonacci;

            int nextToPrint = 0;

            //count all Tribonacci
            for (int i = 3; i < countOfTribonacci; i++)
            {
                tribonacci[i] = tribonacci[i - 3] + tribonacci[i - 2] + tribonacci[i - 1];
            }

            //print the Tribonacci triangle
            for (int i = 0; i < numberOfRows; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    string output = "";
                    if (j != i)
                    {
                        output = output + tribonacci[nextToPrint] + " ";
                    }
                    else
                    {
                        output = output + tribonacci[nextToPrint];
                    }
                    Console.Write(output);
                    nextToPrint++;
                }
                if (i < countOfTribonacci - 1)
                {
                    Console.WriteLine();
                }
            }
        }
    }
}