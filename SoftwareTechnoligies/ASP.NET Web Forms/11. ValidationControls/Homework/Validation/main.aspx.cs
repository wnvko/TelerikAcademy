namespace Validation
{
    using System;
    using System.Web.UI.WebControls;

    public partial class main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.buttonSubmit.Click += ButtonSubmit_Click;
            this.rbSex.SelectedIndexChanged += RbSex_SelectedIndexChanged;
            this.cblBestForHim.Visible = false;
            this.cblBestForHer.Visible = false;
        }

        private void RbSex_SelectedIndexChanged(object sender, EventArgs e)
        {
            var radioButtonList = sender as RadioButtonList;
            if (radioButtonList != null)
            {
                switch (radioButtonList.SelectedValue)
                {
                    case "male":
                        this.cblBestForHim.Visible = true;
                        this.cblBestForHer.Visible = false;
                        break;
                    case "female":
                        this.cblBestForHim.Visible = false;
                        this.cblBestForHer.Visible = true;
                        break;
                }
            }
        }

        private void ButtonSubmit_Click(object sender, EventArgs e)
        {
            this.Page.Validate("vgLogon");
            this.Page.Validate("vgPersonal");
            this.Page.Validate("vgAddress");
        }
    }
}