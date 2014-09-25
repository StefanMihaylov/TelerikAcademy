namespace ReadExcelFile
{
    using System;
    using System.Data.OleDb;
    using System.Threading;

    public class ReadWriteExcelFile
    {
        /* 06. Create an Excel file with 2 columns: name and score. Write a program that reads your MS Excel file through the OLE DB data provider and displays the name and score row by row */

        /* 07. Implement appending new rows to the Excel file */


        // http://aspsnippets.com/Articles/Read-and-Import-Excel-Sheet-using-ADO.Net-and-C.aspx

        // Connection String for Excel 97-2003 Format (.XLS)
        public const string ConnectionString = @" Provider = Microsoft.Jet.OLEDB.4.0; Data Source= ..\..\Data.xls;  Extended Properties = 'Excel 8.0; HDR=Yes' ";    

        public static void Main()
        {
            Console.WriteLine("\tOriginal data");
            Console.WriteLine(new string('-', 30));
            ReadDataFromExcel();
            Console.WriteLine(new string('-', 30));

            WriteDataFromExcel("Peter Petrov", 12);
            WriteDataFromExcel("Ivan Ivanov", 18);

            Console.WriteLine("\n\tTwo new records inserted\n");

            Console.WriteLine("\tData after insertion");
            Console.WriteLine(new string('-', 30));
            ReadDataFromExcel();
        }

        private static void ReadDataFromExcel()
        {
            OleDbConnection dbConnection = new OleDbConnection(ConnectionString);
            dbConnection.Open();
            using (dbConnection)
            {
                OleDbCommand command = new OleDbCommand("SELECT * FROM [Scores$]", dbConnection);
                OleDbDataReader reader = command.ExecuteReader();

                using (reader)
                {
                    Console.WriteLine("{0, 20} | {1}", "Name", "Score");
                    Console.WriteLine(new string('-', 30));
                    while (reader.Read())
                    {
                        string name = (string)reader["Name"];
                        double score = (double)reader["Score"];
                        Console.WriteLine("{0, 20} | {1}", name, score);
                    }
                }
            }
        }

        private static void WriteDataFromExcel(string name, double score)
        {
            OleDbConnection dbConnection = new OleDbConnection(ConnectionString);
            dbConnection.Open();
            using (dbConnection)
            {
                OleDbCommand command = new OleDbCommand("INSERT INTO [Scores$] (Name, Score) VALUES (@name, @score)", dbConnection);

                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@score", score);

                command.ExecuteNonQuery();
            }            
        }
    }
}
