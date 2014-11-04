using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SimpleChat
{
    public class ChatDbContext : DbContext
    {
        public ChatDbContext()
            : base("ChatDbEntities")
        {
        }

        public IDbSet<Message> Messages { get; set; }
    }
}