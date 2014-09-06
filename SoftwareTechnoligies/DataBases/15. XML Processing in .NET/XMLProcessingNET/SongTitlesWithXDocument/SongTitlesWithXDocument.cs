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
        var songTitles = xmlDoc.Descendants("title")
                           .Select(t => new { Name = t.Value });



        foreach (var title in songTitles)
        {
            Console.WriteLine(title.Name);
        }
    }
}
