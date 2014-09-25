namespace GetCategoryImages
{
    using System;
    using System.Configuration;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;

    public class GetCategoryImages
    {
        /* Write a program that retrieves the images for all categories in the Northwind database and stores them as JPG files in the file system */

        public static void Main()
        {
            // see app.config if change of ConnectionString is needed
            ConnectionStringSettings dBConnectionString = ConfigurationManager.ConnectionStrings["SQLDB"];
            SqlConnection dbConnection = new SqlConnection(dBConnectionString.ConnectionString);

            dbConnection.Open();
            using (dbConnection)
            {
                string forderName = "Pictures";
                string pathString = Path.Combine("..\\..\\", forderName);
                Directory.CreateDirectory(pathString);

                int imageCount = ListImageIdsFromDB(dbConnection, pathString, ".jpeg");
                Console.WriteLine("{0} images extracted from the DB. See the {1} folder in project directory", imageCount, forderName);
            }
        }

        private static int ListImageIdsFromDB(SqlConnection dbConnection, string path, string extention)
        {
            SqlCommand cmd = new SqlCommand("SELECT Picture, CategoryName FROM Categories", dbConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            int count = 0;

            using (reader)
            {
                while (reader.Read())
                {
                    byte[] imageBytes = (byte[])reader["Picture"];
                    string name = (string)reader["CategoryName"];

                    name = name.Replace("/", "-");
                    string pathString = Path.Combine(path, name + extention);

                    // WriteBinaryFile(pathString, imageBytes); // don't work

                    int len = imageBytes.Length;
                    int header = 78;
                    byte[] imgData = new byte[len - header];
                    Array.Copy(imageBytes, 78, imgData, 0, len - header);
                    
                    MemoryStream memoryStream = new MemoryStream(imgData);
                    Image image = System.Drawing.Image.FromStream(memoryStream);
                    image.Save(new FileStream(pathString, FileMode.Create), ImageFormat.Jpeg);

                    count++;
                }
            }

            return count;
        }

        private static void WriteBinaryFile(string fileName, byte[] fileContents)
        {
            FileStream stream = File.OpenWrite(fileName);
            using (stream)
            {
                stream.Write(fileContents, 0, fileContents.Length);
            }
        }
    }
}
