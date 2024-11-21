namespace ConsoleApp35
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int y = 5;
            //int result3 = y++ + --y * 2 + y--;
            //Console.WriteLine("Ответ: " + result3);
            //// y++ = 5
            //// y = 6

            //// --y = 5
            //// y = 5

            //// y-- = 5
            //// y = 4

            ////5 + 10 + 5 = 20
            //Console.WriteLine(y);

            //int z = 10;
            //int result9 = ++z + z-- - --z;
            //Console.WriteLine("Ответ: " + result9);
            ////++z = 11
            ////z = 11

            ////z-- = 11
            ////z = 10

            ////--z = 9
            ////z = 9

            //// 11 + 11 - 9 = 13
            //Console.WriteLine(z);

            //int q = 10;
            //int w = 20;
            //int t = 30;
            //int i = 40;
            //int j = 50;
            //int result15 = q++ + ++w - t-- * ++i / j++;
            //Console.WriteLine("Ответ: " + result15);

            //Напишите программу, которая проверяет, является ли число положительным, 
            //    и выводит соответствующее сообщение.Если число положительное, программа должна вывести "Число положительное".

            int number = 12;

            if (number > 0)
            {
                Console.WriteLine("Число положительное");
            }
            else
            {
                if (number < 0)
                {
                    Console.WriteLine("Число отрицательное");
                }
                else
                {
                    Console.WriteLine("Число не отриц и не положительное");
                } 
            } 
        }
    }
}
