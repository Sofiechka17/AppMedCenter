using System.Data.SqlTypes;

namespace ConsoleApp32
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("#1");
            int appleCount = 10;
            Console.WriteLine($"Количество яблок: {appleCount}");
            double applePorezal = appleCount / 3;
            Console.WriteLine($"Количество яблок у Пети: {applePorezal}");

            //Console.WriteLine("#2");
            //string privet = "hello";
            //char symbol = 'w';
            //char abraKadabra = Convert.ToChar(privet);
            //char krokozybra = abraKadabra + symbol;
            //Console.WriteLine(krokozybra);

            Console.WriteLine("#3");
            string prostoStroka = "123";
            int numberBooks = int.Parse(prostoStroka);
            Console.WriteLine(numberBooks + 10);

            Console.WriteLine("#4");
            bool pogodaGood = true;
            bool pogodaCry = false;
            Console.WriteLine(pogodaGood && pogodaCry);
            Console.WriteLine(pogodaGood || pogodaCry);
            Console.WriteLine(!pogodaGood);

            Console.WriteLine("#5");
            decimal ostatokChet = 100.50m;
            string preobrazyemChet = Convert.ToString(ostatokChet);
            Console.WriteLine($"Остаток счета: {preobrazyemChet}");

            Console.WriteLine("#6");
            int kokoc = 5;
            double moloko = 3.14;
            string neKokoc = Convert.ToString(kokoc);
            string neMoloko = Convert.ToString(moloko);
            Console.WriteLine(neKokoc + neMoloko);

            Console.WriteLine("#7");
            int vishnyPirog = 7;
            double applePirog = 3.5;
            double sumPirog = vishnyPirog + applePirog;
            Console.WriteLine(sumPirog);

            Console.WriteLine("#8");
            string dress = "10";
            int dressCount = int.Parse(dress);
            int sumDressCount = dressCount + 5;
            Console.WriteLine(sumDressCount);

            Console.WriteLine("#9");
            int orange = 5;
            int banana = 7;
            int max = Math.Max(orange, banana);
            Console.WriteLine(max);
        }
    }
}
