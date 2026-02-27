using Seleznev2702Test;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seleznev2502
{
    internal class Context : DbContext
    {
        public Context()
            : base("conn")
        {
            Database.CreateIfNotExists();
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Position> Positions { get; set; }
    }
}
