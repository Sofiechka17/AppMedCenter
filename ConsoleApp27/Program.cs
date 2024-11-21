using System;

namespace ConsoleApp27
{
    internal class Program
    {
        static int count = 0;
        static int limit = int.Parse(Console.ReadLine());

        static void Main(string[] args)
        {
            while (count < limit)
            {
                count++;
                Console.WriteLine(count);
            }

            if (count % 2 == 0)
            {
                Console.WriteLine("Число четное");
            }
            else
            {
                Console.WriteLine("Число нечетное");
            }
        }
    }
}
