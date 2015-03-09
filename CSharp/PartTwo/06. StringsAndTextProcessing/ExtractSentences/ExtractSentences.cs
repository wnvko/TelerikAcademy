/*
 * Write a program that extracts from a given text all sentences containing given word.
 */

using System;
using System.Text.RegularExpressions;

public class ExtractSentences
{
    public static void Main(string[] args)
    {
        string userInput = TakeUserInput("Enter a string:");
        string lookupString = TakeUserInput("Enter lookup value:");
        lookupString = @"[\w\s]+\b" + lookupString + @"\b[\s\w]+\.";
        Regex result = new Regex(lookupString);

        foreach (Match match in result.Matches(userInput))
        {
            if (match.Success)
            {
                Console.WriteLine(match.Value);
            }
        }
    }

    private static string TakeUserInput(string inputString)
    {
        Console.WriteLine(inputString);
        string input = Console.ReadLine();
        return input;
    }
}
