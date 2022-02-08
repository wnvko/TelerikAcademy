using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CategoriesAndProducts
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection dbCon = new SqlConnection("Server=.; Database=Northwind; Integrated Security=true");
            Dictionary<string, List<string>> productsInGroups = new Dictionary<string, List<string>>();
                
            dbCon.Open();
            using (dbCon)
            {
                SqlCommand cmdCategoriesAndProducts = new SqlCommand("SELECT c.CategoryName, p.ProductName FROM Categories AS c JOIN Products AS p ON c.CategoryID = p.CategoryID", dbCon);
                SqlDataReader reader = cmdCategoriesAndProducts.ExecuteReader();
                
                using (reader)
                {
                    while (reader.Read())
                    {
                        string category = (string)reader["CategoryName"];
                        string product = (string)reader["ProductName"];
                        if (!productsInGroups.ContainsKey(category))
                        {
                            productsInGroups[category] = new List<string>();
                        }

                        productsInGroups[category].Add(product);
                    }
                }
            }

            foreach (var category in productsInGroups)
            {
                Console.WriteLine("Products in {0} category:", category.Key);
                foreach (var product in category.Value)
                {
                    Console.WriteLine("\t{0}",product);
                }
            }
        }
    }
}
