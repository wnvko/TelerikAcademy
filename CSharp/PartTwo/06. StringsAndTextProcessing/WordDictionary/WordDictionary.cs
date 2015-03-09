/*
 * A dictionary is stored as a sequence of text lines containing words and their explanations.
 * Write a program that enters a word and translates it by using the dictionary.
 */

using System;
using System.Text.RegularExpressions;

public class WordDictionary
{
    public static void Main()
    {
        string dictionary = ".NET – platform for applications from Microsoft" +
                            "\nCLR – managed execution environment for .NET" +
                            "\nnamespace – hierarchical organization of classes";
        string lookupWord = TakeUserInput("Enter a word to find:");
        string regexLookup = @"(?<=(" + lookupWord + @"\s–\s)).+";
        Regex regex = new Regex(regexLookup);
        string result = regex.Match(dictionary).ToString();
        if (result != string.Empty)
        {
            Console.WriteLine("{0} is {1}", lookupWord, result);
        }
        else
        {
            Console.WriteLine("{0} is not found in the dictionary", lookupWord);
        }
    }

    public static string TakeUserInput(string adviseString)
    {
        Console.WriteLine(adviseString);
        string input = Console.ReadLine();
        return input;
    }
}
