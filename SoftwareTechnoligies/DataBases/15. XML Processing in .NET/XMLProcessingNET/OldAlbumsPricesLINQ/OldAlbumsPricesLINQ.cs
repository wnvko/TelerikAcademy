using System;
using System.Linq;
using System.Xml.Linq;

public class OldAlbumsPricesLINQ
{
    private static string xmlFilePath = @"../../../temp";
    private static string xmlFileName = @"/01.collection.xml";

    public static void Main()
    {
        XDocument xmlDoc = XDocument.Load(xmlFilePath + xmlFileName);

        var prices = xmlDoc.Descendants("album")
                     .Where(a => int.Parse(a.Element("year").Value) < DateTime.Now.AddYears(-5).Year)
                     .Select(p => new { Price = p.Element("price").Value });

        foreach (var price in prices)
        {
            Console.WriteLine(price.Price);
        }
    }
}