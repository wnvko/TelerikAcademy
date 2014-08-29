namespace FoldersAndFiles
{
    public class File
    {
        private string name;
        private long size;

        public File(string name, long size)
        {
            this.Name = name;
            this.Size = size;
        }

        public string Name
        {
            get { return this.name; }
            private set { this.name = value; }
        }

        public long Size
        {
            get { return this.size; }
            private set { this.size = value; }
        }
    }
}
