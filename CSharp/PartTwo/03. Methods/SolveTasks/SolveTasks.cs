/*
 * Write a program that can solve these tasks:
 *  - Reverses the digits of a number
 *  - Calculates the average of a sequence of integers
 *  - Solves a linear equation a * x + b = 0
 * Create appropriate methods. Provide a simple text-based menu for the user to choose which task
 * to solve. Validate the input data:
 *  - The decimal number should be non-negative
 *  - The sequence should not be empty
 *  - a should not be equal to 0
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class SolveTasks
{
    public static void Main(string[] args)
    {
        var myClass = new SolveTasks();
        char userChoice = myClass.GetUserInput();

        switch (userChoice)
        {
            case 'A':
                Console.Write("\n Please enter positive integer: ");
                int userInteger = int.Parse(Console.ReadLine());
                int reversetInteger = myClass.ReversNumberDigits(userInteger);
                Console.WriteLine("{0} reversed is {1}", userInteger, reversetInteger);
                break;
            case 'B':
                Console.Write("\n Please enter some integers. Enter any letter to stop: ");
                List<int> userInput = new List<int>();
                int result = 0;
                while (true)
                {
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out result))
                    {
                        userInput.Add(result);
                    }
                    else
                    {
                        break;
                    }
                }

                double averageInteger = myClass.CalcAverageNumber(userInput.ToArray());
                Console.WriteLine("Average is {0}", averageInteger);
                break;
            case 'C':
                Console.WriteLine("\nPlease enter coefficient A and constant B");
                Console.WriteLine("of equation A*X + B = 0");
                Console.Write("A: ");
                int coeficientA = int.Parse(Console.ReadLine());
                Console.Write("B: ");
                int constantB = int.Parse(Console.ReadLine());
                double unknownX = myClass.SolvesLinearEquation(coeficientA, constantB);
                Console.WriteLine("Unknown X is {0}", unknownX);
                break;

            case 'E':
                break;
            default:
                break;
        }
    }

    private char GetUserInput()
    {
        Console.WriteLine("Please choose:");
        Console.WriteLine("\tA) Reverses the digits of a number;");
        Console.WriteLine("\tB) Calculates the average of a sequence of integers;");
        Console.WriteLine("\tC) Solves a linear equation a * x + b = 0");
        Console.WriteLine("\tE)For exit");

        char userChoice;
        do
        {
            Console.WriteLine("Please enter correct letter from menu above (A, B, C or E)");
            userChoice = Console.ReadKey().KeyChar;
        }
        while (userChoice != 'A' && userChoice != 'B' && userChoice != 'C' && userChoice != 'E');

        return userChoice;
    }

    private int ReversNumberDigits(int inputNumber)
    {
        if (inputNumber < 0)
        {
            throw new ArgumentException("Input number should by positive.");
        }

        int reversedNumber = 0;

        while (inputNumber != 0)
        {
            reversedNumber = (reversedNumber * 10) + (inputNumber % 10);
            inputNumber = inputNumber / 10;
        }

        return reversedNumber;
    }

    private double CalcAverageNumber(params int[] numbers)
    {
        if (numbers.Length == 0)
        {
            throw new ArgumentException("The sequence should not be empty");
        }

        int sumOfNumbers = 0;
        foreach (var number in numbers)
        {
            sumOfNumbers += number;
        }

        double average = (double)sumOfNumbers / numbers.Length;
        return average;
    }

    private double SolvesLinearEquation(int indexA, int indexB)
    {
        if (indexA == 0)
        {
            throw new ArgumentException("Index A should not be equal to zero.");
        }

        double unknownX = (double)-indexB / indexA;
        return unknownX;
    }
}