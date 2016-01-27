namespace Employees
{
    using System;
    using System.Linq;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using Model;

    public partial class ListViewCustomers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                return;
            }

            var db = new NWContext();
            this.lvCustomers.DataSource = db.Customers.ToList();
            this.lvCustomers.DataBind();
        }

        public string GetUrl(string id)
        {
            return "EmpDetailsWithFormView.aspx?id=" + id;
        }

    }
}