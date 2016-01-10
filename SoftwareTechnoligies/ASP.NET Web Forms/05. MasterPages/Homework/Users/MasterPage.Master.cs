namespace Users
{
    using System;
    using System.Web.UI.HtmlControls;

    public partial class MasterPage : System.Web.UI.MasterPage
    {
        public HtmlGenericControl Info
        {
            get { return this.info; }
            set { this.info = value; }
        }

        public HtmlGenericControl Fiends
        {
            get { return this.friends; }
            set { this.friends = value; }
        }

        public HtmlGenericControl More
        {
            get { return this.more; }
            set { this.more = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}