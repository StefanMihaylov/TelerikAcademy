using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsSystem.Models
{
    public class Like
    {
        public int LikeId { get; set; }

        public int Value { get; set; }

        public int ArticleId { get; set; }

        public Article Article { get; set; }

        public string UserId { get; set; }

        public virtual AppUser User { get; set; }
    }
}