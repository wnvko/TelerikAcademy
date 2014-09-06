using System;
using System.Linq;
using System.Xml.Linq;

public class ArtistsWithDOM
{
    private static string xmlFilePath = @"../../../temp";
    private static string xmlFileName = @"/01.collection.xml";

    public static void Main()
    {
        XDocument xmlDoc = XDocument.Load(xmlFilePath + xmlFileName);
        var artistsCount = xmlDoc.Descendants("artist")
                           .GroupBy(a => a.Value)
                           .Select(a => new { Name = a.Key, Count = a.Count() });
                           
                            

        foreach (var artist in artistsCount)
        {
            Console.WriteLine("{0} is with {1} albums in the collection", artist.Name, artist.Count);
        }
    }
}
