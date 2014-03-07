namespace FurnitureManufacturer.Models
{
    using FurnitureManufacturer.Interfaces;
    public class Table : Furniture, ITable
    {
        private decimal lenght;
        private decimal width;

        public Table(string model, string material, decimal price, decimal height, decimal lenght, decimal width)
            : base(model, material, price, height)
        {
            this.Length = lenght;
            this.Width = width;
        }

        public decimal Length
        {
            get
            {
                return this.lenght;
            }
            set
            {
                if (value <= 0)
                {
                    base.LessOrEqualToZeroException(this.Length.GetType().Name);
                }

                this.lenght = value;
            }
        }

        public decimal Width
        {
            get
            {
                return this.width;
            }

            private set
            {
                if (value <= 0)
                {
                    base.LessOrEqualToZeroException(this.Width.GetType().Name);
                }

                this.width = value;
            }
        }

        public decimal Area
        {
            get { return this.Width * this.Length; }
        }

        public override string ToString()
        {
            string baseValue = base.ToString();
            return string.Format("{0}Length: {1}, Width: {2}, Area: {3}",
                                  baseValue,  
                                  this.Length,
                                  this.Width,
                                  this.Area);
        }
    }
}