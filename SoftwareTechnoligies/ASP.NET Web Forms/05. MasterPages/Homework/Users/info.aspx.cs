namespace Users
{
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;

    public partial class info : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var info = (HtmlGenericControl)Page.Master.FindControl("info");
            var friends = (HtmlGenericControl)Page.Master.FindControl("friends");
            var more = (HtmlGenericControl)Page.Master.FindControl("more");

            info.Attributes.Add("class", "active");

            more.Attributes.Remove("class");
            friends.Attributes.Remove("class");

        }
    }
}