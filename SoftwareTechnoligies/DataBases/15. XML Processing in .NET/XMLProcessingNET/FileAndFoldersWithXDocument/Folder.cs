using System;
using System.Collections.Generic;

public class Folder
{
    private string name;
    private List<File> files;
    private List<Folder> childFolders;

    public Folder(string name)
    {
        this.Name = name;
        this.files = new List<File>();
        this.childFolders = new List<Folder>();
    }

    public string Name
    {
        get { return this.name; }
        private set { this.name = value; }
    }

    public List<File> Files
    {
        get { return this.files; }
    }

    public List<Folder> ChildFolders
    {
        get { return this.childFolders; }
    }

    public void AddFile(params File[] files)
    {
        this.files.AddRange(files);
    }

    public void AddFolder(params Folder[] folders)
    {
        this.childFolders.AddRange(folders);
    }
}
