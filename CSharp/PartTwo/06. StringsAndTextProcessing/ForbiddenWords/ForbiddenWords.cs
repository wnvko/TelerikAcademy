﻿/*
 * We are given a string containing a list of forbidden words and a text containing some of these words.
 * Write a program that replaces the forbidden words with asterisks.
 */

using System;
using System.Text.RegularExpressions;

public class ForbiddenWords
{
    public static string TakeUserInput(string adviseString)
    {
        Console.WriteLine(adviseString);
        string userExpression = Console.ReadLine();
        return userExpression;
    }

    public static void Main()
    {
        string usetInput = TakeUserInput("Enter a string:");
        string mask = TakeUserInput("Input strings to mask separate by comas:");

        // remove all white spaces
        mask = Regex.Replace(mask, @"\s+", string.Empty);

        // adds brackets for necessary regex expression
        mask = Regex.Replace(mask, @"\w+", @"($&)");

        // replace comas with | for necessary regex expression
        mask = Regex.Replace(mask, @",", @"|");

        Regex result = new Regex(mask);
        foreach (Match match in result.Matches(usetInput))
        {
            string asterix = new string('*', match.Value.Length);
            usetInput = usetInput.Replace(match.Value, asterix);
        }

        Console.WriteLine();
        Console.WriteLine(usetInput);
    }
}
