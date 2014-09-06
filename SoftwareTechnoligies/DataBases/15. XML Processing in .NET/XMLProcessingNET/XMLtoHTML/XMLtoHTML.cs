using System.Xml.Xsl;

public class XSLTransform
{
    private static string xmlFilePath = @"../../../temp";
    private static string xmlFileName = @"/01.collection.xml";
    private static string xsltFileName = @"../../album.xslt";
    private static string htmlFileName = @"/14.collection.html";


    public static void Main()
    {
        XslCompiledTransform xslt = new XslCompiledTransform();
        xslt.Load(xsltFileName);
        xslt.Transform(xmlFilePath+xmlFileName, xmlFilePath+htmlFileName);
    }
}
