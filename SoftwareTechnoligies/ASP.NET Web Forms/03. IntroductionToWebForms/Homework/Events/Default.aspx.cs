namespace Events
{
    using System;
    using System.Web.UI;

    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.labelEvents.Text = "All events: ";
            var allEvents = this.GetType().GetEvents();
            foreach (var ev in allEvents)
            {
                this.labelEvents.Text += ev.Name;
            }
        }
    }
}