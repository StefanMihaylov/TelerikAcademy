namespace CloneDB
{
    using System;
    using System.Data.Entity.Infrastructure;

    using Northwind.Model;
    using System.Data.SqlClient;

    public class Program
    {
        // Create a database called NorthwindTwin with the same structure as Northwind using the features from DbContext. Find the API for schema generation in MSDN or in Google.

        public static void Main()
        {
            // MAGIC !!!!!! DO NOT TOUCH !!!!!! :)

            Console.WriteLine("\t Procedure started");

            IObjectContextAdapter db = new NorthwindEntities();
            string generatedScript = db.ObjectContext.CreateDatabaseScript();
            string createNorthwindCloneDB = "USE master; " +
                                "CREATE DATABASE NorthwindTwin; " +
                                "SELECT name, size, size*1.0/128 AS [Size in MBs] " +
                                "FROM sys.master_files " +
                                "WHERE name = N'NorthwindTwin'; ";

            SqlConnection dbCon = new SqlConnection("Server=.; " +
                                                    "Database = master; Integrated Security=true");
            dbCon.Open();
            using (dbCon)
            {
                SqlCommand createCloneDB = new SqlCommand(createNorthwindCloneDB, dbCon);
                createCloneDB.ExecuteNonQuery();

                SqlCommand changeDataB = new SqlCommand("USE NorthwindTwin; ", dbCon);
                changeDataB.ExecuteNonQuery();

                SqlCommand cloneDB = new SqlCommand(generatedScript, dbCon);
                cloneDB.ExecuteNonQuery();
            }

            Console.WriteLine("\t Database NorthwindTwin created");
        }
    }
}
