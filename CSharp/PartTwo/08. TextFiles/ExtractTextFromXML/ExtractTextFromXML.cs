/*
 * Write a program that extracts from given XML file all the text without the tags.
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

public class ExtractTextFromXML
{
    public static void Main()
    {
        StreamReader reader = new StreamReader(@"..\..\SampleXMLFile.xml");
        StringBuilder output = new StringBuilder();
        string regEx = @"<.+?>";
        string currentLine = string.Empty;

        using (reader)
        {
            while ((currentLine = reader.ReadLine()) != null)
            {
                currentLine = Regex.Replace(currentLine, @"\s+", @" ");
                output.Append(Regex.Replace(currentLine, regEx, string.Empty));
                currentLine = reader.ReadLine();
            }
        }

        Console.WriteLine(output.ToString());
    }
}
