using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp5.Data
{
    public class CourseDbContext : DbContext
    {
        public CourseDbContext(DbContextOptions<CourseDbContext> options) : base(options)
        {
            Database.EnsureCreated(); // создает бд при ее отсутствии
        }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().HasData(GetCourses()); // Инициализация данных курсов
            base.OnModelCreating(modelBuilder);
        }

        private Course[] GetCourses()
        {
            return new Course[]
            {
            new Course {Id=1, Name="Современные методы лечения заболеваний сердечно-сосудистой системы", Description="Обзор современных подходов к диагностике и лечению сердечно-сосудистых заболеваний", HourCount=350, Cost=17500},
            new Course {Id=2, Name="Инновационные методы в физиотерапии", Description="Изучение новых технологий и методов физиотерапии", HourCount=200, Cost=10000},
            new Course {Id=3, Name="Психосоматика в медицине", Description="Исследование взаимосвязи между психологическими и соматическими расстройствами", HourCount=150, Cost=7000}
            };
        }
    }
}
