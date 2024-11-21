using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Xml.Linq;

namespace ConsoleApp33
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите имя: ");
            string name = Console.ReadLine();
            Console.Write("Введите фамилию: ");
            string surname = Console.ReadLine();
            string fullNameToPLus = name + " " + surname;
            Console.WriteLine("Полное имя: " + fullNameToPLus);
            string fullNameToMethodConct = String.Concat(name, " ", surname);
            Console.WriteLine("Полное имя другим методом: " + fullNameToMethodConct);

            Console.Write("Введите первое слово: ");
            string firstWord = Console.ReadLine();
            Console.Write("Введите второе слово: ");
            string secondWord = Console.ReadLine();
            Console.Write("Введите третье слово: ");
            string thirdWord = Console.ReadLine();
            string OfferToPlus = firstWord + " " + secondWord + " " + thirdWord;
            Console.WriteLine("Итоговое предложение первый вариант: " + OfferToPlus);
            string OfferToConct = String.Concat(firstWord, " ", secondWord, " ", thirdWord);
            Console.WriteLine("Итоговое предложение второй вариант: " + OfferToConct);

            Console.Write("Введите первое число: ");
            int firstNumber = int.Parse(Console.ReadLine());
            Console.Write("Введите второе число: ");
            int secondNumber = int.Parse(Console.ReadLine());
            Console.Write("Введите третье число: ");
            int thirdNumber = int.Parse(Console.ReadLine());
            double average = (firstNumber + secondNumber + thirdNumber) / 3.0;
            Console.WriteLine($"Среднее значение: {average}");

            Console.Write("Введите имя: ");
            string nameVisitor = Console.ReadLine();
            Console.Write("Ваша любимая книга: ");
            string nameBook = Console.ReadLine();
            Console.WriteLine($"{nameVisitor}, ваша любимая книга - {nameBook}");

            Console.Write("Введите ваше имя с дополнительными пробелами по краям: ");
            string nameNoTrimmed = Console.ReadLine();
            string trimmedUserInput = nameNoTrimmed.Trim();
            Console.Write("Введите вашу фамилию с дополнительными пробелами по краям: ");
            string surnameNoTrimmed = Console.ReadLine();
            string trimmedSurname = surnameNoTrimmed.Trim();
            Console.WriteLine($"Имя: {trimmedUserInput}, Фамилия: {trimmedSurname}");

            //4) Substring не разобралась 
            //2.Создайте программу для анализа URL. Пользователь вводит URL в формате
            //"http://www.example.com/pages/index.html".Используйте метод Substring для
            //извлечения имени домена(example.com) и названия страницы(index.html), затем
            //выведите их на экран.

            Console.Write("Введите строку: ");
            string messageUser = Console.ReadLine();
            string lowerCase = messageUser.ToLower();
            Console.Write("Строка в нижнем регистре: " + lowerCase);
            string upperCase = messageUser.ToUpper();
            Console.Write("Строка в верхнем регистре: " + upperCase);

            Console.Write("Введите предложение: ");
            string userAnswer = Console.ReadLine();
            string[] splitCase = userAnswer.Split(' ');
            foreach (var sub in splitCase)
            {
                Console.WriteLine($"Слова : {sub}");
            }

            Console.Write("Введите предложение: ");
            string userSentence = Console.ReadLine();
            string sentence = userSentence.Replace("ошибка", "возможность");
            Console.WriteLine("Исправленое предложение: " + sentence);
        }
    }
}
