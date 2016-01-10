namespace Escaping
{
    using System;
    using System.Web.UI;

    public partial class main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.textResult.ValidateRequestMode = ValidateRequestMode.Disabled;
            this.labelResult.ValidateRequestMode = ValidateRequestMode.Disabled;
            this.buttonSubmit.Click += ButtonSubmit_Click;
        }

        private void ButtonSubmit_Click(object sender, EventArgs e)
        {
            var result = this.textInput.Text;
            this.textResult.Text = result;
            this.labelResult.Text = result;
        }
    }
}