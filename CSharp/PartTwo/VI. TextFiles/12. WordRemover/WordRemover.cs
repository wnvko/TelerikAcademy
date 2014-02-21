/*
 * Write a program that removes from a text file all words
 * listed in given another text file. Handle all possible
 * exceptions in your methods.
 */

namespace WordRemover
{
    using System;
    using System.IO;
    using System.Text;
    using System.Text.RegularExpressions;

    public class WordRemover
    {
        public static void Main()
        {
            StringBuilder regExString = new StringBuilder();
            StringBuilder originalText = new StringBuilder();
            string outputText = string.Empty;
            regExString.Append(@"\b(");
            string currentLine = string.Empty;
            try
            {
                StreamReader originalFile = new StreamReader(@"..\..\OriginalFile.txt");
                StreamReader wordList = new StreamReader(@"..\..\WordList.txt");
                originalText.Append(originalFile.ReadToEnd());
                originalFile.Close();
                regExString.Append(Regex.Replace(wordList.ReadToEnd(), @"\s+", " "));
                regExString.Append(@")\b");
                regExString.Replace(" ", "|");
                originalFile.Close();
                wordList.Close();
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

            StreamWriter outputFile = new StreamWriter(@"..\..\Trimed.txt");
            outputText = Regex.Replace(originalText.ToString(), regExString.ToString(), string.Empty);
            using (outputFile)
            {
                outputFile.Write(outputText);
            }
        }
    }
}