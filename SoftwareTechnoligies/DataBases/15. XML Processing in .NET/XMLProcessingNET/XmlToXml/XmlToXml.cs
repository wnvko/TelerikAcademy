using System;
using System.IO;
using System.Text;
using System.Xml;

public class TxtToXml
{
    private static string xmlFilePath = @"../../../temp";
    private static string xmlInputFileName = @"/01.collection.xml";
    private static string xmlOutputFileName = @"/08.albums.xml";

    public static void Main()
    {
        GenerateXml();
    }

    private static void GenerateXml()
    {
        Encoding encoding = Encoding.GetEncoding("windows-1251");
        XmlTextWriter writer = new XmlTextWriter(xmlFilePath + xmlOutputFileName, encoding);

        using (writer)
        {
            writer.Formatting = Formatting.Indented;
            writer.IndentChar = '\t';
            writer.Indentation = 1;

            writer.WriteStartDocument();
            writer.WriteStartElement("Albums");

            XmlReader reader = XmlReader.Create(xmlFilePath + xmlInputFileName);
            using (reader)
            {
                string name = string.Empty;
                string artist = string.Empty;

                while (reader.Read())
                {
                    if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "name"))
                    {
                        name = reader.ReadElementString();
                    }

                    if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "artist"))
                    {
                        artist = reader.ReadElementString();

                        writer.WriteStartElement("Album");
                        writer.WriteElementString("Name", name);
                        writer.WriteElementString("Artist", artist);
                        writer.WriteEndElement();
                    }
                }
            }

            writer.WriteEndDocument();
        }
    }
}