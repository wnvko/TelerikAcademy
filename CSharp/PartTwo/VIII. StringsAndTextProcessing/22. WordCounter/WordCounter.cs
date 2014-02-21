/*
 * Write a program that reads a string from the console and lists all
 * different words in the string along with information how many
 * times each word is found.
 */

namespace WordCounter
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class WordCounter
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

            List<string> eachWord = new List<string>();
            List<int> wordCounter = new List<int>();

            for (int i = 0; i < words.Length; i++)
            {
                if (eachWord.Contains(words[i]))
                {
                    int pos = eachWord.IndexOf(words[i]);
                    wordCounter[pos]++;
                }
                else
                {
                    eachWord.Add(words[i]);
                    wordCounter.Add(1);
                }
            }

            string[] resultWords = eachWord.ToArray();
            int[] resultCount = wordCounter.ToArray();

            Array.Sort(resultCount, resultWords);
            Array.Reverse(resultCount);
            Array.Reverse(resultWords);

            int counter = 0;
            foreach (string word in resultWords)
            {
                Console.WriteLine("{0}: {1} times", word, resultCount[counter]);
                counter++;
            }
        }
    }
}
