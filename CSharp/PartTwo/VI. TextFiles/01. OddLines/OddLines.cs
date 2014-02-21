/*
 * Write a program that reads a text file and prints on the console its odd lines.
 */

namespace OddLines
{
    using System;
    using System.IO;
    using System.Text;

    public class OddLines
    {
         public static void Main()
        {
            StreamReader inputText = new StreamReader(@"..\..\SampleText.txt");
            using (inputText)
            {
                int lineNumner = 0;
                string currentLine = inputText.ReadLine();
                while (currentLine != null)
                {
                    if (lineNumner % 2 != 0)
                    {
                        Console.WriteLine(currentLine);
                    }

                    lineNumner++;
                    currentLine = inputText.ReadLine();
                }
            }
        }
    }
}
