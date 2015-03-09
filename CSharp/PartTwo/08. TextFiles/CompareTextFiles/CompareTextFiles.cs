/*
 * Write a program that compares two text files line by line and prints the number of lines that
 * are the same and the number of lines that are different. Assume the files have equal number
 * of lines.
 */

using System;
using System.IO;

public class CompareTextFiles
{
    public static void Main()
    {
        StreamReader firstFile = new StreamReader(@"..\..\FirstFile.txt");
        StreamReader secondFile = new StreamReader(@"..\..\SecondFile.txt");
        int lineCounter = 0;

        using (firstFile)
        {
            using (secondFile)
            {
                string firstTextFileLine;
                string secondTextFileLne;

                while ((firstTextFileLine = firstFile.ReadLine()) != null)
                {
                    lineCounter++;
                    secondTextFileLne = secondFile.ReadLine();

                    if (firstTextFileLine.CompareTo(secondTextFileLne) == 0)
                    {
                        Console.WriteLine("Line {0} of both files is same", lineCounter);
                    }
                }
            }
        }
    }
}