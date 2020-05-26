using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuventusWiki
{
    class WikiContext: DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Player> Players { get; set; }
        public WikiContext() : base("MyConnection")
        {
        }
    }
}
