namespace Cosmetics.Products
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Cosmetics.Common;
    using Cosmetics.Contracts;

    public class Category : ICategory
    {
        private const int MinNameLenght = 2;
        private const int MaxNameLenght = 15;
        private const string CategoryNameError = "Category name";
        private const string ProductNotExistInCategotyString = "Product {0} does not exist in category {1}!";
        private const string CategoryNameSingleString = "{0} category - {1} product in total";
        private const string CategoryNameManyString = "{0} category - {1} products in total";

        private string name;
        private ICollection<IProduct> products;

        public Category(string name)
        {
            this.Name = name;
            this.products = new List<IProduct>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                string errorMessage = string.Format(GlobalErrorMessages.InvalidStringLength, CategoryNameError, MinNameLenght, MaxNameLenght);
                Validator.CheckIfStringLengthIsValid(value, MaxNameLenght, MinNameLenght, errorMessage);
                this.name = value;
            }
        }

        public void AddCosmetics(IProduct cosmetics)
        {
            this.products.Add(cosmetics);
            this.products = this.products.OrderBy(p => p.Brand).ThenByDescending(p => p.Price).ToList();
        }

        public void RemoveCosmetics(IProduct cosmetics)
        {
            bool productFound = this.products.Contains(cosmetics);
            if (productFound)
            {
                this.products.Remove(cosmetics);
            }
            else
            {
                string errorMessage = string.Format(ProductNotExistInCategotyString, cosmetics.Name, this.Name);
                throw new ArgumentException(errorMessage);
            }
        }

        public string Print()
        {
            StringBuilder result = new StringBuilder();
            string categoryName = string.Empty;
            if (this.products.Count == 1)
            {
                categoryName = CategoryNameSingleString;
            }
            else
            {
                categoryName = CategoryNameManyString;
            }
            result.AppendLine(string.Format(categoryName, this.Name, this.products.Count));
            foreach (Product product in this.products)
            {
                result.AppendLine(product.Print());
            }

            return result.ToString().Trim();
        }
    }
}
