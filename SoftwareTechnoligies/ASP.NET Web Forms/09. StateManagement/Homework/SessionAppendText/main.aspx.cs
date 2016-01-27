namespace SessionAppendText
{
    using System;
    using System.Collections.Generic;
    public partial class main : System.Web.UI.Page
    {
        private string stringsKey = "Strings";
        protected void Page_Load(object sender, EventArgs e)
        {
            this.buttonSubmit.Click += ButtonSubmit_Click;
        }

        private void ButtonSubmit_Click(object sender, EventArgs e)
        {
            ((List<string>)this.Session[this.stringsKey]).Add(this.textBoxInput.Text);
        }

        protected override void OnPreRender(EventArgs e)
        {
            if (this.Session[this.stringsKey] == null)
            {
                this.Session[this.stringsKey] = new List<string>();
            }

            this.labelResult.Text = string.Empty;
            foreach (var value in (List<string>)this.Session[this.stringsKey])
            {
                this.labelResult.Text += value + "<br //>";
            }

            base.OnPreRender(e);
        }
    }
}