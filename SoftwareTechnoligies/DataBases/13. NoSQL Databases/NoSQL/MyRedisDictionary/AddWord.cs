namespace MyRedisDictionary
{
    using System;
    using System.Windows.Forms;

    public partial class AddWord : Form
    {
        public AddWord()
        {
            this.InitializeComponent();
        }

        private void btnAddWord_Click(object sender, EventArgs e)
        {
            ClientForRedis my = ClientForRedis.Instance();
            string word = this.tbWord.Text;
            string meaning = this.tbMeaning.Text;
            my.AddWord(word, meaning);
            this.Close();
        }
    }
}