using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace JPEGCounterWithDb
{
    public class UserDbContext : DbContext
    {
        public UserDbContext()
            : base("UsersCountEntities")
        {
        }

        public IDbSet<UserCounter> Counter { get; set; }
    }
}