/*
 * Write a program that deletes from a text file all words that start with the prefix test.
 * Words contain only the symbols 0…9, a…z, A…Z, _.
 */

using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

public class PrefixTest
{
    public static void Main()
    {
        StreamReader reader = new StreamReader(@"..\..\InputText.txt");
        StreamWriter writer = new StreamWriter(@"OutputText.txt");
        string regEx = @"\btest\w+|\btest";
        string currentLine = string.Empty;

        using (reader)
        {
            using (writer)
            {
                while ((currentLine = reader.ReadLine()) != null)
                {
                    currentLine = Regex.Replace(currentLine, regEx, string.Empty);
                    writer.WriteLine(currentLine);
                }
            }
        }

        Process.Start("notepad.exe", @"OutputText.txt");
    }
}
