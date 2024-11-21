namespace Calc
{
    internal class Program
    {
        static void Main(string[] args)
        {
            do
            {
                int x = GetNumber("Пожалуйста, введите первое число : ");
                int y = GetNumber("Пожалуйста, введите второе число : ");

                Console.WriteLine("Пожалуйста, выберите команду: +, -, *, /, min, max");
                string cmd = Console.ReadLine();

                int result = GetResult(x, y, cmd);

                Console.WriteLine(result);

            }
            while (AskContinue());
        }

        private static bool AskContinue()
        {
            while (true)
            {
                Console.WriteLine("Хотите продолжить? Y/N");
                var status = Console.ReadLine();
                if (status == "Y" || status == "y")
                    return true;
                else if (status == "N" || status == "n")
                    return false;
                else
                    Console.WriteLine("Операция не распознана. Введите Y или N: ");
            }
        }

        private static int GetResult(int x, int y, string? cmd)
        {
            int result;
            switch (cmd)
            {
                case "+":
                    result = x + y;
                    break;
                case "-":
                    result = x - y;
                    break;
                case "*":
                    result = x * y;
                    break;
                case "/":
                    result = x / y;
                    break;
                case "min":
                    result = GetMin(x, y);
                    break;
                case "max":
                    result = GetMax(x, y);
                    break;
                default:
                    result = 0;
                    break;
            }
            return result;
        }

        private static int GetNumber(string text)
        {
            Console.WriteLine(text);

            while (true)
            {
                string str = Console.ReadLine();
                int result;
                if (Int32.TryParse(str, out result))
                    return result;
                else
                    Console.WriteLine("Неправильный формат числа. Попробуйте еще раз");
            }
        }

        static int GetMax(int a, int b)
        {
            int max = 0;
            if (a > b)
            {
                max = a;
            }
            else
            {
                max = b;
            }
            return max;
        }

        static int GetMin(int a, int b)
        {
            int min = 0;
            if (a < b)
                min = a;
            else
                min = b;
            return min;
        }
    }
}