/*
 * Write a method that adds two polynomials. Represent them as arrays
 * of their coefficients as in the example below:
 * x2 + 5 = 1x2 + 0x + 5 -> { 5 , 0 , 1 }
 */


namespace PolinomialSum
{
    using System;
    class PolinomialSum
    {
        static Random rnd = new Random();
        static int[] GenerateRandomArray(int numberOfItems)
        {
            int maxNumberInArray = 100;
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
                separator = (counter > 0 ? " + " : "");
                Console.Write("{0}*x^{1}{2}", inputArray[counter], counter, separator);
            }
            Console.WriteLine();
        }

        static int[] SumPolinomials(int[] firstPolinomial, int[] secondPolinomial)
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

            int[] sumOfPolinomials = new int[longerPolinomialLenght];

            for (int index = 0; index < longerPolinomialLenght; index++)
            {
                if (index < shorterPolinomialLenght)
                {
                    sumOfPolinomials[index] = firstPolinomial[index] + secondPolinomial[index];
                }
                else if (firstIsLonger)
                {
                    sumOfPolinomials[index] = firstPolinomial[index];
                }
                else
                {
                    sumOfPolinomials[index] = secondPolinomial[index];
                }
            }

            return sumOfPolinomials;
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
            
            int[] sumOfPolinomials = SumPolinomials(firstPolinomial, secondPolinomial);
            Console.WriteLine(new string('-',30));
            PrintArray(sumOfPolinomials);
        }
    }
}
