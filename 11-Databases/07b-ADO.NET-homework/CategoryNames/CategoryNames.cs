namespace CategoryNames
{
    using System;
    using System.Data.SqlClient;

    public class CategoryNames
    {
        /* Write a program that retrieves the name and description of all categories in the Northwind DB. */

        public static void Main()
        {
            // change the server property if needed
            SqlConnection dbConnection = new SqlConnection("Server = localhost; Database = Northwind; Integrated Security = true");

            dbConnection.Open();
            using (dbConnection)
            {
                SqlCommand sqlCommand = new SqlCommand("SELECT CategoryName, Description FROM Categories", dbConnection);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        string name = (string)reader["CategoryName"];
                        string description = (string)reader["Description"];
                        Console.WriteLine("{0} : {1}", name, description);
                    }
                }
            }
        }
    }
}
