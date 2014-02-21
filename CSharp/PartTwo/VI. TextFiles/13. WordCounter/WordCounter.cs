/*
 * Write a program that reads a list of words from a file words.txt
 * and finds how many times each of the words is contained in another
 * file test.txt. The result should be written in the file result.txt
 * and the words should be sorted by the number of their occurrences
 * in descending order. Handle all possible exceptions in your methods.
 */

namespace WordCounter
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Text.RegularExpressions;

    public class WordCounter
    {
        public static void Main()
        {
            List<string> wordsList = new List<string>();
            string testText = string.Empty;
            string outputText = string.Empty;

            try
            {
                StreamReader originalFile = new StreamReader(@"..\..\test.txt");
                StreamReader wordList = new StreamReader(@"..\..\words.txt");
                using (originalFile)
                {
                    testText = originalFile.ReadToEnd();
                }

                using (wordList)
                {
                    wordsList.AddRange((Regex.Replace(wordList.ReadToEnd(), @"\s+", " ")).Split(' '));
                }
            }
            catch (System.NullReferenceException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (System.IO.FileNotFoundException exception)
            {
                Console.WriteLine("File {0} is not found", exception.FileName);
            }
            catch
            {
                Console.WriteLine("Fatal error occured!");
            }

            int[] repetitionount = new int[wordsList.Count];
            for (int count = 0; count < wordsList.Count; count++)
            {
                repetitionount[count] = Regex.Matches(testText, @"\b" + wordsList[count] + @"\b").Count;
            }

            string[] wordsArray = wordsList.ToArray();
            Array.Sort(repetitionount, wordsArray);
            Array.Reverse(repetitionount);
            Array.Reverse(wordsArray);

            StreamWriter resultFile = new StreamWriter(@"..\..\result.txt");
            using (resultFile)
            {
                for (int count = 0; count < repetitionount.Length; count++)
                {
                    resultFile.WriteLine(string.Format("{0,-10}{1,5} times", wordsArray[count], repetitionount[count]));
                }
            }
        }
    }
}