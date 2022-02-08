using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

public class FileAndFoldersWithXDocument
{
    public const string FolderName = @"D:\TelerikAcademy";
    private static string xmlFilePath = @"../../../temp";
    private static string xmlFileName = @"/10.FilesAndFolders.xml";

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
        XElement foldersStructure = new XElement("FoldersStructure");

        AddFolderToXml(foldersStructure, rootFolder);
        foldersStructure.Save(xmlFilePath + xmlFileName);
    }

    private static void AddFolderToXml(XElement foldersStructure, Folder rootFolder)
    {
        foreach (Folder folder in rootFolder.ChildFolders)
        {
            XElement filesAndFolders = new XElement("FilesAndFolders");
            XElement currentFolder = new XElement("Folder", folder.Name);

            AddFolderToXml(currentFolder, folder);

            XElement files = new XElement("Files");
            foreach (File file in rootFolder.Files)
            {
                files.Add(new XElement("File", file.Name));
            }

            currentFolder.Add(files);
            filesAndFolders.Add(currentFolder);
            foldersStructure.Add(filesAndFolders);
        }
    }
}
