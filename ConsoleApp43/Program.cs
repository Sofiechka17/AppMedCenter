namespace ConsoleApp43
{
    class Program
    {
        //Метод половинного деления, уточнение корней 
        // Определяем функцию F(x)
        static double F(double x)
        {
            return x * x * x - 23 * x - 42; // F(x) = x^3 - 23x - 42
        }
        static void Main(string[] args)
        {
            // Начальные значения a, b и e
            double a = -4;
            double b = -2.77;
            double e = 0.01;
            double c; // Переменная для хранения среднего значения

            while (b - a > e)
            {
                c = (a + b) / 2; // Среднее значение между a и b
                if (F(a) * F(c) < 0) // Если F(a) и F(c) имеют разные знаки
                {
                    b = c; // Сужаем интервал до [a, c]
                }
                else
                {
                    a = c; // Сужаем интервал до [c, b]
                }
            }

            // Вычисляем конечный результат
            double x = (a + b) / 2; // Значение корня
            double pogr = (b - a) / 2; // Погрешность

            // Вывод результата
            Console.WriteLine($"Значение корня: {x}");
            Console.WriteLine($"При x = {x}, погрешность = {pogr}");

            // Проверка значений F(x)
            double fx = F(x);
            Console.WriteLine($"Проверка F(x) для найденного корня: F({x}) = {fx}");
        }
    }
}
    

