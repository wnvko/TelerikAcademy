namespace CategoriesAndProducts
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter product to search for:");
            string lookup = Console.ReadLine();

            lookup.Replace("'", "''");

            SqlConnection dbCon = new SqlConnection("Server=.; Database=Northwind; Integrated Security=true");

            dbCon.Open();
            using (dbCon)
            {
                SqlCommand cmdCategoriesAndProducts = new SqlCommand(
                                    string.Format(
                                            "SELECT p.ProductName " +
                                            "FROM Products AS p " +
                                            "WHERE p.ProductName LIKE '{0}'",
                                            lookup),
                                    dbCon);

                SqlDataReader reader = cmdCategoriesAndProducts.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        string product = (string)reader["ProductName"];
                        Console.WriteLine(product);
                    }
                }
            }
        }
    }
}