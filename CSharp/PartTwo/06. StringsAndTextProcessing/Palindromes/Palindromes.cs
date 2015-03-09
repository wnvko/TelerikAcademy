/*
 * Write a program that extracts from a given text all palindromes, e.g. ABBA, lamal, exe.
 */

using System;
using System.Text.RegularExpressions;

public class Palindromes
{
    public static void Main()
    {
        string textToCheck = "Some text with palindromes like ABBA, lamal, exe and some more coplex abbcdEE1EEdcbba! But not this a.a";
        Console.WriteLine(textToCheck);

        Console.WriteLine("\nAll palindromes are:\n");

        Regex palindromes = new Regex(@"(?<N>\w)+\w?(?<-N>\k<N>)+(?(N)(?!))");
        foreach (Match palindrome in palindromes.Matches(textToCheck))
        {
            Console.WriteLine(palindrome);
        }
    }
}
