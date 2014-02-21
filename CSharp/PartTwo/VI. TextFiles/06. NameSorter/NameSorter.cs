/*
 * Write a program that reads a text file containing a list of strings,
 * sorts them and saves them to another text file.
 * Example:
 * 
 * Ivan      George
 * Peter     Ivan
 *       ->
 * Maria     Maria
 * George    Peter
 */

namespace NameSorter
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class NameSorter
    {
        public static List<string> ReadTextFile(string fileName)
        {
            StreamReader inputFile = new StreamReader(fileName);
            List<string> output = new List<string>();
            string currentRow = string.Empty;

            using (inputFile)
            {
                currentRow = inputFile.ReadLine();
                while (currentRow != null)
                {
                    output.Add(currentRow);
                    currentRow = inputFile.ReadLine();
                }
            }

            return output;
        }

        public static void WriteTextFile(List<string> inputList)
        {
            StreamWriter sortedFile = new StreamWriter(@"..\..\SortedNames.txt");
            using (sortedFile)
            {
                for (int count = 0; count < inputList.Count; count++)
                {
                    sortedFile.WriteLine(inputList[count].ToString());
                }
            }
        }

        public static void Main()
        {
            List<string> names = new List<string>();
            names = ReadTextFile(@"..\..\Names.txt");
            names.Sort();
            WriteTextFile(names);
        }
    }
}