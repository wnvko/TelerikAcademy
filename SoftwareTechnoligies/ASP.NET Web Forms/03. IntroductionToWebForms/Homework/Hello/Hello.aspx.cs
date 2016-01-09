namespace Hello
{
    using System;

    public partial class Hello : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ButtonSayHello.Click += ButtonSayHello_Click;
        }

        private void ButtonSayHello_Click(object sender, EventArgs e)
        {
            this.LabelHello.Text = $"Hello {this.TextBoxName.Text}!";
        }
    }
}