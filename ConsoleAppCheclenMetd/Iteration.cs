//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ConsoleAppCheclenMetd
//{
//    internal class Iteration
//    {
//        static void Main()
//        {
//            // Порог точности
//            double E = 0.01;

//            // Начальные приближения для переменных
//            double x1 = -5.85, x2 = -0.077, x3 = 2.882, x4 = 0.84;

//            // Переменные для хранения новых значений
//            double newX1, newX2, newX3, newX4;

//            // Коэффициенты для исходной матрицы
//            double[,] coefficients = {
//            { 0, -0.25, -0.35, -0.05 },
//            { 0.077, 0, 0, 0.538 },
//            { -0.235, 0.353, 0, -0.294 },
//            { -0.36, 0.32, 0.16, 0 }
//        };

//            // Вычисление нормы ||A||
//            double normA = Math.Round(CalculateNorm(coefficients), 3);
//            Console.WriteLine("Норма ||A|| = " + normA);

//            // Проверка, примерно равна ли норма 1
//            if (Math.Abs(normA - 1) < 0.1)
//            {
//                Console.Write("Система имеет единственное решение.");
//            }
//            else
//            {
//                Console.Write("Система может не иметь единственного решения.");
//            }

//            // Метод простой итерации
//            while (true)
//            {
//                // Вычисление новых значений на основе текущих значений
//                newX1 = -5.85 - 0.25 * x2 - 0.35 * x3 - 0.05 * x4;
//                newX2 = -0.077 + 0.077 * x1 + 0.538 * x4;
//                newX3 = 2.882 - 0.235 * x1 + 0.353 * x2 - 0.294 * x4;
//                newX4 = 0.84 - 0.36 * x1 + 0.32 * x2 + 0.16 * x3;

//                // Проверка на точность
//                if (Math.Max(Math.Abs(newX1 - x1), Math.Max(Math.Abs(newX2 - x2), Math.Max(Math.Abs(newX3 - x3), Math.Abs(newX4 - x4)))) < E)
//                    break;

//                // Обновляем значения переменных для следующей итерации
//                x1 = newX1;
//                x2 = newX2;
//                x3 = newX3;
//                x4 = newX4;
//            }

//            // Округление найденных значений до целых чисел
//            int finalX1 = (int)Math.Round(newX1);
//            int finalX2 = (int)Math.Round(newX2);
//            int finalX3 = (int)Math.Round(newX3);
//            int finalX4 = (int)Math.Round(newX4);

//            Console.WriteLine("Округленные значения:");
//            Console.WriteLine("x1 = " + finalX1);
//            Console.WriteLine("x2 = " + finalX2);
//            Console.WriteLine("x3 = " + finalX3);
//            Console.WriteLine("x4 = " + finalX4);

//            // Проверка решения, подставляя округленные значения в исходную систему
//            CheckSolution(finalX1, finalX2, finalX3, finalX4);
//        }

//        // Метод для вычисления нормы ||A||
//        static double CalculateNorm(double[,] matrix)
//        {
//            double sum = 0;
//            foreach (double value in matrix)
//            {
//                sum += value * value;
//            }
//            return Math.Sqrt(sum);
//        }

//        // Метод для проверки решения
//        static void CheckSolution(int x1, int x2, int x3, int x4)
//        {
//            // Исходные константы правых частей уравнений
//            int[] constants = { -117, -1, 49, -21 };

//            // Вычисляем левую часть каждого уравнения с подставленными значениями x1, x2, x3, x4
//            int equation1 = 20 * x1 + 5 * x2 + 7 * x3 + x4;
//            int equation2 = -x1 + 13 * x2 - 7 * x4;
//            int equation3 = 4 * x1 - 6 * x2 + 17 * x3 + 5 * x4;
//            int equation4 = -9 * x1 + 8 * x2 + 4 * x3 - 25 * x4;

//            // Проверяем каждый результат
//            Console.WriteLine($"Результат для первого уравнения: {equation1} (должно быть {constants[0]})");
//            Console.WriteLine(equation1 == constants[0] ? "Первое уравнение выполнено верно." : "Первое уравнение не совпадает.");

//            Console.WriteLine($"Результат для второго уравнения: {equation2} (должно быть {constants[1]})");
//            Console.WriteLine(equation2 == constants[1] ? "Второе уравнение выполнено верно." : "Второе уравнение не совпадает.");

//            Console.WriteLine($"Результат для третьего уравнения: {equation3} (должно быть {constants[2]})");
//            Console.WriteLine(equation3 == constants[2] ? "Третье уравнение выполнено верно." : "Третье уравнение не совпадает.");

//            Console.WriteLine($"Результат для четвертого уравнения: {equation4} (должно быть {constants[3]})");
//            Console.WriteLine(equation4 == constants[3] ? "Четвертое уравнение выполнено верно." : "Четвертое уравнение не совпадает.");
//        }

//    }
//}