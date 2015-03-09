/*
 * Write a program that concatenates two text files into another text file.
 */

using System;
using System.Diagnostics;
using System.IO;

public class ConcatenateTextFiles
{
    public static void Main()
    {
        StreamReader firstFile = new StreamReader(@"..\..\FirstText.txt");
        StreamReader secondFile = new StreamReader(@"..\..\SecondText.txt");
        StreamWriter concatenatedFile = new StreamWriter(@"ConcatenatedText.txt");
        string textConcatenation = string.Empty;
        using (firstFile)
        {
            textConcatenation = firstFile.ReadToEnd();
            textConcatenation += Environment.NewLine;
        }

        using (secondFile)
        {
            textConcatenation += secondFile.ReadToEnd();
        }

        using (concatenatedFile)
        {
            concatenatedFile.Write(textConcatenation);
            Process.Start("notepad.exe", @"ConcatenatedText.txt");
        }
    }
}
