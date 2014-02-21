/*
 * Write a program that reads a string from the console and prints all different
 * letters in the string along with information how many times each letter is found. 
 */

namespace LetterCounter
{
    using System;
    using System.Collections.Generic;

    public class LetterCounter
    {
        public static void Main()
        {
            string textToCheck = "Write a program that reads a string from the console and " +
                                 "prints all different letters in the string along with " +
                                 "information how many times each letter is found. ";
            Console.WriteLine(textToCheck);
            Console.WriteLine();
            Dictionary<char, int> letters = new Dictionary<char, int>();
            for (int small = 97; small < 123; small++)
            {
                letters.Add((char)small, 0);
            }

            for (int big = 65; big < 91; big++)
            {
                letters.Add((char)big, 0);
            }

            for (int counter = 0; counter < textToCheck.Length; counter++)
            {
                int tempValue;
                if (letters.TryGetValue(textToCheck[counter], out tempValue))
                {
                    letters[textToCheck[counter]] = tempValue + 1;
                }
            }

            int[] repeatCounter = new int[letters.Values.Count];
            char[] letter = new char[letters.Values.Count];
            int i = 0;
            foreach (var pair in letters)
            {
                repeatCounter[i] = pair.Value;
                letter[i] = pair.Key;
                i++;
            }

            Array.Sort(repeatCounter, letter);
            Array.Reverse(repeatCounter);
            Array.Reverse(letter);
            Console.WriteLine("Leter:   Repeatence:");
            for (int counter = 0; counter < repeatCounter.Length; counter++)
            {
                if (repeatCounter[counter] > 0)
                {
                    Console.WriteLine("{0,7}{1,14}", letter[counter], repeatCounter[counter]);
                }
            }
        }
    }
}
