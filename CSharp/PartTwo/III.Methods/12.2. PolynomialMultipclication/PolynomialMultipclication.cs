namespace PolynomialMultipclication
{
    using System;
    class PolynomialMultipclication
    {
        static Random rnd = new Random();
        static int[] GenerateRandomArray(int numberOfItems)
        {
            int maxNumberInArray = 10;
            int[] randomArray = new int[numberOfItems];

            for (int counter = 0; counter < numberOfItems; counter++)
            {
                randomArray[counter] = rnd.Next(maxNumberInArray);
            }

            return randomArray;
        }
        static void PrintArray(int[] inputArray)
        {
            for (int counter = inputArray.Length - 1; counter >= 0; counter--)
            {
                string separator = "";
                if (inputArray[counter] > 0)
                {
                    separator = (counter != (inputArray.Length - 1) ? "+" : "");
                }
                else if (inputArray[counter] < 0)
                {
                    separator = "";
                }
                else
                {
                    continue;
                }
                Console.Write("{0}{1}*x^{2}", separator, inputArray[counter], counter);
            }
            Console.WriteLine();
        }

        static int[] MultiplyPolinomials(int[] firstPolinomial, int[] secondPolinomial)
        {
            int shorterPolinomialLenght = 0;
            int longerPolinomialLenght = 0;
            bool firstIsLonger = false;

            if (firstPolinomial.Length > secondPolinomial.Length)
            {
                shorterPolinomialLenght = secondPolinomial.Length;
                longerPolinomialLenght = firstPolinomial.Length;
                firstIsLonger = true;
            }
            else
            {
                shorterPolinomialLenght = firstPolinomial.Length;
                longerPolinomialLenght = secondPolinomial.Length;
                firstIsLonger = false;
            }

            int[] productOfPolinomials = new int[longerPolinomialLenght + shorterPolinomialLenght];

            for (int s = 0; s < shorterPolinomialLenght; s++)
            {
                for (int l = 0; l < longerPolinomialLenght; l++)
                {
                    if (firstIsLonger)
                    {
                        productOfPolinomials[s + l] += (secondPolinomial[s] * firstPolinomial[l]);
                    }
                    else
                    {
                        productOfPolinomials[s + l] += (firstPolinomial[s] * secondPolinomial[l]);
                    }
                }
            }

            return productOfPolinomials;
        }
        static void Main()
        {
            Console.Write("Enter the degree of first polinomial: ");
            int firstPolinomialDegree = int.Parse(Console.ReadLine());
            Console.Write("Enter the degree of second polinomial: ");
            int secondPolinomialDegree = int.Parse(Console.ReadLine());

            int[] firstPolinomial = GenerateRandomArray(firstPolinomialDegree + 1);
            int[] secondPolinomial = GenerateRandomArray(secondPolinomialDegree + 1);

            Console.WriteLine();
            PrintArray(firstPolinomial);
            PrintArray(secondPolinomial);

            int[] sumOfPolinomials = MultiplyPolinomials(firstPolinomial, secondPolinomial);
            Console.WriteLine(new string('-', 30));
            PrintArray(sumOfPolinomials);
        }
    }
}