/*
 * Write a program that creates an array containing all letters from the alphabet (A-Z).
 * Read a word from the console and print the index of each of its letters in the array.
 */

using System;
using System.Collections.Generic;

public class IndexOfLetters
{
    public static void Main(string[] args)
    {
        Console.Write("Please enter a word: ");
        string wordToCheck = Console.ReadLine().ToUpper();

        List<char> alphabet = new List<char>();
        for (int index = 0; index < 26; index++)
        {
            alphabet.Add((char)('A' + index));
        }

        Console.WriteLine();
        Console.WriteLine("Letter\tIndex");
        for (int index = 0; index < wordToCheck.Length; index++)
        {
            int letterIndex = alphabet.IndexOf(wordToCheck[index]);
            Console.WriteLine("{0}\t{1}", wordToCheck[index], letterIndex);
        }
    }
}