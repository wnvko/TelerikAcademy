namespace MyRedisDictionary
{
    using System;
    using System.Windows.Forms;

    public partial class Dictionary : Form
    {
        public Dictionary()
        {
            this.InitializeComponent();
        }

        private void BtnAddWord_Click(object sender, EventArgs e)
        {
            AddWord form = new AddWord();
            form.ShowDialog(this);
        }

        private void BtnFindWord_Click(object sender, EventArgs e)
        {
            FindWord form = new FindWord();
            form.ShowDialog(this);
        }

        private void BtnListAllWords_Click(object sender, EventArgs e)
        {
            ListAllWords form = new ListAllWords();
            form.ShowDialog(this);
        }
    }
}
