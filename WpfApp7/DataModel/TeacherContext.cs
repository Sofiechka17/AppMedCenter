using System;
using System.Data.Entity;
using System.Linq;

namespace WpfApp7.DataModel
{
    public class TeacherContext : DbContext
    {
        // Контекст настроен для использования строки подключения "TeacherContext" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "WpfApp7.DataModel.TeacherContext" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "TeacherContext" 
        // в файле конфигурации приложения.
        public TeacherContext()
            : base("name=TeacherContext")
        {
        }

        // Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
        // о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.

     public DbSet<Teacher> Teachers {  get; set; }   // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    
    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}