using System;
using System.Collections.Generic;
using System.Xml;

public class ArtistsWithDOM
{
    private static string xmlFilePath = @"../../../temp";
    private static string xmlFileName = @"/01.collection.xml";

    public static void Main()
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(xmlFilePath + xmlFileName);
        string xPathQuery = @"/catalogue/album/artist";
        XmlNodeList artists = xmlDoc.SelectNodes(xPathQuery);

        Dictionary<string, int> artistsCount = new Dictionary<string, int>();
        foreach (XmlNode artist in artists)
        {
            string name = artist.InnerText;
            if (!artistsCount.ContainsKey(name))
            {
                artistsCount[name] = 0;
            }

            artistsCount[name]++;
        }

        foreach (var artist in artistsCount)
        {
            Console.WriteLine("{0} is with {1} albums in the collection", artist.Key, artist.Value);
        }
    }
}
