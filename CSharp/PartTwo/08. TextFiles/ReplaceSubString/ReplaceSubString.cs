/*
 * Write a program that replaces all occurrences of the sub-string start with the sub-string finish
 * in a text file. Ensure it will work with large files (e.g. 100 MB).
 */

using System.Diagnostics;
using System.IO;

public class ReplaceSubString
{
    public static void Main()
    {
        StreamReader reader = new StreamReader(@"..\..\OriginalText.txt");
        StreamWriter writer = new StreamWriter(@"ChangedText.txt");
        string currentLine = string.Empty;
        string oldlWord = "start";
        string newWord = "finish";

        using (reader)
        {
            using (writer)
            {
                while ((currentLine = reader.ReadLine()) != null)
                {
                    currentLine = currentLine.Replace(oldlWord, newWord);
                    writer.WriteLine(currentLine);
                }
            }
        }

        Process.Start("notepad.exe", @"ChangedText.txt");
    }
}
