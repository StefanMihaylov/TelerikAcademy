using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChatChannel.Models
{
    public class Message
    {
        public int MessageId { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime PostDate { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }
    }
}