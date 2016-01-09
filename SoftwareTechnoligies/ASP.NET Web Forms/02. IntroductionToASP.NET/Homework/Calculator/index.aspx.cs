namespace Calculator
{
    using System;
    using System.Web.UI.WebControls;

    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox_TextChanged(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            if (sender != null)
            {
                double input = 0;
                input = GetInput(textBox);
            }
        }

        private static double GetInput(TextBox textBox)
        {
            double input;
            var inputIsNumber = double.TryParse(textBox.Text, out input);
            if (!inputIsNumber)
            {
                textBox.Text = string.Empty;
            }

            return input;
        }

        protected void OnButtonSumClick(object sender, EventArgs e)
        {
            double firstNum = GetInput(this.TextBox1);
            double secondNum = GetInput(this.TextBox2);

            this.TextBox3.Text = (firstNum + secondNum).ToString();
        }
    }
}