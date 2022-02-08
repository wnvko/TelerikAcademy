using System;
using System.Windows.Forms;

namespace MyRedisDictionary
{
    public partial class FindWord : Form
    {
        private const string NoResult = "The word {0} does not exist in the dictionary";

        public FindWord()
        {
            InitializeComponent();
        }

        private void brnFindWord_Click(object sender, EventArgs e)
        {
            ClientForRedis my = ClientForRedis.Instance();
            string word = this.tbWordToFind.Text;
            string result = my.FindWord(word);

            if (result != null && result != string.Empty)
            {
                this.tbResult.Text = result;
            }
            else
            {
                this.tbResult.Text = string.Format(NoResult, word);
            }
        }
    }
}
