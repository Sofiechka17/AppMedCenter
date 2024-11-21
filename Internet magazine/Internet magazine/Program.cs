using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internet_magazine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите информацию о товаре:");
            Console.Write("Название: ");
            string name = Console.ReadLine();

            Console.Write("Категория (0 - Одежда, 1 - Обувь, 2 - Аксессуары): ");
            Category category = (Category)int.Parse(Console.ReadLine());

            Console.Write("Цена: ");
            decimal price = decimal.Parse(Console.ReadLine());

            Product product = new Product(name, category, price);
            product.PrintInfo();
            Product.PrintTotalInfo();
            product.Sell(5);
            Console.ReadKey();
        }
    }
}
