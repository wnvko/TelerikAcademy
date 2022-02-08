using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace MyRedisDictionary
{
    public partial class ListAllWords : Form
    {
        public ListAllWords()
        {
            InitializeComponent();
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
        }

        private void ListAllWords_Load(object sender, EventArgs e)
        {
            ClientForRedis my = ClientForRedis.Instance();
            SortedDictionary<string, string> allWords = my.ListAllWords();

            DataTable myDataTable = CreateDataTable(allWords);
            this.dataGridView1.DataSource = myDataTable;
            this.dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridView1.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.RowHeadersVisible = false;
        }

        private DataTable CreateDataTable(SortedDictionary<string, string> allWords)
        {
            DataTable myDataTable = new DataTable("myDataTable");
            myDataTable.Columns.Add("Word", typeof(string));
            myDataTable.Columns.Add("Meaning", typeof(string));

            foreach (var word in allWords)
            {
                DataRow myRow = myDataTable.NewRow();
                myRow["Word"] = word.Key;
                myRow["Meaning"] = word.Value;

                myDataTable.Rows.Add(myRow);
            }

            return myDataTable;
        }
    }
}
