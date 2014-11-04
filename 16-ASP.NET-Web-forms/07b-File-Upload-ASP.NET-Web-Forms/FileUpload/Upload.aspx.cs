namespace FileUpload
{
    using FileUpload.Model;
    using Ionic.Zip;
    using System;
    using System.IO;
    using System.Text;
    using System.Web;

    public partial class Upload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Expires = -1;
            try
            {
                var db = new FileDbContext();
                var zipContent = new StringBuilder();

                HttpPostedFile file = Request.Files["uploaded"];
                var zipFile = ZipFile.Read(file.InputStream);
                foreach (var zipEntry in zipFile.Entries)
                {
                    var memoryStream = new MemoryStream();
                    zipEntry.Extract(memoryStream);

                    memoryStream.Position = 0;
                    zipContent.Clear();
                    var reader = new StreamReader(memoryStream);
                    zipContent.AppendLine(reader.ReadToEnd());

                    db.Files.Add(new Model.File()
                    {
                        FileName = zipEntry.FileName,
                        Content = zipContent.ToString()
                    });
                }

                db.SaveChanges();


                Response.ContentType = "application/json";
                Response.Write("{}");
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }
    }
}