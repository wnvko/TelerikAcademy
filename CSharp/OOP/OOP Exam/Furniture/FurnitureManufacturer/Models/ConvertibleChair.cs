namespace FurnitureManufacturer.Models
{
    using FurnitureManufacturer.Interfaces;
    public class ConvertibleChair : Chair, IConvertibleChair
    {
        private decimal initialHeight;

        public ConvertibleChair(string model, string material, decimal price, decimal height, int numberOfLegs)
            : base(model, material, price, height, numberOfLegs)
        {
            this.initialHeight = this.Height;
            this.IsConverted = false;
        }
        public bool IsConverted { get; private set; }

        public void Convert()
        {
            if (IsConverted)
            {
                this.Height = initialHeight;
            }
            else
            {
                this.Height = 0.10m;
            }

            this.IsConverted = !IsConverted;
        }

        public override string ToString()
        {
            string baseValue = base.ToString();
            return string.Format("{0}, State: {1}",
                                 baseValue,
                                 this.IsConverted ? "Converted" : "Normal");
        }
    }
}
