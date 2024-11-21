namespace ConsoleApp22
{
    delegate void PrintDelegate(string text);
    delegate string StringCombinerDelegate(params string[] text);
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintDelegate printDel = delegate (String text);
            {
                Console.WriteLine(text);
            };
            printDel += delegate (string text)
            {
                for (int i = text.Length - 1; i > -1; i--)
                {
                    Console.WriteLine(text[i] + "|");
                }
            };
            printDel("some text");
            
        }
    }
}
