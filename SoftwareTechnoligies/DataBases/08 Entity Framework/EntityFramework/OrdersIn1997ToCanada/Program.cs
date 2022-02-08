using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthWind;

namespace OrdersIn1997ToCanada
{
    class Program
    {
        static void Main(string[] args)
        {
            NorthwindEntities db = new NorthwindEntities();
            var customerFromCanada = from c in db.Customers
                                     join o in db.Orders
                                     on c.CustomerID equals o.CustomerID
                                     where c.Country == "Canada"
                                     where o.OrderDate.Value.Year == 1997
                                     orderby o.OrderDate
                                     select new
                                     {
                                         Name = c.ContactName,
                                         Country = c.Country,
                                         OrderDate = o.OrderDate
                                     };

            foreach (var customer in customerFromCanada)
            {
                Console.WriteLine("{0} from {1} has order on {2:dddd d.MMMM.yyyy}", customer.Name, customer.Country, customer.OrderDate);
            }

            var customerFromCanadaNativeSQL = db.Database.SqlQuery<string>("SELECT c.ContactName + ' ' + c.Country FROM dbo.Customers AS C JOIN dbo.Orders AS o ON c.CustomerID = o.CustomerID WHERE c.Country = 'canada' AND o.OrderDate BETWEEN '1997-01-01' AND '1997-12-31' ORDER BY o.OrderDate");
            foreach (var customer in customerFromCanadaNativeSQL)
            {
                Console.WriteLine(customer);
            }
        }
    }
}