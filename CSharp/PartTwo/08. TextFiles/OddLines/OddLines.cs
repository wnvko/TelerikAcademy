/*
 * Write a program that reads a text file and prints on the console its odd lines.
 */

using System;
using System.IO;

public class OddLines
{
    public static void Main()
    {
        StreamReader inputText = new StreamReader(@"..\..\SampleText.txt");
        using (inputText)
        {
            int lineNumner = 0;
            string currentLine;
            while ((currentLine = inputText.ReadLine()) != null)
            {
                if (lineNumner % 2 != 0)
                {
                    Console.WriteLine(currentLine);
                }

                lineNumner++;
            }
        }
    }
}
