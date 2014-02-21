/*
 * Write a program that deletes from given text file all
 * odd lines. The result should be in the same file.
 */

namespace OddLinesRemover
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class OddLinesRemover
    {
        public static void Main()
        {
            StreamReader reader = new StreamReader(@"..\..\SampleText.txt");
            StreamWriter writer = new StreamWriter(@"..\..\ChangedText.txt");
            List<string> changedText = new List<string>();

            using (reader)
            {
                int lineNumner = 0;
                string currentLine = reader.ReadLine();
                while (currentLine != null)
                {
                    if (lineNumner % 2 == 0)
                    {
                        changedText.Add(currentLine);
                    }

                    lineNumner++;
                    currentLine = reader.ReadLine();
                }
            }

            using (writer)
            {
                for (int line = 0; line < changedText.Count; line++)
                {
                    writer.WriteLine(changedText[line].ToString());
                }
            }
        }
    }
}
