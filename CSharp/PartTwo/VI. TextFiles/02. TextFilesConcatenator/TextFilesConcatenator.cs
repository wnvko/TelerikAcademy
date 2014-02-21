/*
 * Write a program that concatenates two text files into another text file.
 */

namespace TextFilesConcatenator
{
    using System;
    using System.IO;

    public class TextFilesConcatenator
    {
        public static void Main()
        {
            StreamReader firstFile = new StreamReader(@"..\..\FirstText.txt");
            StreamReader secondFile = new StreamReader(@"..\..\SecondText.txt");
            StreamWriter concatenatedFile = new StreamWriter(@"..\..\ConcatenatedText.txt");
            string textConcatenation = string.Empty;
            using (firstFile)
            {
                textConcatenation = firstFile.ReadToEnd();
                textConcatenation += "\r\n";
            }

            using (secondFile)
            {
                textConcatenation += secondFile.ReadToEnd();
            }

            using (concatenatedFile)
            {
                concatenatedFile.Write(textConcatenation);
            }
        }
    }
}
