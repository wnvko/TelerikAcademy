using System;
using System.Windows.Forms;

namespace MyRedisDictionary
{
    public partial class AddWord : Form
    {
        public AddWord()
        {
            InitializeComponent();
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