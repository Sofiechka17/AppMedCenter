namespace Internet_magaz
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
            
            Product p1 = new Product("", Category.Одежда, 1000);
            Product p2 = new Product("", Category.Обувь, 1000);
            Product p3 = new Product("", Category.Акссесуары, 1000);


            p1.PrintInfo();
            p2.PrintInfo();
            p3.PrintInfo();

            Product.PrintTotalInfo();

            p2.Sell(5);
            p2.Sell(7);
            p3.Sell(10);

            Console.WriteLine("Для завершения нажмите любую клавишу...");
            Console.ReadKey();

        }
    }

}
