using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace AptekaApp
{
    internal class ApplicationContext : DbContext
    {
       public DbSet<User> Users { get; set; }
        public ApplicationContext() : base("DefaultConnection") { }
    }
    
}
