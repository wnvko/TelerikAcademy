namespace ReadExcelFile
{
    using System;
    using System.Data.OleDb;
    using System.IO;
    using System.Windows.Forms;

    public class Program
    {
        public static void Main(string[] args)
        {
            string filePath = Path.GetDirectoryName(Application.ExecutablePath);
            filePath = filePath.Substring(0, filePath.IndexOf("bin"));
            string fileName = "myWorksheet.xlsx";

            string csProvider = @"Provider=Microsoft.ACE.OLEDB.12.0; ";
            string csDataSource = string.Format("Data Source = {0}; ", filePath + fileName);
            string csExtendedProperties = @"Extended Properties = ""Excel 12.0 Xml; HDR = YES"";";
            string connectionString = csProvider + csDataSource + csExtendedProperties;

            OleDbConnection conExcel = new OleDbConnection(connectionString);
            conExcel.Open();

            using (conExcel)
            {
                OleDbCommand cmdExcel = new OleDbCommand("SELECT * FROM [Sheet1$] AS s", conExcel);
                OleDbDataReader reader = cmdExcel.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        if (reader["Name"] is System.DBNull || reader["Score"] is System.DBNull)
                        {
                            continue;
                        }

                        string name = (string)reader["Name"];
                        double score = (double)reader["Score"];
                        Console.WriteLine("{0} has scored {1}", name, score);
                    }
                }

                OleDbCommand cmdInsertIntoExcel = new OleDbCommand("INSERT INTO [Sheet1$](Name, Score) VALUES('Pesho', 100)", conExcel);
                cmdInsertIntoExcel.ExecuteNonQuery();
            }
        }
    }
}
