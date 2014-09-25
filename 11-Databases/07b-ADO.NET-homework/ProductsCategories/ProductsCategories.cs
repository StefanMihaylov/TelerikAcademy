namespace ProductsCategories
{
    using System;
    using System.Data.SqlClient;

    public class ProductsCategories
    {
        public static void Main()
        {
            SqlConnection dbConnection = new SqlConnection("Server = localhost; Database = Northwind; Integrated Security = true");

            dbConnection.Open();
            using (dbConnection)
            {
                SqlCommand sqlCommand = new SqlCommand(
                      @"SELECT p.ProductName, c.CategoryName
                        FROM Products p
                            JOIN Categories c
                            ON p.CategoryID = c.CategoryID
                        ORDER BY c.CategoryName"
                      , dbConnection);

                SqlDataReader reader = sqlCommand.ExecuteReader();
                using (reader)
                {
                    Console.WriteLine("{0,20} | {1}", "Category", "Product");
                    Console.WriteLine(new string('-',60));

                    while (reader.Read())
                    {
                        string product = (string)reader["ProductName"];
                        string category = (string)reader["CategoryName"];
                        Console.WriteLine("{0,20} | {1}", category, product );
                    }
                }
            }
        }
    }
}
