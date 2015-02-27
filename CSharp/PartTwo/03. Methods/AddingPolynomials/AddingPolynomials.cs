/*
 * Write a method that adds two polynomials. Represent them as arrays of their coefficients.
 * 
 * Extend the previous program to support also subtraction and multiplication of polynomials.
 */

using System;

public class AddingPolynomials
{
    public static void Main(string[] args)
    {
        var myClass = new AddingPolynomials();
        var myHelperClass = new HelperClass();

        Console.Write("Enter the degree of first polinomial: ");
        int firstPolinomialDegree = int.Parse(Console.ReadLine());

        Console.Write("Enter the degree of second polinomial: ");
        int secondPolinomialDegree = int.Parse(Console.ReadLine());

        int[] firstPolinomial = myHelperClass.GenerateRandomArray<int>(firstPolinomialDegree + 1, 10);
        int[] secondPolinomial = myHelperClass.GenerateRandomArray<int>(secondPolinomialDegree + 1, 10);

        Console.WriteLine();
        myHelperClass.PrintArray(firstPolinomial);
        Console.WriteLine();

        myHelperClass.PrintArray(secondPolinomial);
        Console.WriteLine();

        int[] sumOfPolinomials = myClass.SumPolinomials(firstPolinomial, secondPolinomial);
        myHelperClass.PrintArray(sumOfPolinomials);
        Console.WriteLine();

        int[] difOfPolinomials = myClass.SubtractPolinomials(firstPolinomial, secondPolinomial);
        myHelperClass.PrintArray(difOfPolinomials);
        Console.WriteLine();
    }

    private int[] SumPolinomials(int[] firstPolinomial, int[] secondPolinomial)
    {
        int[] shorter = firstPolinomial.Length <= secondPolinomial.Length ? firstPolinomial : secondPolinomial;
        int[] longer = firstPolinomial.Length > secondPolinomial.Length ? firstPolinomial : secondPolinomial;

        int[] sumOfPolinomials = new int[longer.Length];

        for (int index = 0; index < longer.Length; index++)
        {
            if (index < shorter.Length)
            {
                sumOfPolinomials[index] = shorter[index] + longer[index];
            }
            else
            {
                sumOfPolinomials[index] = longer[index];
            }
        }

        return sumOfPolinomials;
    }

    private int[] SubtractPolinomials(int[] firstPolinomial, int[] secondPolinomial)
    {
        int[] shorter = firstPolinomial.Length <= secondPolinomial.Length ? firstPolinomial : secondPolinomial;
        int[] longer = firstPolinomial.Length > secondPolinomial.Length ? firstPolinomial : secondPolinomial;
        bool firstIsLonger = firstPolinomial.Length > secondPolinomial.Length;

        int[] differenceOfPolinomials = new int[longer.Length];

        for (int index = 0; index < longer.Length; index++)
        {
            if (index < shorter.Length)
            {
                differenceOfPolinomials[index] = firstPolinomial[index] - secondPolinomial[index];
            }
            else if (firstIsLonger)
            {
                differenceOfPolinomials[index] = firstPolinomial[index];
            }
            else
            {
                differenceOfPolinomials[index] = -secondPolinomial[index];
            }
        }

        return differenceOfPolinomials;
    }
}