using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleChat
{
    public class Message
    {
        public int MessageId { get; set; }

        public String Username { get; set; }

        public String Content { get; set; }

        public DateTime PostDate { get; set; }
    }
}