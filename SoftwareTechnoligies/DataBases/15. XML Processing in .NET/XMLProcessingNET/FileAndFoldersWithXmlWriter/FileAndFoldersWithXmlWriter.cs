using System.IO;
using System.Text;
using System.Xml;

public class FileAndFoldersWithXmlWriter
{
    public const string FolderName = @"D:\TelerikAcademy";
    private static string xmlFilePath = @"../../../temp";
    private static string xmlFileName = @"/09.FilesAndFolders.xml";

    static void Main()
    {
        Folder rootFolder = new Folder(FolderName);
        AddFolders(rootFolder);
        CreateXml(rootFolder);
    }

    public static void AddFolders(Folder folder)
    {
        string[] fileNames = Directory.GetFiles(folder.Name);
        foreach (var fileName in fileNames)
        {
            folder.AddFile(new File(fileName));
        }

        string[] childFoldersNames = Directory.GetDirectories(folder.Name);
        foreach (var childFolderName in childFoldersNames)
        {
            Folder childFolder = new Folder(childFolderName);
            folder.AddFolder(childFolder);
            AddFolders(childFolder);
        }
    }

    private static void CreateXml(Folder rootFolder)
    {
        Encoding encoding = Encoding.GetEncoding("windows-1251");
        XmlTextWriter writer = new XmlTextWriter(xmlFilePath + xmlFileName, encoding);
        using (writer)
        {
            writer.Formatting = Formatting.Indented;
            writer.IndentChar = '\t';
            writer.Indentation = 1;

            writer.WriteStartDocument();
            writer.WriteStartElement("FoldersStructure");

            AddFolderToXml(writer, rootFolder);

            writer.WriteEndDocument();
        }
    }

    private static void AddFolderToXml(XmlTextWriter writer, Folder rootFolder)
    {
        foreach (Folder folder in rootFolder.ChildFolders)
        {
            writer.WriteStartElement("FilesAndFolders");
            writer.WriteElementString("Folder", folder.Name);

            AddFolderToXml(writer, folder);

            writer.WriteStartElement("Files");
            foreach (File file in rootFolder.Files)
            {
                writer.WriteElementString("File", file.Name);
            }

            writer.WriteEndElement();
            writer.WriteEndElement();
        }
    }
}