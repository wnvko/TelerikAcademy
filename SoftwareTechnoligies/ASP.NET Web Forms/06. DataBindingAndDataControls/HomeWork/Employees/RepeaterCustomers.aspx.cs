namespace Employees
{
    using System;
    using System.Linq;
    using Model;

    public partial class RepeaterCustomers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                return;
            }

            var db = new NWContext();
            this.repCustomers.DataSource = db.Customers.ToList();
            this.repCustomers.DataBind();
        }

        public string GetUrl(string id)
        {
            return "EmpDetails.aspx?id=" + id;
        }
    }
}