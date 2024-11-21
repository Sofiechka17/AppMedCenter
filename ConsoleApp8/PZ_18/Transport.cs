using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ_18
{
    enum TypeOfTransport { Trolleybus, Bus, Electrichka } //список типов транспорта

    internal class Transport
    {
        string _number; //номер транспорта
        string _driver; //фио водителя
        TimeOnly _timeOut; //выход в рейс
        TimeOnly _timeEnd; //возвращение из рейса

        public static int countOfTransport; //количество транспорта

        public TypeOfTransport Type { get; set; } //типы транспорта
        public string Number //посимвольная проверка номера во время создания
        {
            get => _number;
            set
            {
                string numberTempString = value;
                char[] numberTemp = numberTempString.ToCharArray();
                if (Char.IsLetter(numberTemp[0]) && Char.IsLetter(numberTemp[1]) &&
                    Char.IsDigit(numberTemp[3]) && Char.IsDigit(numberTemp[4]) && Char.IsDigit(numberTemp[5]) &&
                    Char.IsLetter(numberTemp[7]) && Char.IsLetter(numberTemp[8]))
                {
                    _number = value;
                }
                else
                {
                    Console.WriteLine("Введите корректный номер:");
                    _number = Console.ReadLine();
                }
            }
        }

        public string Driver //проверка наличия данных в строке при создание водителя
        {
            get => _driver;
            set
            {
                if (value != "")
                {
                    _driver = value;
                }
                else
                {
                    Console.WriteLine("Вы не ввели ФИО водителя. Ему будет присвоено значение 'не назначен'");
                    _driver = "не назначен";
                }
            }
        }

        public TimeOnly TimeOut //время выезда на рейс
        {
            get => _timeOut;
            set
            {
                _timeOut = value;
            }
        }

        public TimeOnly TimeEnd //время возвращения из рейса
        {
            get => _timeEnd;
            set
            {
                _timeEnd = value;
            }
        }

        public string OnRace() //метод определения в рейсе или в парке транспорт
        {
            TimeOnly timeNow = TimeOnly.FromDateTime(DateTime.Now);

            if (timeNow.IsBetween(TimeOut, TimeEnd))
            {
                return "в рейсе";
            }
            else
            {
                return "в парке";
            }
        }

        public Transport(string number, string driver, TimeOnly timeOut, TimeOnly timeEnd, TypeOfTransport type) //полная инициализация объекта
        {
            Number = number;
            Driver = driver;
            TimeOut = timeOut;
            TimeEnd = timeEnd;
            Type = type;

            countOfTransport++;
        }

        public Transport(string number, TimeOnly timeOut, TimeOnly timeEnd, TypeOfTransport type)
        {
            Number = number;
            Console.WriteLine("Введите имя водителя: ");
            Driver = Console.ReadLine();
            TimeOut = timeOut;
            TimeEnd = timeEnd;
            Type = type;
        }
        public Transport() //инциализация пустого объекта
        {
            Console.WriteLine("Вы не ввели значения. Объект не создан");
        }

        public override string ToString() //вывод информации об объекте
        {
            return new string($"Транспорт: {(Type == TypeOfTransport.Trolleybus ? "троллейбус" : (Type != TypeOfTransport.Bus ? "электричка" : "автобус"))} \n" +
                $"Имеет номер: {Number}\n" +
                $"Водитель: {Driver} \n" +
                $"Время выезда: {TimeOut}\n" +
                $"Время возвращения: {TimeEnd}\n" +
                $"В рейсе: {OnRace()}");
        }
    }
}

