using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace SaveAllPictures
{
    class Program
    {
        static void Main()
        {
            SqlConnection dbCon = new SqlConnection("Server=.; Database=Northwind; Integrated Security=true");
            string picturePath = Path.GetDirectoryName(Application.ExecutablePath);
            string pictureName = "picture{0}.jpg";
            List<byte[]> picture = new List<byte[]>();
            int pictureNumber = 0;

            dbCon.Open();
            using (dbCon)
            {
                SqlCommand cmdGetPictures = new SqlCommand("SELECT c.Picture FROM  Categories AS c", dbCon);
                SqlDataReader reader = cmdGetPictures.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        picture.Add((byte[])reader["Picture"]);
                        string pictureFileName = Path.Combine(picturePath, string.Format(pictureName, pictureNumber));

                        FileStream stream = File.OpenWrite(pictureFileName);
                        using (stream)
                        {
                            stream.Write(picture[pictureNumber], 0, picture.ToArray().Length);
                        }

                        pictureNumber++;
                    }
                }
            }
        }
    }
}
