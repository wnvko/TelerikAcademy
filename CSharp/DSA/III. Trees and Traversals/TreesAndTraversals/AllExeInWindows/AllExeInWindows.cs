using System;
using System.Collections.Generic;
using System.IO;

public class AllExeInWindows
{
    public const string WindowsPath = @"D:\TelerikAcademy";
    public const string FilePatern = @"*.cs";
    public static int filesCount = 0;

    public static void Main()
    {
        if (File.Exists(WindowsPath))
        {
            ProcessFile(WindowsPath);
        }
        else if (Directory.Exists(WindowsPath))
        {
            ProcessDirectory(WindowsPath);
        }
        else
        {
            Console.WriteLine("{0} is not a lalid path", WindowsPath);
        }

        Console.WriteLine();
        Console.WriteLine("In total {0} files of type {1}", filesCount, FilePatern);
    }

    private static void ProcessDirectory(string windowsPath)
    {
        string[] files = Directory.GetFiles(windowsPath, FilePatern);
        foreach (var file in files)
        {
            ProcessFile(file);
        }

        string[] subDirs = Directory.GetDirectories(windowsPath);
        foreach (var subDir in subDirs)
        {
            ProcessDirectory(subDir);
        }
    }

    private static void ProcessFile(string windowsPath)
    {
        Console.WriteLine("Files {0}", windowsPath);
        filesCount++;
    }
}
