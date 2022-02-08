using NorthWind;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalIncomeBySupplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string sql = "IF (OBJECT_ID('usp_TotalSalesBySupplierInPeriod') IS NOT NULL) " +
                         "BEGIN " +
                         "DROP PROCEDURE usp_TotalSalesBySupplierInPeriod " +
                         "END " +
                         //"GO " +
                         "CREATE procedure usp_TotalSalesBySupplierInPeriod " +
                         "@CompanyName nvarchar(40), @Beginning_Date DateTime, @Ending_Date DateTime AS " +
                         "SELECT s.CompanyName AS Supplier, SUM(od.Quantity*od.UnitPrice*od.Discount) AS [Total income] " +
                         "FROM Orders AS o " +
                         "JOIN [Order Details] AS od " +
                         "ON o.OrderID = od.OrderID " +
                         "JOIN Products AS p " +
                         "ON od.ProductID = p.ProductID " +
                         "JOIN Suppliers AS s " +
                         "ON p.SupplierID = s.SupplierID " +
                         "WHERE o.OrderDate BETWEEN @Beginning_Date AND @Ending_Date AND s.CompanyName = @CompanyName " +
                         "GROUP BY s.CompanyName ";// + 
                         //"GO";

            SqlConnection dbCon = new SqlConnection("Server=.; Database=Northwind; Integrated Security=true");
            dbCon.Open();
            using(dbCon)
            {
                SqlCommand command = new SqlCommand();
                command.Connection = dbCon;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = sql;
                command.ExecuteNonQuery();
            }
        }
    }
}
