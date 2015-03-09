/*
 * Write a program that reads a string from the console and lists all different words in the string
 * along with information how many times each word is found.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class WordsCount
{
    public static void Main()
    {
        string textToCheck = "Write a program that reads a string from the console " +
                             "and lists all different words in the string along with " +
                             "information how many times each word is found. a a a the the is is";

        Console.WriteLine(textToCheck);
        Console.WriteLine();

        Regex removePunctoation = new Regex(@"([^\w+\s+])");
        string clearedText = removePunctoation.Replace(textToCheck, string.Empty);
        string[] words = clearedText.Split(' ');

        Dictionary<string, int> dictionary = new Dictionary<string, int>();

        for (int index = 0; index < words.Length; index++)
        {
            if (!dictionary.ContainsKey(words[index]))
            {
                dictionary[words[index]] = 0;
            }

            dictionary[words[index]]++;
        }

        var ordered = dictionary.OrderByDescending(v => v.Value);

        foreach (KeyValuePair<string, int> pair in ordered)
        {
            Console.WriteLine("{0,15}{1,5}", pair.Key, pair.Value);
        }
    }
}