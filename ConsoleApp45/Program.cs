namespace ConsoleApp45
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] guests = new string[5];


            for (int guestIndex = 0; guestIndex < guests.Length; guestIndex++)
            {
                guests[guestIndex] = Console.ReadLine();
            }
        }
    }
}

//1.Организатор мероприятий: Создайте программу для управления списком гостей на мероприятии. Пользователи могут добавлять, удалять гостей и проверять, присутствует ли определенный гость в списке.
