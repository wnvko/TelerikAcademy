namespace Employees
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Model;

    public partial class EmpDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["id"] == null)
            {
                Response.Redirect("GridView.aspx");
            }

            var customerId = Request.Params["id"];
            var db = new NWContext();
            var customer = new List<Customer>() { db.Customers.FirstOrDefault(c => c.CustomerID == customerId) };
            this.dvDetails.DataSource = customer;
            this.dvDetails.DataBind();
        }
    }
}