namespace QuadronacciRectangle
{
    using System;
    using System.Threading;
    using System.Globalization;

    class QuadronacciRectangle
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            double firstQuadronacci = double.Parse(Console.ReadLine());
            double secondQuadronacci = double.Parse(Console.ReadLine());
            double thirdQuadronacci = double.Parse(Console.ReadLine());
            double fourthQuadronacci = double.Parse(Console.ReadLine());
            int numberOfRows = int.Parse(Console.ReadLine());
            int numberOfColumns = int.Parse(Console.ReadLine());
            int totalQudronacciCount = (numberOfColumns * numberOfRows);
            double[] quadronacci = new double[totalQudronacciCount];

            //calculating all Quadronaccis
            quadronacci[0] = firstQuadronacci;
            quadronacci[1] = secondQuadronacci;
            quadronacci[2] = thirdQuadronacci;
            quadronacci[3] = fourthQuadronacci;
            for (int i = 4; i < (totalQudronacciCount); i++)
            {
                quadronacci[i] = quadronacci[i - 4] + quadronacci[i - 3] + quadronacci[i - 2] + quadronacci[i - 1];
            }

            //print the result
            int index = 0;
            string result = "";
            for (int i = 0; i < numberOfRows; i++)
            {
                index = i * numberOfColumns;
                result = "";
                for (int j = 0; j < numberOfColumns; j++)
                {
                    if (j != (numberOfColumns - 1))
                    {
                        result = result + quadronacci[index] + " ";
                    }
                    else
                    {
                        result = result + quadronacci[index];
                    }
                    index++;
                }
                Console.WriteLine(result);
            }
        }
    }
}
