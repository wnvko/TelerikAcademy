using System;
using System.Xml;

public class SongTitlesWithXmlreader
{
    private static string xmlFilePath = @"../../../temp";
    private static string xmlFileName = @"/01.collection.xml";

    public static void Main()
    {
        XmlReader reader = XmlReader.Create(xmlFilePath + xmlFileName);
        using (reader)
        {
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "title")
                {
                    Console.WriteLine(reader.ReadElementString());
                }
            }
        }
    }
}
