namespace DbContext
{
    using System;
    using System.Linq;

    using NorthWind;

    public class Program
    {
        public static void Main(string[] args)
        {
            NorthwindEntities db = new NorthwindEntities();
            var customers = db.Customers.Select(c => c.Address);
            foreach (var customer in customers)
            {
                Console.WriteLine(customer);
            }
        }
    }
}
