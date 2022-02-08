using System;
using NorthWind;

namespace NewOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            NorthwindEntities db = new NorthwindEntities();
            Order myOrder = new Order();
            myOrder.CustomerID = "WELLI";
            myOrder.EmployeeID = 3;
            myOrder.OrderDate = DateTime.Today.AddMonths(2);
            myOrder.ShipVia = 1;
            myOrder.ShipCity = "London";
            db.Orders.Add(myOrder);
            db.SaveChanges();
        }
    }
}
