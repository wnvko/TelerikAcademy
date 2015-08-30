namespace InsertNewProduct
{
    using System;
    using System.Data.SqlClient;

    public class Program
    {
        public static void Main()
        {
            string productName = "Vafla Mypa";
            int? supplierID = 10;
            int? categoryID = 3;
            string quantityPerUnit = "36 per box";
            decimal? unitPrice = 16.2m;
            int? unitsInStock = null;
            int? unitsOnOrder = 360;
            int? reorderLevel = 28;
            bool discontinued = false;

            SqlConnection dbCon = new SqlConnection("Server=.; Database=Northwind; Integrated Security=true");
            dbCon.Open();
            using (dbCon)
            {
                SqlCommand cmdInsertProduct = new SqlCommand(
                              @"INSERT INTO Products(ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued) " +
                               "VALUES(@ProductName, @SupplierID, @CategoryID, @QuantityPerUnit, @UnitPrice, @UnitsInStock, @UnitsOnOrder, @ReorderLevel, @Discontinued) ",
                               dbCon);

                cmdInsertProduct.Parameters.AddWithValue("@ProductName", productName);
                SqlParameter paramSupplierID = new SqlParameter("@SupplierID", supplierID);
                if (supplierID == null)
                {
                    paramSupplierID.Value = DBNull.Value;
                }

                cmdInsertProduct.Parameters.Add(paramSupplierID);

                SqlParameter paramCategoryID = new SqlParameter("@CategoryID", categoryID);
                if (categoryID == null)
                {
                    paramCategoryID.Value = DBNull.Value;
                }

                cmdInsertProduct.Parameters.Add(paramCategoryID);

                cmdInsertProduct.Parameters.AddWithValue("@QuantityPerUnit", quantityPerUnit);
                SqlParameter paramUnitPrice = new SqlParameter("@UnitPrice", unitPrice);
                if (unitPrice == null)
                {
                    paramUnitPrice.Value = DBNull.Value;
                }

                cmdInsertProduct.Parameters.Add(paramUnitPrice);

                SqlParameter paramUnitsInStock = new SqlParameter("@UnitsInStock", unitsInStock);
                if (unitsInStock == null)
                {
                    paramUnitsInStock.Value = DBNull.Value;
                }

                cmdInsertProduct.Parameters.Add(paramUnitsInStock);

                SqlParameter paramUnitsOnOrder = new SqlParameter("@UnitsOnOrder", unitsOnOrder);
                if (unitsOnOrder == null)
                {
                    paramUnitsOnOrder.Value = DBNull.Value;
                }

                cmdInsertProduct.Parameters.Add(paramUnitsOnOrder);

                SqlParameter paramReorderLevel = new SqlParameter("@ReorderLevel", reorderLevel);
                if (reorderLevel == null)
                {
                    paramReorderLevel.Value = DBNull.Value;
                }

                cmdInsertProduct.Parameters.Add(paramReorderLevel);

                SqlParameter paramDiscontinued = new SqlParameter("@Discontinued", discontinued);
                if (discontinued)
                {
                    paramDiscontinued.Value = 0;
                }
                else
                {
                    paramDiscontinued.Value = 1;
                }

                cmdInsertProduct.Parameters.Add(paramDiscontinued);

                cmdInsertProduct.ExecuteNonQuery();
            }
        }
    }
}
