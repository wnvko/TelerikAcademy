/*
 * Write a program that deletes from given text file all odd lines. The result should be in the same file.
 */

using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

public class DeleteOddLines
{
    private const string FileName = @"..\..\SampleText.txt";

    public static void Main()
    {
        StreamReader reader = new StreamReader(FileName);
        List<string> changedText = new List<string>();

        using (reader)
        {
            int lineNumner = 0;
            string currentLine;
            while ((currentLine = reader.ReadLine()) != null)
            {
                if (lineNumner % 2 == 0)
                {
                    changedText.Add(currentLine);
                }

                lineNumner++;
            }
        }

        StreamWriter writer = new StreamWriter(FileName);
        using (writer)
        {
            for (int line = 0; line < changedText.Count; line++)
            {
                writer.WriteLine(changedText[line].ToString());
            }
        }

        Process.Start("notepad.exe", FileName);
    }
}
