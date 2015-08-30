namespace MyRedisDictionary
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Windows.Forms;

    public partial class ListAllWords : Form
    {
        public ListAllWords()
        {
            this.InitializeComponent();
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
        }

        private void ListAllWords_Load(object sender, EventArgs e)
        {
            ClientForRedis redisClient = ClientForRedis.Instance();
            SortedDictionary<string, string> allWords = redisClient.ListAllWords();

            DataTable myDataTable = this.CreateDataTable(allWords);
            this.dataGridView1.DataSource = myDataTable;
            this.dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridView1.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.RowHeadersVisible = false;
        }

        private DataTable CreateDataTable(SortedDictionary<string, string> allWords)
        {
            DataTable dataTable = new DataTable("DataTable");
            dataTable.Columns.Add("Word", typeof(string));
            dataTable.Columns.Add("Meaning", typeof(string));

            foreach (KeyValuePair<string, string> word in allWords)
            {
                DataRow row = dataTable.NewRow();
                row["Word"] = word.Key;
                row["Meaning"] = word.Value;

                dataTable.Rows.Add(row);
            }

            return dataTable;
        }
    }
}
