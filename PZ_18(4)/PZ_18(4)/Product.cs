using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ_18_4_
{
    enum sales { одежда, обувь, аксессуары }
    internal class Product
    {
        private string name;
        private sales category;
        private double price;
        private static double count;
        public double Count() { return count; }

        private static double allPrice;
        public double AllPrice() { return allPrice; }
        public string Name { get { return name; } }
        public sales Category { get { return category; } }
        public double Price { get { return price; } }
        public Product(string name, sales category, int price)
        {
            count++;
            allPrice += price;
            this.name = name;
            this.category = category;
            this.price = price;
        }

        public override string ToString()
        {
            return ($"name: {name}, category: {category}, price: {price}");
        }

        public string ProductInfo()
        {
            double average = Math.Round(allPrice / count);
            return $"count: {count}, allPrice: {allPrice}, average price: {average}";
        }

        public void Sale(sales sale)
        {
            count--;
            double saleee = 0;
            if (sale == sales.одежда)
            {
                saleee = price - price * 0.05;
            }
            else if (sale == sales.обувь)
            {
                saleee = price - price * 0.07;
            }
            else if (sale == sales.аксессуары)
            {
                saleee = price - price * 0.1;
            }
            price = saleee;

            allPrice -= price;

        }

    }
}
