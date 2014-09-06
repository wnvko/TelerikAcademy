using System.Xml;

public class ArtistsWithDOM
{
    private static string xmlFilePath = @"../../../temp";
    private static string inputXmlFileName = @"/01.collection.xml";
    private static string outputXmlFileName = @"/04.cheapCollection.xml";

    public static void Main()
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(xmlFilePath + inputXmlFileName);
        string xPathQuery = @"/catalogue/album[price>20]/price";
        XmlNodeList expensiveAlbums = xmlDoc.SelectNodes(xPathQuery);

        foreach (XmlNode album in expensiveAlbums)
        {
            XmlNode nodeToRemve = album.ParentNode;
            nodeToRemve.ParentNode.RemoveChild(nodeToRemve);
        }

        xmlDoc.Save(xmlFilePath + outputXmlFileName);
    }
}
