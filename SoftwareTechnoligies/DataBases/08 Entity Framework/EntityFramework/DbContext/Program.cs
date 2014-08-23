using System;
using System.Linq;
using NorthWind;

namespace DbContext
{
    class Program
    {
        static void Main(string[] args)
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
