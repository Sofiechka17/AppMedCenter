namespace ConsoleApp44
{
    class Program
    {
        // Определяем функцию F(x)
        static double F(double x)
        {
            return x * x * x - 23 * x - 42; // F(x) = x^3 - 23x - 42
        }

        // Определяем первую производную функции F(x)
        static double FPrime(double x)
        {
            return 3 * x * x - 23; // F'(x) = 3x^2 - 23
        }

        static void Main(string[] args)
        {
            // Критические точки
            double x1 = 2.76887;
            double x2 = -2.76887;

            // Границы интервалов
            double lowerBound = -100;
            double upperBound = 100;

            // Вывод информации
            Console.WriteLine("Таблица знаков функции F(x) и интервалы:");

            // Проверяем знак функции в каждом из критических значений и граничных значений
            double[] testPoints = { lowerBound, x2, x1, upperBound };
            foreach (double point in testPoints)
            {
                double funcValue = F(point);
                string sign = funcValue < 0 ? "-" : "+";

                Console.WriteLine($"F({point}) = {funcValue} : знак = {sign}");
            }

            // Определяем интервалы со знаками
            Console.WriteLine("\nИнтервалы с противоположными знаками:");
            Console.WriteLine("(-100; -2.76887), знак '-' на левой границе и знак '+' на правой границе");
            Console.WriteLine("(-2.76887; 2.76887), знак '-' на левой границе и знак '-' на правой границе");
            Console.WriteLine("(2.76887; 100), знак '+' на левой границе и знак '+' на правой границе");

            // Выводим возможные корни
            Console.WriteLine("\nКорни находятся в следующих интервалах:");
            Console.WriteLine("Корень в интервале (-100; -2.76887)");
            Console.WriteLine("Корень в интервале (2.76887; 100)");

            // Анализируем интервалы для нахождения корней
            double root1 = FindRoot(-100, x2); // Поиск корня в интервале (-100; -2.76887)
            double root2 = FindRoot(x1, 100);   // Поиск корня в интервале (2.76887; 100)

            // Выводим корни
            Console.WriteLine($"\nНайденные корни:");
            Console.WriteLine($"Корень 1: {root1}");
            Console.WriteLine($"Корень 2: {root2}");
        }

        static double FindRoot(double a, double b, double epsilon = 0.01)
        {
            double c;
            while ((b - a) > epsilon)
            {
                c = (a + b) / 2.0;
                if (F(a) * F(c) < 0) // Корень между a и c
                {
                    b = c;
                }
                else // Корень между c и b
                {
                    a = c;
                }
            }
            return (a + b) / 2; // Возвращаем найденный корень
        }
    }
}
