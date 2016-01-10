namespace Users
{
    using System;
    using System.Web.UI.HtmlControls;
    public partial class more : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var info = (HtmlGenericControl)Page.Master.FindControl("info");
            var friends = (HtmlGenericControl)Page.Master.FindControl("friends");
            var more = (HtmlGenericControl)Page.Master.FindControl("more");

            more.Attributes.Add("class", "active");

            info.Attributes.Remove("class");
            friends.Attributes.Remove("class");
        }
    }
}