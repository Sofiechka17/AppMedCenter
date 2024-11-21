namespace ConsoleApp23
{
    delegate string SomeWork(int k);

    internal class Program
    {
        static void Main(string[] args)
        {
            SomeWork work = (k) => new string('*', k);
            Console.WriteLine(work(5));
        }

        Action<string> action = (string text) =>
        {
            foreach (char item in text)
                Console.WriteLine(item + "|");
        };
    }
}

