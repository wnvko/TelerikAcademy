/*
 * Write a program that deletes from a text file all words that start
 * with the prefix "test". Words contain only the symbols 0...9, a...z, A…Z, _.
 */

namespace PrefixRemover
{
    using System;
    using System.IO;
    using System.Text;
    using System.Text.RegularExpressions;

    public class PrefixRemover
    {
        public static void Main()
        {
            StreamReader reader = new StreamReader(@"..\..\InputText.txt");
            StreamWriter writer = new StreamWriter(@"..\..\OutputText.txt");
            StringBuilder output = new StringBuilder();
            string regEx = @"\btest\w+|\btest";
            string currentLine = string.Empty;

            using (reader)
            {
                using (writer)
                {
                    currentLine = reader.ReadLine();
                    while (currentLine != null)
                    {
                        currentLine = Regex.Replace(currentLine, regEx, string.Empty);
                        writer.WriteLine(currentLine);
                        output.Append(currentLine);
                        output.Append("\n\b");
                        currentLine = reader.ReadLine();
                    }
                }
            }

            Console.WriteLine(output);
        }
    }
}