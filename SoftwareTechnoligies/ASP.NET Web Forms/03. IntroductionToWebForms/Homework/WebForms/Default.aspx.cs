namespace WebForms
{
    using System;
    using System.Reflection;
    using System.Web.UI;

    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.LabelLocation.Text = Assembly.GetExecutingAssembly().Location;
        }
    }
}