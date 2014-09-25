namespace FindProduct
{
    using System;
    using System.Data.SqlClient;

    public class FindProduct
    {
        // Write a program that reads a string from the console and finds all products that contain this string. Ensure you handle correctly characters like ', %, ", \ and _.

        public static void Main()
        {
            // change the server property if needed
            SqlConnection dbConnection = new SqlConnection("Server = localhost; Database = Northwind; Integrated Security = true");

            Console.Write("Search for product: ");
            string pattern = Console.ReadLine();

            pattern = pattern.Replace("'", "[']");
            pattern = pattern.Replace("%", "[%]");
            pattern = pattern.Replace("\"", "[\"]");
            pattern = pattern.Replace("\\", "[\\]");
            pattern = pattern.Replace("_", "[_]");

            dbConnection.Open();
            using (dbConnection)
            {
                SqlCommand sqlCommand = new SqlCommand("SELECT ProductName FROM Products WHERE ProductName Like @searchString", dbConnection);

                sqlCommand.Parameters.AddWithValue("@searchString", "%" + pattern + "%");

                SqlDataReader reader = sqlCommand.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        string name = (string)reader["ProductName"];
                        Console.WriteLine("{0}", name);
                    }
                }
            }
        }
    }
}
