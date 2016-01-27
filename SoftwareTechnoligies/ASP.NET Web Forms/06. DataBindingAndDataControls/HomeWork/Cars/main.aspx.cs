namespace Cars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web.UI.WebControls;

    public partial class main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ddlMade.SelectedIndexChanged += this.DropdWownListMade_SelectedIndexChanged;
            this.ddlMade.AutoPostBack = true;
            this.buttonSubmit.Click += this.ButtonSubmit_Click;
            this.buttonSubmit.Text = "Search your new car!";

            if (Page.IsPostBack)
            {
                return;
            }

            this.ddlMade.DataSource = this.GetCars();
            this.ddlMade.DataTextField = "Name";
            this.ddlMade.DataBind();

            this.cblExtras.DataSource = this.GetExtras();
            this.cblExtras.DataTextField = "Name";
            this.cblExtras.DataBind();

            this.rblEngine.DataSource = new string[] { "Petrol", "Diesel", "Electric" };
            this.rblEngine.SelectedIndex = 0;
            this.rblEngine.DataBind();
        }

        private List<Producer> GetCars()
        {
            var producers = new List<Producer>();
            var audi = new Producer() { Name = "Audi" };
            audi.Models.AddRange(new string[] { "A1", "A2", "A3", "A4", "A5", "A6", "A7", "A7" });
            producers.Add(audi);

            var bmw = new Producer() { Name = "BMW" };
            bmw.Models.AddRange(new string[] { "Z1", "Z3", "Z4", "Z8" });
            producers.Add(bmw);

            var citroen = new Producer() { Name = "Citroen" };
            citroen.Models.AddRange(new string[] { "C1", "C2", "C3", "C4", "C5", "C6", "C7", "C8" });
            producers.Add(citroen);

            return producers;
        }

        private void DropdWownListMade_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ddlSender = sender as DropDownList;
            var producer = this.GetCars().FirstOrDefault(p => p.Name == ddlSender.Text);

            this.ddlModel.DataSource = producer.Models;
            this.ddlModel.DataBind();
            this.ddlModel.SelectedIndex = 0;
        }

        private List<Extra> GetExtras()
        {
            var extras = new List<Extra>()
            {
                new Extra() {Name="ABS", Description="Anti-lock Braking System" },
                new Extra() {Name="ACC", Description="Autonomous Cruise Control System" },
                new Extra() {Name="APS", Description="Automated Park system" },
                new Extra() {Name="EPS", Description="Electric Power Assisted Steering" },
                new Extra() {Name="ESP", Description="Electronic Stability Program" },
                new Extra() {Name="TRC", Description="Traction Control System" },
            };

            return extras;
        }

        private void ButtonSubmit_Click(object sender, EventArgs e)
        {
            var result = new StringBuilder();
            result.AppendFormat("<p>Produer: {0}<//p>", this.ddlMade.Text);
            result.AppendFormat("<p>Model: {0}<//p>", this.ddlModel.Text);
            result.AppendFormat("<p>Engine: {0}<//p>", this.rblEngine.SelectedValue);
            if (this.cblExtras.Items.Cast<ListItem>().Any(li => li.Selected))
            {
                result.AppendLine("<p>Extras:<//p>");
                foreach (ListItem item in this.cblExtras.Items)
                {
                    if (item.Selected)
                    {
                        var extra = this.GetExtras().FirstOrDefault(ex => ex.Name == item.Text);
                        result.AppendFormat("<p>{0} - {1}<//p>", extra.Name, extra.Description);
                    }
                }
            }
            else
            {
                result.AppendLine("No extras, so sad!");
            }

            this.literalResult.Text = result.ToString();
        }
    }
}