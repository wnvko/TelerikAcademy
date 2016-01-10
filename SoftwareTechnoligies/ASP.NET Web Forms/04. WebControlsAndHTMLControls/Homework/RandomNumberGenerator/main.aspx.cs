namespace RandomNumberGenerator
{
    using System;

    public partial class main : System.Web.UI.Page
    {
        private Random random;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.random = new Random();
            this.buttonGenerate.ServerClick += ButtonGenerate_ServerClick;
        }

        private void ButtonGenerate_ServerClick(object sender, EventArgs e)
        {
            int min = 0;
            bool minNumberIsCorrect = int.TryParse(this.textMin.Value, out min);
            if (!minNumberIsCorrect)
            {
                this.result.InnerText = "Please enter correct Min number!";
                return;
            }

            int max = 0;
            bool maxNumberIsCorrect = int.TryParse(this.textMax.Value, out max);
            if (!maxNumberIsCorrect)
            {
                this.result.InnerText = "Please enter correct Max number!";
                return;
            }

            if (min > max)
            {
                this.result.InnerText = "Min number should be less than Max number!";
                return;
            }

            var randomNumber = this.random.Next(min, max + 1);
            this.result.InnerText = $"Random number between {min} and {max}: {randomNumber}";
        }
    }
}