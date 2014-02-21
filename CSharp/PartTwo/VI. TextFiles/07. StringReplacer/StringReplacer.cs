/*
 * Write a program that replaces all occurrences of the substring
 * "start" with the substring "finish" in a text file. Ensure it
 * will work with large files (e.g. 100 MB).
 */

namespace StringReplacer
{
    using System;
    using System.IO;

    public class StringReplacer
    {
        public static void Main()
        {
            StreamReader reader = new StreamReader(@"..\..\OriginalText.txt");
            StreamWriter writer = new StreamWriter(@"..\..\ChangedText.txt");
            string currentLine = string.Empty;
            string oldlWord = "start";
            string newWord = "finish";

            using (reader)
            {
                using (writer)
                {
                    currentLine = reader.ReadLine();
                    while (currentLine != null)
                    {
                        currentLine = currentLine.Replace(oldlWord, newWord);
                        writer.WriteLine(currentLine);
                        currentLine = reader.ReadLine();
                    }
                }
            }
        }
    }
}