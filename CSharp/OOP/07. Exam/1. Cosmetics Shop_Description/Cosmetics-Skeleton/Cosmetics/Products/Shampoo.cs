namespace Cosmetics.Products
{
    using System.Text;

    using Cosmetics.Common;
    using Cosmetics.Contracts;

    public class Shampoo : Product, IShampoo
    {
        private const string QuantityString = "  * Quantity: {0} ml";
        private const string UsageString = "  * Usage: {0}";

        private uint milliliters;
        private UsageType usage;

        public Shampoo(string name, string brand, decimal price, GenderType gender, uint milliliters, UsageType usage)
            : base(name, brand, price, gender)
        {
            this.Milliliters = milliliters;
            this.Usage = usage;
        }

        public uint Milliliters
        {
            get { return this.milliliters; }
            private set { this.milliliters = value; }
        }

        public UsageType Usage
        {
            get { return this.usage; }
            private set { this.usage = value; }
        }

        public override string Print()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(base.Print());
            result.AppendLine(string.Format(QuantityString, this.Milliliters));
            result.AppendLine(string.Format(UsageString, this.Usage.ToString()));

            return result.ToString();
        }
    }
}
