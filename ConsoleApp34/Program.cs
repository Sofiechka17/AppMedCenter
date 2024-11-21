namespace ConsoleApp34
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x = 5;
            int result = x + 10 * 2 + x / 3;
            Console.WriteLine("Ответ: " + result);
            //1)10 * 2 = 20
            //2)х/3 = 1
            //3)5 + 20 + 1 = 26
            //4)result = 26

            int result1 = 5 + 10 * 2 / 4 - 3 % 2;
            Console.WriteLine("Ответ: " + result1);
            //25/4-1=5,25 ?!

            int result2 = (10 + 4) * 2 - (6 / (3 - 1));
            Console.WriteLine("Ответ: " + result2);
            //28-3=25

            int y = 5;
            int result3 = y++ + --y * 2 + y--; 
            Console.WriteLine("Ответ: " + result3);
            // 5 + 4 * 2 + 5    18?!

            int number = -8;
            int result4 = number < 0 ? -number : number * 2;
            Console.WriteLine("Ответ: " + result4);
            //8

            bool result5 = (5 > 3 && 4 < 7) || !(8 == 9);
            Console.WriteLine("Ответ: " + result5);
            // 1 || 1 = 1 true

            int result6 = 5 + 10 * 2 / 4 - 3 % 2;
            Console.WriteLine("Ответ: " + result6);
            
            int result7 = (5 + 3) * 4 - (6 / (2 - 1));
            Console.WriteLine("Ответ: " + result7);
            //32-6=26 

            bool result8 = (7 > 3 || 4 < 2) && !(6 <= 8);
            Console.WriteLine("Ответ: " + result8);
            // (1 || 0) && 0   1&&0=0 false

            int z = 10;
            int result9 = ++z + z-- - --z;
            Console.WriteLine("Ответ: " + result9);
            //11 + 10 - 9 = 10 ?!

            int a = 5;
            int b = 7;
            bool result10 = (a > b) ? (a > 0 && b > 0) : (a < 0 || b < 0);
            Console.WriteLine("Ответ: " + result10);
            //0 || 0 = 0 false

            String result11 = "Hello" + 5 + 2;
            Console.WriteLine("Ответ: " + result11);
            //Hello52

            int result12 = 2;
            result12 += 3 * 4 - 6;
            Console.WriteLine("Ответ: " + result12);
            //8

            int c = 5;
            int d = 3;
            bool result13 = (c > 4) || ((d += 2) == 5);
            Console.WriteLine("Ответ: " + result13);
            // 1 || 1 = true 

            bool result14 = (4 > 2) || !(6 <= 3);
            Console.WriteLine("Ответ: " + result14);
            //true

            int q = 10;
            int w = 20;
            int t = 30;
            int i = 40;
            int j = 50;
            int result15 = q++ + ++w - t-- * ++i / j++;
            Console.WriteLine("Ответ: " + result15);
            //10 + 21 - 30 * 41/50 = 31 ?!
        }
    }
}
