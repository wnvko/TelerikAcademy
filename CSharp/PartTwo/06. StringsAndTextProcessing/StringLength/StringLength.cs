﻿/*
 * Write a program that reads from the console a string of maximum 20 characters. If the length of
 * the string is less than 20, the rest of the characters should be filled with *.
 * Print the result string into the console.
 */

using System;

public class StringLength
{
    public static void Main()
    {
        string userInput = TakeUserInput("Enter string with not more than 20 chars:");
        string result = AddAsterix(userInput);
        Console.WriteLine(result);
    }

    private static string TakeUserInput(string inputString)
    {
        Console.WriteLine(inputString);
        string userExpression = Console.ReadLine();
        if (userExpression.Length > 20)
        {
            userExpression = userExpression.Remove(20);
        }

        return userExpression;
    }

    private static string AddAsterix(string inputString)
    {
        string resultWithAsterix = inputString;
        if (inputString.Length < 20)
        {
            resultWithAsterix += new string('*', 20 - inputString.Length);
        }

        return resultWithAsterix;
    }
}