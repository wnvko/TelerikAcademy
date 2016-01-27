namespace ZipFilesToText
{
    using System;
    using System.IO;
    using System.IO.Compression;
    using System.Text;
    public partial class main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.buttonUpload.Click += this.ButtonUpload_Click;
        }

        private void ButtonUpload_Click(object sender, EventArgs e)
        {
            if (this.fileUpload.HasFile)
            {
                try
                {
                    if (fileUpload.PostedFile.ContentType == "application/x-zip-compressed")
                    {
                        using (var fileStream = this.fileUpload.PostedFile.InputStream)
                        {
                            var result = new StringBuilder();
                            var zipArchie = new ZipArchive(fileStream, ZipArchiveMode.Read, false);
                            foreach (ZipArchiveEntry textFile in zipArchie.Entries)
                            {
                                if (textFile.Name.IndexOf(".txt") == textFile.Name.Length - 4)
                                {
                                    result.AppendLine("<p>File " + textFile.Name + "<//p><br //>");
                                    result.AppendLine();
                                    using (var stream = textFile.Open())
                                    {
                                        using (var reader = new StreamReader(stream))
                                        {
                                            result.Append("<p>");
                                            result.AppendLine(reader.ReadToEnd());
                                            result.Append("<//p>");
                                        }
                                    }
                                }
                            }

                            this.labelResult.Text = result.ToString();
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}