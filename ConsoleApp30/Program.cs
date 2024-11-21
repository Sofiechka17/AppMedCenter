using System;

namespace ConsoleApp30
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Введите ваше имя и фамилию: ");
            //string fullName = Console.ReadLine();
            //// Иван Иванович
            ////string name = fullName[0].ToString() + fullName[1] + fullName[2] + fullName[3];
            //string name = fullName.Substring(0,fullName.IndexOf(' '));
            //fullName.Substring()
            //Console.WriteLine(name);

            ////Создайте программу для анализа URL. Пользователь вводит URL в формате
            //"http://www.example.com/pages/index.html".Используйте метод Substring для
            //извлечения имени домена(example.com) и названия страницы(index.html), затем
            //выведите их на экран.
            // htpp://www.ananas.com/pages/index.html

            Console.WriteLine("Введите URL: ");
            string url = Console.ReadLine();
            string web = "www.";
            int webIndex = url.IndexOf(web);
            int domainStartIndex = webIndex + web.Length;
            Console.WriteLine(domainStartIndex);
            string splitter = "/";
            int splitterIndex = url.IndexOf(splitter, domainStartIndex);
            int domainEndIndex = splitterIndex;
            int domainLength = domainEndIndex - domainStartIndex;
            string domain = url.Substring(domainStartIndex, domainLength);
            Console.WriteLine(domain);
            


        }
    }
}
