/*
 * Write a program that extracts from given XML file all the text without the tags.
 * Example:
 * <?xml version="1.0"><student><name>Pesho</name><age>21</age><interests count="3">
 * <interest> Games</instrest><interest>C#</instrest><interest> Java</instrest>
 * </interests></student>
 */

namespace XMLReader
{
    using System;
    using System.IO;
    using System.Text;
    using System.Text.RegularExpressions;

    public class XMLReader
    {
        public static void Main()
        {
            StreamReader reader = new StreamReader(@"..\..\SampleXMLFile.xml");
            StringBuilder output = new StringBuilder();
            string regEx = @"<.+?>";
            string currentLine = string.Empty;

            using (reader)
            {
                currentLine = reader.ReadLine();
                while (currentLine != null)
                {
                    currentLine = Regex.Replace(currentLine, @"\s+", @" ");
                    output.Append(Regex.Replace(currentLine, regEx, string.Empty));
                    currentLine = reader.ReadLine();
                }
            }

            Console.WriteLine(output.ToString());
        }
    }
}