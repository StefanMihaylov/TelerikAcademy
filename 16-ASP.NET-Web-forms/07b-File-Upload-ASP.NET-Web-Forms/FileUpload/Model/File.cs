using System.ComponentModel.DataAnnotations.Schema;
namespace FileUpload.Model
{
    public class File
    {
        public int FileId { get; set; }

        public string FileName { get; set; }

        public string Content { get; set; }
    }
}