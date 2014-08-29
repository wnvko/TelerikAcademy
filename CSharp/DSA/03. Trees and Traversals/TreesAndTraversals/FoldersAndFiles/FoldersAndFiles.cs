namespace FoldersAndFiles
{
    using System;
    using System.IO;

    class FoldersAndFiles
    {
        public const string FolderName = @"D:\TelerikAcademy";
        static void Main()
        {
            Folder myFolders = new Folder(FolderName);
            AddFolders(myFolders);
            long totalFileSize = CalculateFilesSize(myFolders);
            Console.WriteLine("Total file size in {0} is {1} bytes", FolderName, totalFileSize);
            Console.WriteLine();
        }

        public static void AddFolders(Folder myFolder)
        {
            string[] fileNames = Directory.GetFiles(myFolder.Name);
            foreach (var fileName in fileNames)
            {
                FileInfo thisFile = new FileInfo(fileName);
                myFolder.AddFile(new File(fileName, thisFile.Length));
            }

            string[] childFoldersNames = Directory.GetDirectories(myFolder.Name);
            foreach (var childFolderName in childFoldersNames)
            {
                Folder childFolder = new Folder(childFolderName);
                myFolder.AddFolder(childFolder);
                AddFolders(childFolder);
            }
        }

        public static long CalculateFilesSize(Folder myFolder)
        {
            long totalFileSize = 0;
            foreach (var file in myFolder.Files)
            {
                totalFileSize += file.Size;
            }

            foreach (var folder in myFolder.ChildFolders)
            {
                totalFileSize += CalculateFilesSize(folder);
            }

            return totalFileSize;
        }
    }
}