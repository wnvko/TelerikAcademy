namespace MyRedisDictionary
{
    using System;
    using System.Windows.Forms;

    public partial class FindWord : Form
    {
        private const string NoResult = "The word {0} does not exist in the dictionary";

        public FindWord()
        {
            this.InitializeComponent();
        }

        private void BtnFindWord_Click(object sender, EventArgs e)
        {
            ClientForRedis redisClient = ClientForRedis.Instance();
            string word = this.tbWordToFind.Text;
            string result = redisClient.FindWord(word);

            if (!string.IsNullOrEmpty(result))
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
