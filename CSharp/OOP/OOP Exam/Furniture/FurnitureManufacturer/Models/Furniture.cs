
namespace FurnitureManufacturer.Models
{
    using System;
    using FurnitureManufacturer.Interfaces;
    using FurnitureManufacturer.Engine.Factories;

    public abstract class Furniture : IFurniture
    {
        private const string InvalidMaterialName = "Invalid material name: {0}";
        private const string InvalidnumberParameter = "{0} must bi bigger than zero.";

        private string model;
        private string material;
        private decimal price;
        private decimal height;

        public Furniture(string model, string material, decimal price, decimal height)
        {
            this.Model = model;
            this.Material = material;
            this.Price = price;
            this.Height = height;
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(value, "Model cannot be null or empty string.");
                }

                if (value.Length < 4)
                {
                    throw new ArgumentException("Model name cannot be shorter than three leters.");
                }

                this.model = value;
            }
        }

        public string Material
        {
            get
            {
                return this.material;
            }
            private set
            {
                if (value != MaterialType.Leather.ToString() &&
                    value != MaterialType.Plastic.ToString() &&
                    value != MaterialType.Wooden.ToString())
                {
                    throw new ArgumentException(String.Format(InvalidMaterialName, value));
                }

                this.material = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value <= 0)
                {
                    this.LessOrEqualToZeroException(this.Price.GetType().Name);
                }

                this.price = value;
            }
        }

        public decimal Height
        {
            get
            {
                return this.height;
            }
            protected set
            {
                if (value <= 0)
                {
                    this.LessOrEqualToZeroException(this.Height.GetType().Name);
                }

                this.height = value;
            }
        }

        public override string ToString()
        {

            return String.Format("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}, ",
                                 this.GetType().Name,
                                 this.Model,
                                 this.Material,
                                 this.Price,
                                 this.Height);
        }

        protected void LessOrEqualToZeroException(string propertyName)
        {
            throw new ArgumentException(string.Format(InvalidnumberParameter, propertyName));
        }
    }
}