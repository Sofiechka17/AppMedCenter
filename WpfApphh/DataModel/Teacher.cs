using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WpfApphh.DataModel
{
    namespace WpfApphh.DataModel
    {

        public class TeachersCourse
        {
            public int TeachersCourseId { get; set; }
            public string Course { get; set; }

            public ICollection<Teacher> Teachers { get; set; }
        }

        public class Teacher
        {
            public int TeacherId { get; set; }
            public string FullName { get; set; }
            public int Seniority { get; set; }
            public string PhoneNumber { get; set; }


            public int TeachersCourseId { get; set; }
            public TeachersCourse TeachersCourse { get; set; }
        }


        public class YourDbContext : DbContext
        {
            public DbSet<Teacher> Teachers { get; set; }
            public DbSet<TeachersCourse> TeachersCourses { get; set; }


            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlite("Data Source=teacherdb.db");
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {

                modelBuilder.Entity<Teacher>()
                    .HasOne(t => t.TeachersCourse)
                    .WithMany(tc => tc.Teachers)
                    .HasForeignKey(t => t.TeachersCourseId);
            }
        }
    }
}