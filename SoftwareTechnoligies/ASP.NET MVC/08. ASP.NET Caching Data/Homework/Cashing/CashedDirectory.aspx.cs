namespace Cashing
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web.Caching;

    public partial class CashedDirectory : System.Web.UI.Page
    {
        private FileInfo[] files;

        protected void Page_Load(object sender, EventArgs e)
        {
            var drives = DriveInfo.GetDrives();
            DirectoryInfo directoryInfo = null;
            foreach (var drive in drives)
            {
                if (drive.DriveType == DriveType.Fixed && !drive.Name.Contains("C"))
                {
                    directoryInfo = drive.RootDirectory;
                }
            }

            if (directoryInfo != null)
            {
                this.files = directoryInfo.GetFiles();
                this.directorySpan.InnerText = directoryInfo.Name;
            }
            else
            {
                this.directorySpan.InnerText = "No such directory";
            }

            if (this.Cache["directoryCashe"] == null)
            {
                var dependency = new CacheDependency(directoryInfo.Name);
                var content = this.GetFilesName();
                this.Cache.Insert(
                    key: "directoryCashe",
                   value: content,
                   dependencies: dependency,
                   absoluteExpiration: DateTime.Now.AddHours(1),
                   slidingExpiration: TimeSpan.Zero);
            }

        }

        public IEnumerable filesRepeater_GetData()
        {
            return this.Cache["directoryCashe"] as IEnumerable<string>;
        }

        private IEnumerable GetFilesName()
        {
            if (this.files != null)
            {
                return this.files.Select(f => f.Name).ToList();
            }
            else
            {
                return new List<string>() { "No files found" };
            }
        }
    }
}