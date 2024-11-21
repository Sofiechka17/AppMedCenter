namespace PZ_18_4_
{
    internal class Program
    {
        Product product = new Product("shorts", sales.одежда, 1000);
        Console.WriteLine(product);
Console.WriteLine(product.ProductInfo());
Product product1 = new Product("shorts", sales.одежда, 1000);
        Console.WriteLine(product1);
Console.WriteLine(product1.ProductInfo());
Product product2 = new Product("shorts", sales.одежда, 1000);
        Console.WriteLine(product2);
Console.WriteLine(product2.ProductInfo());
Product product3 = new Product("shorts", sales.одежда, 1000);
        Console.WriteLine(product3);
Console.WriteLine(product3.ProductInfo());
product.Sale(sales.одежда);
Console.WriteLine(product.Count());
Console.WriteLine(product.AllPrice());

    }
}
