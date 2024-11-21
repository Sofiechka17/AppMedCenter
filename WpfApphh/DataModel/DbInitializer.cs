using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApphh.DataModel.WpfApphh.DataModel;

namespace WpfApphh.DataModel
{
    public static class DbInitializer
    {
        public static void Initialize(YourDbContext context)
        {
            context.Database.EnsureDeleted();  
            context.Database.EnsureCreated();  

            
            if (!context.TeachersCourses.Any())
            {
                var teachersCourses = new TeachersCourse[]
                {
                    new TeachersCourse { Course = "Мед помощь"},
                    new TeachersCourse { Course = "Психология общения"},
                    new TeachersCourse { Course = "Сестринская помощь"},
                };

                foreach (var teachersCourse in teachersCourses)
                {
                    context.TeachersCourses.Add(teachersCourse);
                }

                var teachers = new Teacher[]
                {
                    new Teacher  { FullName = "Петров Петр Петрович", Seniority = 10, PhoneNumber = "1234567890" },
                    new Teacher  { FullName = "Иванов Иван Петрович", Seniority = 5, PhoneNumber = "89122361739" },
                    new Teacher  { FullName = "Сидорова Анна Ивановна", Seniority = 3, PhoneNumber = "8900980987896" },
                };

                foreach (var t in teachers)
                {
                    context.Teachers.Add(t);
                }
                context.SaveChanges();  
            }
        }
    }
}
