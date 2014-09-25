namespace SQLiteBooks
{
    using System;
    using System.Data.SQLite;

    public class SQLiteBooks
    {
        public static void Main()
        {
            string connectionStr = @"Data Source = ..\\..\\Library.db; Version = 3;";

            AddBook(connectionStr, "Programing =++ Algorithms", "P.Nakov", new DateTime(2000, 02, 29), "123467");
            AddBook(connectionStr, "The Lord of the Ring", "J. R. R. Tolkien", new DateTime(1954, 07, 29), "23456523");
            AddBook(connectionStr, "The Hobbit", "J. R. R. Tolkien", new DateTime(1937, 09, 21), "5850132652");

            Console.WriteLine("\n Three books added");
            ListAll(connectionStr);


            FindTitle(connectionStr, "The Hobbit");
        }

        private static void ListAll(string connectionStr)
        {
            SQLiteConnection connection = new SQLiteConnection(connectionStr);

            connection.Open();
            using (connection)
            {
                SQLiteCommand command = new SQLiteCommand("select * from books", connection);
                SQLiteDataReader reader = command.ExecuteReader();

                Console.WriteLine("\n All books:");
                while (reader.Read())
                {
                    string title = (string)reader["title"];
                    string author = (string)reader["author"];
                    DateTime publishDate = (DateTime)reader["publishDate"];
                    string isbn = (string)reader["ISBN"];

                    Console.WriteLine("{0} - {1} - {2} - {3}", title, author, publishDate.ToShortDateString(), isbn);
                }
            }
        }

        private static void AddBook(string connectionStr, string title, string author, DateTime publishDate, string isbn)
        {
            SQLiteConnection connection = new SQLiteConnection(connectionStr);

            connection.Open();
            using (connection)
            {
                SQLiteCommand command = new SQLiteCommand(
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
            SQLiteConnection connection = new SQLiteConnection(connectionStr);

            connection.Open();
            using (connection)
            {
                SQLiteCommand command = new SQLiteCommand("select * from books where title = @title", connection);
                command.Parameters.AddWithValue("@title", searchedTitle);

                SQLiteDataReader reader = command.ExecuteReader();

                Console.WriteLine("\n Search Results for book with title \"{0}\"", searchedTitle);
                while (reader.Read())
                {
                    string title = (string)reader["title"];
                    string author = (string)reader["author"];
                    DateTime publishDate = (DateTime)reader["publishDate"];
                    string isbn = (string)reader["ISBN"];

                    Console.WriteLine("{0} - {1} - {2} - {3}", title, author, publishDate.ToShortDateString(), isbn);
                }
            }
        }
    }
}
