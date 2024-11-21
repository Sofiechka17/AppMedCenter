using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internet_magaz
{
    public enum Category
    {
        Одежда,
        Обувь,
        Акссесуары
    }
    public class Product
    {
        private static int totalProducts;
        private static decimal totalCost;

        public string Name { get; set; }
        public Category Category { get; set; }
        private decimal price;

        public decimal Price
        {
            get { return price; }
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Цена не может быть отрицательной");
                }
                price = value;
            }
        }

        public static int TotalProducts
        {
            get { return totalProducts; }
        }

        public static decimal TotalCost
        {
            get { return totalCost; }
        }

        public Product(string name, Category category, decimal price)
        {
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Имя не может быть пустым");
            }
            Name = name;
            Category = category;
            Price = price;

            totalProducts++;
            totalCost += price;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Название: {Name}, Категория: {Category}, Цена: {Price}");
        }

        public static void PrintTotalInfo()
        {
            Console.WriteLine($"Общее количество товаров: {totalProducts}, Общая стоимость товаров: {totalCost}, Средняя цена: {totalCost / totalProducts}");
        }

        public void Sell(decimal discount)
        {
            decimal discountedPrice = Price - (Price * discount / 100);
            Console.WriteLine($"Товар {Name} со скидкой {discount}% по цене {discountedPrice}");
            totalProducts--;
            totalCost -= discountedPrice;
        }
    }

}
