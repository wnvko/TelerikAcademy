/*
 * Write a program that reads a text file and inserts line numbers in front of each of its lines.
 * The result should be written to another text file.
 */

using System.Diagnostics;
using System.IO;

public class LineNumbers
{
    public static void Main()
    {
        StreamReader inputFile = new StreamReader(@"..\..\SampleText.txt");
        StreamWriter outputFile = new StreamWriter(@"TextWithNumbers.txt");
        int rowCounter = 0;
        using (inputFile)
        {
            string currentLine = inputFile.ReadLine();
            using (outputFile)
            {
                while (currentLine != null)
                {
                    rowCounter++;
                    string tempString = string.Format("Line {0,-10}{1}", rowCounter, currentLine);
                    outputFile.WriteLine(tempString);
                    currentLine = inputFile.ReadLine();
                }
            }
        }

        Process.Start("notepad.exe", @"TextWithNumbers.txt");
    }
}