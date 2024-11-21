using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp5.Data
{
    public class TeacherDbContext : DbContext
    {
        public TeacherDbContext(DbContextOptions<TeacherDbContext> options) : base(options)
        {
            Database.EnsureCreated(); // создает бд при ее отсутствии
        }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>().HasData(GetTeachers()); //для инициализации бд при конфигурации определенной модели вызывается метод HasData()
            base.OnModelCreating(modelBuilder);
        }

        private Teacher[] GetTeachers()
        {
            return new Teacher[]
            {
                new Teacher {Id=1, FullName="Сидорова Светлана Викторовна", Seniority=10, Number="89876099909"},
                new Teacher {Id=2, FullName="Кузнецов Алексей Сергеевич", Seniority=10, Number="89999999999"},
                new Teacher {Id=3, FullName="Александров Сергей Сергеевич", Seniority=10, Number="80879797905"},
            };
        }
    }
}
