using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WpfApp6.DataModel
{
    public class TeacherDbContext : DbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("Data Source=Teacher.db");
        //}

        public TeacherDbContext()
            : base("name=TeacherDbContext")
        {
        }

        public DbSet<Teacher> Teachers { get; set; }
    }
}
