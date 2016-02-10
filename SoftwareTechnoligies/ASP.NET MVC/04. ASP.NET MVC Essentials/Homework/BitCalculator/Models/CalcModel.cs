namespace BitCalculator.Models
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class CalcModel
    {
        public CalcModel()
        {
            this.Types = this.GetTypes();
        }

        public List<SelectListItem> Types { get; set; }

        public double Modifier { get; set; }

        public int Quantity { get; set; }

        private List<SelectListItem> GetTypes()
        {
            var types = new List<SelectListItem>();
            types.Add(new SelectListItem() { Text = "Bit - b", Value = "b" });
            types.Add(new SelectListItem() { Text = "Byte - B", Value = "B" });
            types.Add(new SelectListItem() { Text = "Kilobit - Kb", Value = "Kb" });
            types.Add(new SelectListItem() { Text = "Kilobyte - KB", Value = "KB" });
            types.Add(new SelectListItem() { Text = "Megabit - Mb", Value = "Mb" });
            types.Add(new SelectListItem() { Text = "Megabyte - MB", Value = "MB" });
            types.Add(new SelectListItem() { Text = "Gigabit - Gb", Value = "Gb" });
            types.Add(new SelectListItem() { Text = "Gigabyte - GB", Value = "GB" });
            types.Add(new SelectListItem() { Text = "Terabit - Tb", Value = "Tb" });
            types.Add(new SelectListItem() { Text = "Terabyte - TB", Value = "TB" });
            types.Add(new SelectListItem() { Text = "Petabit - Pb", Value = "Pb" });
            types.Add(new SelectListItem() { Text = "Petabyte - PB", Value = "PB" });
            types.Add(new SelectListItem() { Text = "Exabit - Eb", Value = "Eb" });
            types.Add(new SelectListItem() { Text = "Exabyte - EB", Value = "EB" });
            types.Add(new SelectListItem() { Text = "Zettabit - Zb", Value = "Zb" });
            types.Add(new SelectListItem() { Text = "Zetaabyte - ZB", Value = "ZB" });
            types.Add(new SelectListItem() { Text = "Yottabit - Yb", Value = "Yb" });
            types.Add(new SelectListItem() { Text = "Yottabyte - YB", Value = "YB" });

            return types;
        }
    }
}