namespace Cosmetics.Products
{
    using System.Collections.Generic;

    using Cosmetics.Contracts;

    public class ShoppingCart : IShoppingCart
    {
        private ICollection<IProduct> products;

        public ShoppingCart()
        {
            this.products = new List<IProduct>();
        }

        public void AddProduct(IProduct product)
        {
            this.products.Add(product);
        }

        public void RemoveProduct(IProduct product)
        {
            this.products.Remove(product);
        }

        public bool ContainsProduct(IProduct product)
        {
            return this.products.Contains(product);
        }

        public decimal TotalPrice()
        {
            decimal totalPrice = 0;
            foreach (Product product in this.products)
            {
                if (product is IShampoo)
                {
                    IShampoo shampoo = product as IShampoo;
                    totalPrice += shampoo.Price * shampoo.Milliliters;
                }

                if (product is IToothpaste)
                {
                    IToothpaste toothpaste = product as IToothpaste;
                    totalPrice += toothpaste.Price;
                }
            }

            return totalPrice;
        }
    }
}
