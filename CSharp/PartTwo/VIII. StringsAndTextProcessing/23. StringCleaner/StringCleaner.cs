/*
 * Write a program that reads a string from the console and replaces
 * all series of consecutive identical letters with a single one.
 * 
 * Example:
 * "aaaaabbbbbcdddeeeedssaa" -> "abcdedsa".
 */

namespace StringCleaner
{
    using System;
    using System.Text.RegularExpressions;

    public class StringCleaner
    {
        public static void Main()
        {
            string textToCheck = "aaaaabbbbbcdddeeeedssaa";
            Console.WriteLine(textToCheck);
            string fixedText = Regex.Replace(textToCheck, @"(\w)\1+", @"$1");
            Console.WriteLine(fixedText);
        }
    }
}
