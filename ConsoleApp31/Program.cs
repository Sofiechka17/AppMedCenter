using System;

namespace ConsoleApp31
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Подсчёт книг
            int booksCount = 120;
            Console.WriteLine("Количество книг в библиотеке: " + booksCount);
            booksCount = 135;
            Console.WriteLine("Количество книг в библиотеке: " + booksCount);

            //Счётчик учеников
            int studentsInClass = 23;
            Console.WriteLine("Количество учеников: " + studentsInClass);
            studentsInClass = 25;
            Console.WriteLine("Количество учеников: " + studentsInClass);

            //Температура воздуха
            float airTemperature = 24.7f;
            Console.WriteLine("Температура воздуха в градусах Цельсия: " + airTemperature);
            airTemperature = 18.2f;
            Console.WriteLine("Температура воздуха в градусах Цельсия: " + airTemperature);

            //Оценка за тест
            float testScore = 4.5f;
            Console.WriteLine("Оценка за тест: " + testScore);
            testScore = 4.8f;
            Console.WriteLine("Оценка за тест: " + testScore);

            //Расстояние между городами
            double distanceBetweenCities = 123.456;
            Console.WriteLine("Расстояние между городами: " + distanceBetweenCities);
            distanceBetweenCities = 135.789;
            Console.WriteLine("Расстояние между городами: " + distanceBetweenCities);

            //Объём бутылки воды
            double bottleVolume = 1.5;
            Console.WriteLine("Объём бутылки воды: " + bottleVolume);
            bottleVolume = 2.0;
            Console.WriteLine("Объём бутылки воды: " + bottleVolume);

            //Первая буква имени
            char firstLetterOfName = 'S';
            Console.WriteLine("Первая буква моего имени: " + firstLetterOfName);
            firstLetterOfName = 'A';
            Console.WriteLine("Первая буква имени друга: " + firstLetterOfName);

            //Символ валюты
            Console.WriteLine("Символ валюты: ");
            char currencySymbol = '$';
            Console.WriteLine(currencySymbol);
            currencySymbol = 'P';
            Console.WriteLine(currencySymbol);

            //Логическое значение
            Console.WriteLine("Логическое значение: ");
            bool isRaining = true;
            Console.WriteLine(isRaining);
            isRaining = false;
            Console.WriteLine(isRaining);

            //Открыта ли дверь
            Console.WriteLine("Открыта ли дверь: ");
            bool isDoorOpen = false;
            Console.WriteLine(isDoorOpen);
            isDoorOpen = true;
            Console.WriteLine(isDoorOpen);

            //Банковский баланс
            Console.WriteLine("Банковский баланс: ");
            decimal bankBalance = 15000.75m;
            Console.WriteLine(bankBalance);
            bankBalance = 15800.30m; 
            Console.WriteLine(bankBalance);

            //Цена за единицу товара
            Console.WriteLine("Цена за единицу товара: ");
            decimal pricePerItem = 299.99m;
            Console.WriteLine(pricePerItem);
            pricePerItem = 349.99m; 
            Console.WriteLine(pricePerItem);

            //Уровень заряда батареи
            Console.WriteLine("Уровень заряда батареи: ");
            byte batteryLevel = 75;
            Console.WriteLine(batteryLevel);
            batteryLevel = 100;
            Console.WriteLine(batteryLevel);

            //Количество ошибок в программе
            Console.WriteLine("Количество ошибок в программе: ");
            byte errorCount = 0;
            Console.WriteLine(errorCount);
            errorCount = 5;
            Console.WriteLine(errorCount);

            //Количество шагов
            Console.WriteLine("Количество шагов: ");
            short stepsTaken = 3000;
            Console.WriteLine(stepsTaken);
            stepsTaken = 5000;
            Console.WriteLine(stepsTaken);

            //Очки игрока
            Console.WriteLine("Очки игрока: ");
            short playerScore = 1200;
            Console.WriteLine(playerScore);
            playerScore = 1500; 
            Console.WriteLine(playerScore);

            //Население города
            Console.WriteLine("Население города: ");
            long cityPopulation = 12345678;
            Console.WriteLine(cityPopulation);
            cityPopulation = 12348765;
            Console.WriteLine(cityPopulation);

            //Долгосрочное хранение
            Console.WriteLine("Долгосрочное хранение: ");
            long totalFilesSize = 95000000000; 
            Console.WriteLine(totalFilesSize);
            totalFilesSize = 100000000000; 
            Console.WriteLine(totalFilesSize);

            //Любимая цитата
            Console.WriteLine("Любимая цитата: ");
            string favoriteQuote = "abra kadabra";
            Console.WriteLine(favoriteQuote);
            favoriteQuote = "booms";
            Console.WriteLine(favoriteQuote);

            //Имя и фамилия
            Console.WriteLine("Имя и фамилия: ");
            string fullName = "Anna Ivanovna";
            Console.WriteLine(fullName);
            fullName = "Ivan Ivanovich";
            Console.WriteLine(fullName);

        }
    }
}
