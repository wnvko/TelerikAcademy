using System;
using System.Collections.Generic;
using System.Xml;

public class OldAlbumsPrices
{
    private static string xmlFilePath = @"../../../temp";
    private static string xmlFileName = @"/01.collection.xml";

    public static void Main()
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(xmlFilePath + xmlFileName);
        string xPathQuery = @"/catalogue/album[year<{0}]/price";
        XmlNodeList prices = xmlDoc.SelectNodes(string.Format(xPathQuery, DateTime.Now.AddYears(-5).Year));

        foreach (XmlNode price in prices)
        {
            Console.WriteLine(price.InnerText);
        }
    }
}
