namespace RandomNumberGeneratorWebControls
{
    using System;

    public partial class main : System.Web.UI.Page
    {
        private Random random;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.random = new Random();
            this.buttonGenerate.Click += ButtonGenerate_Click;

        }

        private void ButtonGenerate_Click(object sender, EventArgs e)
        {
            int min = 0;
            bool minNumberIsCorrect = int.TryParse(this.textMin.Text, out min);
            if (!minNumberIsCorrect)
            {
                this.labelResult.Text = "Please enter correct Min number!";
                return;
            }

            int max = 0;
            bool maxNumberIsCorrect = int.TryParse(this.textMax.Text, out max);
            if (!maxNumberIsCorrect)
            {
                this.labelResult.Text = "Please enter correct Max number!";
                return;
            }

            if (min > max)
            {
                this.labelResult.Text = "Min number should be less than Max number!";
                return;
            }

            var randomNumber = this.random.Next(min, max + 1);
            this.labelResult.Text = $"Random number between {min} and {max}: {randomNumber}";
        }
    }
}