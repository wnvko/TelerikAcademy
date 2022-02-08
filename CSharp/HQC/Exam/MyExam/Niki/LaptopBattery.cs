namespace Computers
{
    using Contracts;

    public class LaptopBattery : IBattery
    {
        public const int InitialCharge = 50;

        internal LaptopBattery()
        {
            this.PercentCharge = InitialCharge;
        }

        public int PercentCharge { get; set; }

        public void Charge(int inputAmount)
        {
            this.PercentCharge += inputAmount;
            if (this.PercentCharge > 100)
            {
                this.PercentCharge = 100;
            }

            if (this.PercentCharge < 0)
            {
                this.PercentCharge = 0;
            }
        }
    }
}
