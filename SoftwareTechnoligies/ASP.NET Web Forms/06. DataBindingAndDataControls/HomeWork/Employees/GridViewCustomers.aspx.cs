namespace Employees
{
    using System;
    using System.Linq;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using Model;

    public partial class GridViewCustomers1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.gvCustomers.PageIndexChanging += this.gvCustomers_PageIndexChanging;
            if (Page.IsPostBack)
            {
                return;
            }

            this.SetDataBinding();
        }

        private void gvCustomers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            var grid = sender as GridView;
            if (grid != null)
            {
                grid.PageIndex = e.NewPageIndex;
                this.SetDataBinding();
            }
        }

        private void SetDataBinding()
        {
            var db = new NWContext();
            this.gvCustomers.DataSource = db.Customers.ToList();
            this.gvCustomers.DataBind();
        }
    }
}