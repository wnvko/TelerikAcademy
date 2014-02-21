/*
 * Write a program that compares two text files line by line and prints
 * the number of lines that are the same and the number of lines that
 * are different. Assume the files have equal number of lines.
 */

namespace FileComparer
{   
    using System;
    using System.IO;

    public class FileComparer
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
                    string firstTextFileLine = firstFile.ReadLine();
                    string secondTextFileLne = secondFile.ReadLine();
                        
                    while (firstTextFileLine != null)
                    {
                        lineCounter++;
                        if (firstTextFileLine.CompareTo(secondTextFileLne) == 0)
                        {
                            Console.WriteLine("Line {0} of both files is same", lineCounter);
                        }

                        firstTextFileLine = firstFile.ReadLine();
                        secondTextFileLne = secondFile.ReadLine();
                    }
                }
            }
        }
    }
}