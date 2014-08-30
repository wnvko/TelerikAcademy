using System;
using System.Windows.Forms;

namespace MyRedisDictionary
{
    public partial class Dictionary : Form
    {
        public Dictionary()
        {
            InitializeComponent();
        }

        private void btnAddWord_Click(object sender, EventArgs e)
        {
            AddWord form = new AddWord();
            form.ShowDialog(this);
        }

        private void btnFindWord_Click(object sender, EventArgs e)
        {
            FindWord form = new FindWord();
            form.ShowDialog(this);
        }

        private void btnListAllWords_Click(object sender, EventArgs e)
        {
            ListAllWords form = new ListAllWords();
            form.ShowDialog(this);
        }
    }
}
