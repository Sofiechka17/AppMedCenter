using System;
using System.IO;
namespace PZ_14
{
    class Program
    {
        static void Main()
        {
            //Получаем путь к файлу
            string path = @"C:TextFile1.txt";

            //Проверяем существует ли файл
            if (File.Exists(path))
            {
                //Создаем список продуктов
                string[] products = File.ReadAllLines(path);

                //Выводим информацию пользователю
                Console.WriteLine("Список продуктов:");

                //Перебираем все продукты
                foreach (string product in products)

                    //Выводим на экран название продукта и его цену
                    Console.WriteLine(product);


                //Получаем сумму чека
                int sum = products.Sum(product => int.Parse(product.Split(' ')[1]));

                //Выводим сумму на экран
                Console.WriteLine("Сумма чека: " + sum + " р.");

                try
                {
                    //Открываем файл для записи в конец
                    using (StreamWriter sw = File.AppendText(path))

                        //Записываем сумму чека и пояснение в файл
                        sw.WriteLine("Сумма чека: " + sum + " р. - сумма всех покупок в магазине.");

                    //Выводим сообщение об успешной записи в файл
                    Console.WriteLine("Сумма чека успешно добавлена в файл.");

                }
                catch (Exception ex)
                {
                    //Выводим сообщение об ошибке при записи в файл
                    Console.WriteLine("Ошибка при записи в файл: " + ex.Message);
                }

            }
            else
            {
                //Выводим сообщение об ошибке, если файл не существует
                Console.WriteLine("Файл не найден!");
            }

            //Задерживаем консоль, чтобы она не закрылась сразу после выполнения программы
            Console.ReadKey();
        }
    }
}