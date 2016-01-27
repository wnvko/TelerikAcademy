namespace PagesWithLogin
{
    using System;
    using System.Web;

    public partial class login : System.Web.UI.Page
    {
        private string cookieName = "Logged";
        private string cookieValue = "You are the lucky one! You are in!";
        protected void Page_Load(object sender, EventArgs e)
        {
            this.buttonLogin.Click += ButtonLogin_Click;
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            var cookie = new HttpCookie(this.cookieName, this.cookieValue);
            cookie.Expires = DateTime.Now.AddMinutes(1);
            this.Response.Cookies.Add(cookie);
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies[this.cookieName];
            if (cookie != null)
            {
                this.Response.Redirect("logged.aspx");
            }
        }
    }
}