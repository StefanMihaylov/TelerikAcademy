namespace MySQLBooks
{
    using System;
    using MySql.Data.MySqlClient;

    public class MySqlBooks
    {
        /*  Download and install MySQL database, MySQL Connector/Net (.NET Data Provider for MySQL) + MySQL Workbench GUI administration tool. Create a MySQL database to store Books (title, author, publish date and ISBN). Write methods for listing all books, finding a book by name and adding a book */

        public static void Main()
        {
            Console.Write("Enter pass: ");
            string pass = Console.ReadLine();

            // change the server property if needed
            string connectionStr = "Server = localhost; Database = books_db; Uid=root; Pwd=" + pass + ";";

            ListAll(connectionStr);

            AddBook(connectionStr, "The Lord of the Ring", "J. R. R. Tolkien", new DateTime(1954, 07, 29), "23456523");
            AddBook(connectionStr, "The Hobbit", "J. R. R. Tolkien", new DateTime(1937, 09, 21), "5850132652");

            Console.WriteLine("Two books added");
            ListAll(connectionStr);


            FindTitle(connectionStr, "The Hobbit");
        }
 
        private static void ListAll(string connectionStr)
        {
            MySqlConnection connection = new MySqlConnection(connectionStr);

            connection.Open();
            using (connection)
            {
                MySqlCommand command = new MySqlCommand("select * from books", connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int bookId = (int)reader["bookid"];
                    string title = (string)reader["title"];
                    string author = (string)reader["author"];
                    DateTime publishDate = (DateTime)reader["publishDate"];
                    string isbn = (string)reader["ISBN"];

                    Console.WriteLine("{0,3} : {1} - {2} - {3} - {4}", bookId, title, author, publishDate.ToShortDateString(), isbn);
                }
            }
        }

        private static void AddBook(string connectionStr, string title, string author, DateTime publishDate, string isbn)
        {
            MySqlConnection connection = new MySqlConnection(connectionStr);

            connection.Open();
            using (connection)
            {
                MySqlCommand command = new MySqlCommand(
                    "insert into books(title, author, publishDate, ISBN) values(@title, @author, @publishDate, @ISBN)"
                    , connection);

                command.Parameters.AddWithValue("@title", title);
                command.Parameters.AddWithValue("@author", author);
                command.Parameters.AddWithValue("@publishDate", publishDate);
                command.Parameters.AddWithValue("@ISBN", isbn);
                command.ExecuteNonQuery();
            }
        }

        private static void FindTitle(string connectionStr, string searchedTitle)
        {
            MySqlConnection connection = new MySqlConnection(connectionStr);

            connection.Open();
            using (connection)
            {
                MySqlCommand command = new MySqlCommand("select * from books where title = @title", connection);
                command.Parameters.AddWithValue("@title", searchedTitle);

                MySqlDataReader reader = command.ExecuteReader();

                Console.WriteLine("Search Results for book with title \"{0}\"", searchedTitle);
                while (reader.Read())
                {
                    int bookId = (int)reader["bookid"];
                    string title = (string)reader["title"];
                    string author = (string)reader["author"];
                    DateTime publishDate = (DateTime)reader["publishDate"];
                    string isbn = (string)reader["ISBN"];

                    Console.WriteLine("{0,3} : {1} - {2} - {3} - {4}", bookId, title, author, publishDate.ToShortDateString(), isbn);
                }
            }
        }
    }
}
