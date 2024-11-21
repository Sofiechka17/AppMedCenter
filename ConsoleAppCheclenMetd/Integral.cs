using System;

namespace ConsoleAppCheclenMetd
{
    internal class Integral
    {
        static void Main()
        {
            double a = 0.0;   // Нижний предел интегрирования
            double b = 1.0;   // Верхний предел интегрирования
            double h = 0.1;   // Шаг интегрирования

            double result = SimpsonMethod(a, b, h);
            Console.WriteLine("Значение интеграла: " + result);
        }

        // Метод Симпсона для численного интегрирования
        static double SimpsonMethod(double a, double b, double h)
        {
            int n = (int)((b - a) / h);
            if (n % 2 != 0)
            {
                throw new ArgumentException("Количество подинтервалов n должно быть чётным.");
            }

            double sum = Function(a) + Function(b); 

            for (int i = 1; i < n; i++)
            {
                double x = a + i * h;

                // Если индекс чётный и не является последним чётным индексом
                if (i % 2 == 0 && i < n - 1)
                {
                    sum += 2 * Function(x); // Чётные индексы, без последнего
                }
                // Если индекс нечётный и не является последним нечётным индексом
                else if (i % 2 != 0 && i < n - 1)
                {
                    sum += 4 * Function(x); // Нечётные индексы, без последнего
                }
            }

            return (h / 3) * sum; // Итоговое значение интеграла
        }

        // Функция f(x) = 1 / (x^2 + 1)
        static double Function(double x)
        {
            return 1 / (x * x + 1);
        }
    }
}
