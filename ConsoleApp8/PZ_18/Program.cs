namespace PZ_18
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Transport trans1 = new Transport("AA 777 ОА", "Иван Иванович Иванов", new TimeOnly(13, 00), new TimeOnly(14, 30), TypeOfTransport.Bus); //объект 1
            Transport trans2 = new Transport(); //объект 2
            Transport trans3 = new Transport("ББ 777 АО", new TimeOnly(14, 00), new TimeOnly(15, 30), TypeOfTransport.Trolleybus); //объект 3
            Transport trans4 = new Transport("ВВ 777 AA", "Иван Арсланбекович Арсланбеков", new TimeOnly(15, 00), new TimeOnly(16, 30), TypeOfTransport.Electrichka); //объект 4 
            Transport trans5 = new Transport("ГГ 777 ББ", "Рим Мантович Петров", new TimeOnly(16, 00), new TimeOnly(17, 30), TypeOfTransport.Electrichka); //объект 5
            Transport trans6 = new Transport("AБ 777 ОБ", "Роман Бадретдинов Бондарев", new TimeOnly(17, 00), new TimeOnly(18, 30), TypeOfTransport.Bus); //объект 6
            Transport trans7 = new Transport("AВ 777 AЦ", "Екатерина Башеровна Грек", new TimeOnly(18, 00), new TimeOnly(19, 30), TypeOfTransport.Trolleybus); //объект 7
            Transport trans8 = new Transport("AГ 777 AХ", "Алексей Апельсинович Петров", new TimeOnly(19, 00), new TimeOnly(20, 30), TypeOfTransport.Electrichka); //объект 8
            Transport trans9 = new Transport("AХ 777 AХ", "Анна Апельсиновна Иванова", new TimeOnly(20, 00), new TimeOnly(21, 30), TypeOfTransport.Bus); //объект 9 
            Transport trans10 = new Transport("AA 777 РA", "Валентин Башерович Башатов", new TimeOnly(21, 00), new TimeOnly(22, 30), TypeOfTransport.Trolleybus); //объект 10

            Console.WriteLine("");
            Console.WriteLine(trans3.ToString()); //вывод информации объекта 3
            Console.WriteLine("");
            Console.WriteLine($"Количество транспорта: {Transport.countOfTransport}"); //общее количество транспорта
            Console.WriteLine($"Транспорт {trans1.OnRace()}"); //проверка первого объекта на рейсе ли он

        }
    }
}

