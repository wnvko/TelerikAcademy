/*
 * You are given a text. Write a program that changes the text in all regions surrounded by the
 * tags <upcase> and </upcase> to upper-case. The tags cannot be nested.
 */

using System;
using System.Text.RegularExpressions;

public class ParseTags
{
    public static void Main(string[] args)
    {
        string userString = TakeUserInput("Enter a string with necessary tags: ");
        string changedString = ParseInput(userString);
        Console.WriteLine();
        Console.WriteLine(changedString);
    }

    private static string TakeUserInput(string adviseString)
    {
        Console.WriteLine(adviseString);
        string userExpression = Console.ReadLine();
        return userExpression;
    }

    private static string ParseInput(string userString)
    {
        string changedString = Regex.Replace(
                                             userString,
                                             @"(?<=<upcase>)(.+?)(?=</upcase>)",
                                             delegate(Match match)
                                             {
                                                 string text = match.ToString();
                                                 return text.ToUpper();
                                             });

        changedString = Regex.Replace(changedString, @"<.+?>", string.Empty);
        return changedString;
    }
}