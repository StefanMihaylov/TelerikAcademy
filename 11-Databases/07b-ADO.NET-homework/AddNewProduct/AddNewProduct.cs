namespace AddNewProduct
{
    using System;
    using System.Data.SqlClient;
    using System.Configuration;

    public class AddNewProduct
    {
        /* Write a method that adds a new product in the products table in the Northwind database. Use a parameterized SQL command */

        public static void Main()
        {
            // see app.config if change of ConnectionString is needed
            ConnectionStringSettings dBConnectionString = ConfigurationManager.ConnectionStrings["SQLDB"];

            // SqlConnection dbConnection = new SqlConnection(Settings.Default.DBConnectionString); // this row or the next one;
            SqlConnection dbConnection = new SqlConnection(dBConnectionString.ConnectionString);

            dbConnection.Open();
            using (dbConnection)
            {
                int newProductId = InsertProduct(dbConnection, "Djibrova Shliokavica", null, 
                    1, "2 l bottles", 15.00m, 100, 0, 0, false);
                Console.WriteLine("New product inserted. ProductID = {0}", newProductId);
            }
        }

        private static int InsertProduct(SqlConnection dbCon, 
            string name, int? supplierID, int? categoryID, string quantityPerUnit,
            decimal? unitPrice, short? unitsInStock, short? unitsOnOrder, short? reorderLevel, bool discontinued)
        {
            SqlCommand insertProductCommand = new SqlCommand(
                @"INSERT INTO Products(ProductName, SupplierID, CategoryID, QuantityPerUnit, 
                                        UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued) " +
                "VALUES (@name, @supplierID, @categoryID, @quantityPerUnit, @unitPrice, @unitsInStock, @unitsOnOrder, @reorderLevel, @discontinued)", dbCon);

            insertProductCommand.Parameters.AddWithValue("@name", name);

            SqlParameter sqlParameterSupplierID = new SqlParameter("@supplierID", supplierID);
            if (supplierID == null)
            {
                sqlParameterSupplierID.Value = DBNull.Value;
            }
            insertProductCommand.Parameters.Add(sqlParameterSupplierID);

            SqlParameter sqlParameterCategoryID = new SqlParameter("@categoryID", categoryID);
            if (categoryID == null)
            {
                sqlParameterCategoryID.Value = DBNull.Value;
            }
            insertProductCommand.Parameters.Add(sqlParameterCategoryID);

            SqlParameter sqlParameterQuantityPerUnit = new SqlParameter("@quantityPerUnit", quantityPerUnit);
            if (quantityPerUnit == null)
            {
                sqlParameterQuantityPerUnit.Value = DBNull.Value;
            }
            insertProductCommand.Parameters.Add(sqlParameterQuantityPerUnit);

            SqlParameter sqlParameterUnitPrice = new SqlParameter("@unitPrice", unitPrice);
            if (unitPrice == null)
            {
                sqlParameterUnitPrice.Value = DBNull.Value;
            }
            insertProductCommand.Parameters.Add(sqlParameterUnitPrice);

            SqlParameter sqlParameterUnitsInStock = new SqlParameter("@unitsInStock", unitsInStock);
            if (unitsInStock == null)
            {
                sqlParameterUnitsInStock.Value = DBNull.Value;
            }
            insertProductCommand.Parameters.Add(sqlParameterUnitsInStock);

            SqlParameter sqlParameterUnitsOnOrder = new SqlParameter("@unitsOnOrder", unitsOnOrder);
            if (unitsOnOrder == null)
            {
                sqlParameterUnitsOnOrder.Value = DBNull.Value;
            }
            insertProductCommand.Parameters.Add(sqlParameterUnitsOnOrder);

            SqlParameter sqlParameterReorderLevel = new SqlParameter("@reorderLevel", reorderLevel);
            if (reorderLevel == null)
            {
                sqlParameterReorderLevel.Value = DBNull.Value;
            }
            insertProductCommand.Parameters.Add(sqlParameterReorderLevel);

            insertProductCommand.Parameters.AddWithValue("@discontinued", discontinued);

            insertProductCommand.ExecuteNonQuery();

            SqlCommand cmdSelectIdentity = new SqlCommand("SELECT @@Identity", dbCon);
            int insertedRecordId = (int)(decimal)cmdSelectIdentity.ExecuteScalar();
            return insertedRecordId;
        }
    }
}
