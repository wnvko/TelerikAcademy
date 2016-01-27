namespace PagesWithLogin
{
    using System;
    using System.Web;

    public partial class logged : System.Web.UI.Page
    {
        private string cookieName = "Logged";

        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies[this.cookieName];
            if (cookie == null)
            {
                this.Response.Redirect("login.aspx");
            }

        }
    }
}