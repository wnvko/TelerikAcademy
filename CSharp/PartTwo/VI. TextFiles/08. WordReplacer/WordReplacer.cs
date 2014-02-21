/*
 * Modify the solution of the previous problem to replace only whole words (not substrings).
 */

namespace WordReplacer
{
    using System;
    using System.IO;
    using System.Text.RegularExpressions;

    public class WordReplacer
    {
        public static void Main()
        {
            StreamReader reader = new StreamReader(@"..\..\OriginalText.txt");
            StreamWriter writer = new StreamWriter(@"..\..\ChangedText.txt");
            string currentLine = string.Empty;
            string oldlWord = @"\bstart\b";
            string newWord = "finish";

            using (reader)
            {
                using (writer)
                {
                    currentLine = reader.ReadLine();
                    while (currentLine != null)
                    {
                        currentLine = Regex.Replace(currentLine, oldlWord, newWord);
                        writer.WriteLine(currentLine);
                        currentLine = reader.ReadLine();
                    }
                }
            }
        }
    }
}