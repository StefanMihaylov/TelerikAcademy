using System;
using System.Data.SqlClient;

public class GetCategoriesCount
{
    /* Write a program that retrieves from the Northwind sample database in MS SQL Server the number of  rows in the Categories table. */

    public static void Main()
    {
        // change the server property if needed
        SqlConnection dbCon = new SqlConnection("Server = localhost; Database = Northwind; Integrated Security = true");

        dbCon.Open();
        using (dbCon)
        {
            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Categories", dbCon);
            int categoriesCount = (int)command.ExecuteScalar();
            Console.WriteLine("Categories count: {0} ", categoriesCount);
        }
    }
}

