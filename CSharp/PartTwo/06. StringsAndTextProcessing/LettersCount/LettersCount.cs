/*
 * Write a program that reads a string from the console and prints all different letters in the
 * string along with information how many times each letter is found.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class LettersCount
{
    public static void Main()
    {

        string textToCheck = "Write a program that reads a string from the console and " +
                             "prints all different letters in the string along with " +
                             "information how many times each letter is found. ";
        Console.WriteLine(textToCheck);
        Console.WriteLine();
        Dictionary<char, int> letters = new Dictionary<char, int>();

        for (int index = 0; index < textToCheck.Length; index++)
        {
            if (!letters.ContainsKey(textToCheck[index]))
            {
                letters[textToCheck[index]] = 0;
            }

            letters[textToCheck[index]]++;
        }

        var ordered = letters.OrderByDescending(v => v.Value);

        foreach (KeyValuePair<char, int> pair in ordered)
        {
            Console.WriteLine("{0,7}{1,14}", pair.Key, pair.Value);
        }
    }
}