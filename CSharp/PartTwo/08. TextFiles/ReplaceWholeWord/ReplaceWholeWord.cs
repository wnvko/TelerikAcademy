/*
 * Modify the solution of the previous problem to replace only whole words (not strings).
 */

using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

public class ReplaceWholeWord
{
    public static void Main()
    {
        StreamReader reader = new StreamReader(@"..\..\OriginalText.txt");
        StreamWriter writer = new StreamWriter(@"ChangedText.txt");
        string currentLine = string.Empty;
        string oldlWord = @"\bstart\b";
        string newWord = "finish";

        using (reader)
        {
            using (writer)
            {
                while ((currentLine = reader.ReadLine()) != null)
                {
                    currentLine = Regex.Replace(currentLine, oldlWord, newWord);
                    writer.WriteLine(currentLine);
                }
            }
        }

        Process.Start("notepad.exe", @"ChangedText.txt");
    }
}
