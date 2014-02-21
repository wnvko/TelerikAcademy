/*
 * Write a method that adds two polynomials. Represent them as arrays
 * of their coefficients as in the example below:
 * x2 + 5 = 1x2 + 0x + 5 -> { 5 , 0 , 1 }
 * Extend the program to support also subtraction and multiplication of polynomials.
 */

namespace PolinomialsSubtract
{
    using System;
    class PolinomialsSubtract
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

        static int[] SubtractPolinomials(int[] firstPolinomial, int[] secondPolinomial)
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

            int[] differenceOfPolinomials = new int[longerPolinomialLenght];

            for (int index = 0; index < longerPolinomialLenght; index++)
            {
                if (index < shorterPolinomialLenght)
                {
                    differenceOfPolinomials[index] = firstPolinomial[index] - secondPolinomial[index];
                }
                else if (firstIsLonger)
                {
                    differenceOfPolinomials[index] = firstPolinomial[index];
                }
                else
                {
                    differenceOfPolinomials[index] = secondPolinomial[index];
                }
            }

            return differenceOfPolinomials;
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

            int[] sumOfPolinomials = SubtractPolinomials(firstPolinomial, secondPolinomial);
            Console.WriteLine(new string('-', 30));
            PrintArray(sumOfPolinomials);
        }
    }
}