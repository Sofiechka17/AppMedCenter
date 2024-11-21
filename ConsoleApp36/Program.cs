using System.ComponentModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleApp36
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.Write("Введите цвет: ");
            //string Usercolor = Console.ReadLine();
            //string red = "красный";
            //string yellow = "желтый";
            //string green = "зеленый";

            //if (Usercolor == red)
            //{
            //    Console.WriteLine("Стоп");
            //}
            //else
            //{
            //    if (Usercolor == green)
            //    {
            //        Console.WriteLine("Поехали");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Приготовились");
            //    }
            //}

            //Console.Write("Введите сумму счета: ");
            //string invoiceAmount = Console.ReadLine(); //сумма счета
            //int convertUserMessage = int.Parse(invoiceAmount);
            //int tip = 500; //чаевые

            //if (convertUserMessage >= tip)
            ////{
            ////    Console.WriteLine("Рекомендуем оставить чаевые");
            ////}
            ////else
            ////{
            ////    Console.WriteLine("Чаевые не требуются");
            ////}

            ////Write a program that prints all even numbers from 1 to 100.

            //int startNumber = 1; 
            //int endNumber = 100;

            //for(int number = startNumber; number <= endNumber; number++)
            //{
            //    if(number % 2 == 0)
            //    {
            //        Console.WriteLine(number);
            //    }
            //}

            ////Create a program that accepts a string and reverses it. For example, "hello" becomes "olleh".

            //Console.WriteLine("Введите слово: ");
            //string word = Console.ReadLine();



            //            Вы работаете над клиентом для облачного хранилища данных,
            //            и вам нужно симулировать процесс загрузки файлов. При этом вы хотите показать пользователю прогресс загрузки в процентах.

            //Задание:

            //            Используя цикл for, симулируйте процесс загрузки, выводя на экран сообщение вида "Загрузка: X%", где X — процент загрузки от 0 до 100.

            //int startProcent = 0;
            // int endProcent = 100;

            // for(int procent = startProcent; procent <= endProcent; procent++)
            // {
            //     Console.WriteLine($"Загрузка: {procent}%");
            // }

            //Write a program that simulates rolling a dice until a 
            //    6 is rolled.The program should print the result of each roll and count how many rolls it took to get a 6.

            int cubeValue = -1;
            int minCubeValue = 1;
            int neededCubeValue = 6;
            int rollCount = 0;
               
            while(cubeValue != neededCubeValue)
            {
                Random random = new Random();
                cubeValue = random.Next(minCubeValue,neededCubeValue + 1);
                Console.WriteLine(cubeValue);
                rollCount++;
               
            }
            Console.WriteLine(rollCount);
        }
    }
}
