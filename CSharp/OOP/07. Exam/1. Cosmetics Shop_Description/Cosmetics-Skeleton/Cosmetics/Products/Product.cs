namespace Cosmetics.Products
{
    using System.Text;

    using Cosmetics.Common;
    using Cosmetics.Contracts;

    public abstract class Product : IProduct
    {
        private const int MinNameLenght = 3;
        private const int MaxNameLenght = 10;
        private const int MinBrandLenght = 2;
        private const int MaxBrandLenght = 10;
        private const string ProductNameString = "Product name";
        private const string ProductBrandString = "Product brand";
        private const string ProductBrandAndNameString = "- {0} - {1}:";
        private const string PriceString = "  * Price: {0:c}";
        private const string GenderString = "  * For gender: {0}";

        private string name;
        private string brand;
        private decimal price;
        private GenderType gender;

        public Product(string name, string brand, decimal price, GenderType gender)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.Gender = gender;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                string errorMessage = string.Format(GlobalErrorMessages.InvalidStringLength, ProductNameString, MinNameLenght, MaxNameLenght);
                Validator.CheckIfStringLengthIsValid(value, MaxNameLenght, MinNameLenght, errorMessage);
                this.name = value;
            }
        }

        public string Brand
        {
            get
            {
                return this.brand;
            }

            private set
            {
                string errorMessage = string.Format(GlobalErrorMessages.InvalidStringLength, ProductBrandString, MinBrandLenght, MaxBrandLenght);
                Validator.CheckIfStringLengthIsValid(value, MaxBrandLenght, MinBrandLenght, errorMessage);
                this.brand = value;
            }
        }

        public decimal Price
        {
            get { return this.price; }
            private set { this.price = value; }
        }

        public GenderType Gender
        {
            get { return this.gender; }
            private set { this.gender = value; }
        }

        public virtual string Print()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(string.Format(ProductBrandAndNameString, this.Brand, this.Name));
            decimal correctPrice = this.Price;
            if (this is IShampoo)
            {
                IShampoo shampoo = this as IShampoo;
                correctPrice = shampoo.Price * shampoo.Milliliters;
            }

            result.AppendLine(string.Format(PriceString, correctPrice));
            result.AppendLine(string.Format(GenderString, this.Gender.ToString()));

            return result.ToString().Trim();
        }
    }
}
