namespace NewOrder
{
    using System;

    using NorthWind;

    public class Program
    {
        public static void Main(string[] args)
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
