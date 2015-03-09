/*
 * Write a program that reads a text file containing a list of strings, sorts them and saves them
 * to another text file.
 */

using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

public class SaveSortedNames
{
    private const string IputFileName = @"..\..\Names.txt";
    private const string OutputFileName = @"SortedNames.txt";

    public static void Main()
    {
        List<string> names = ReadTextFile(IputFileName);
        names.Sort();
        WriteTextFile(names, OutputFileName);
        Process.Start("notepad.exe", OutputFileName);
    }

    private static List<string> ReadTextFile(string fileName)
    {
        StreamReader inputFile = new StreamReader(fileName);
        List<string> output = new List<string>();
        string currentRow = string.Empty;

        using (inputFile)
        {
            while ((currentRow = inputFile.ReadLine()) != null)
            {
                output.Add(currentRow);
            }
        }

        return output;
    }

    private static void WriteTextFile(List<string> inputList, string fileName)
    {
        StreamWriter sortedFile = new StreamWriter(fileName);
        using (sortedFile)
        {
            for (int index = 0; index < inputList.Count; index++)
            {
                sortedFile.WriteLine(inputList[index].ToString());
            }
        }
    }
}
