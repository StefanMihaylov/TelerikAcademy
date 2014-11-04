namespace FileUpload
{
    using FileUpload.Model;
    using System;
    using System.Text;

    public partial class Home : System.Web.UI.Page
    {
        protected string FileOutput { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            var db = new FileDbContext();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<ol>");
            foreach (var item in db.Files)
            {
                sb.AppendLine("<li>");
                sb.AppendFormat("<strong>{0}:</strong> {1}", item.FileName, item.Content);
                sb.AppendLine("</li>");
            }
            sb.AppendLine("</ol>");

            this.FileOutput = sb.ToString();
        }
    }
}