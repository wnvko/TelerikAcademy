/*
 * Write a program to check if in a given expression the brackets are put correctly.
 */

using System;
using System.Collections.Generic;

public class CorrectBrackets
{
    public static void Main(string[] args)
    {
        string userInput = TakeUserInput();
        bool correctExpression = CheckBrackets(userInput);
        if (correctExpression)
        {
            Console.WriteLine(userInput);
            Console.WriteLine("is with correct brackets.");
        }
        else
        {
            Console.WriteLine(userInput);
            Console.WriteLine("is with incorrect brackets.");
        }
    }

    public static string TakeUserInput()
    {
        Console.Write("Enter an expression: ");
        string userExpression = Console.ReadLine();
        return userExpression;
    }

    public static bool CheckBrackets(string input)
    {
        Stack<char> checker = new Stack<char>();

        for (int index = 0; index < input.Length; index++)
        {
            if (input[index] == '(')
            {
                checker.Push(input[index]);
                continue;
            }

            if (input[index] == ')')
            {
                if (checker.Count > 0)
                {
                    checker.Pop();
                }
                else
                {
                    return false;
                }
            }
        }

        if (checker.Count > 0)
        {
            return false;
        }

        return true;
    }
}