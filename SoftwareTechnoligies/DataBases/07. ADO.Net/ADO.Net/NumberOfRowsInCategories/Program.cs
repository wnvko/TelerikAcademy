﻿using System;
using System.Data.SqlClient;

namespace NumberOfRowsInCategories
{
    class Program
    {
        static void Main()
        {
            SqlConnection dbCon = new SqlConnection("Server=.; Database=Northwind; Integrated Security=true");
            dbCon.Open();
            using (dbCon)
            {
                SqlCommand cmdSelectCount = new SqlCommand("SELECT COUNT(*) FROM Categories", dbCon);
                int categoriesRowsCount = (int)cmdSelectCount.ExecuteScalar();
                Console.WriteLine("Number of rows in Categories table is {0}", categoriesRowsCount);
            }
        }
    }
}
