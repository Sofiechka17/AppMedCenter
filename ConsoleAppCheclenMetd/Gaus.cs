//using System;

//class Gaus
//{
//    static void Main(string[] args)
//    {
//        // Матрица системы уравнений (расширенная матрица)
//        double[,] matrix = {
//            { 3, -8, 1, -7, 96 },
//            { 6, 4, 8, 5, -13 },
//            { -1, 1, -9, -3, -54 },
//            { -6, 6, 9, -4, 82 }
//        };

//        int n = matrix.GetLength(0);
//        double[] roots = new double[n];

//        // Прямой ход метода Гаусса
//        for (int i = 0; i < n; i++)
//        {
//            // Поиск ведущего элемента
//            for (int j = i + 1; j < n; j++)
//            {
//                if (Math.Abs(matrix[j, i]) > Math.Abs(matrix[i, i]))
//                {
//                    // Меняем строки
//                    for (int k = 0; k <= n; k++)
//                    {
//                        double temp = matrix[i, k];
//                        matrix[i, k] = matrix[j, k];
//                        matrix[j, k] = temp;
//                    }
//                }
//            }

//            for (int j = i + 1; j < n; j++)
//            {
//                double factor = matrix[j, i] / matrix[i, i];
//                for (int k = i; k <= n; k++)
//                {
//                    matrix[j, k] -= factor * matrix[i, k];
//                }
//            }
//        }

//        // Определитель
//        double determinant = 1;
//        for (int i = 0; i < n; i++)
//        {
//            determinant *= matrix[i, i];
//        }

//        // Обратный ход
//        for (int i = n - 1; i >= 0; i--)
//        {
//            roots[i] = matrix[i, n]; // Получаем значение из последнего столбца
//            for (int j = i + 1; j < n; j++)
//            {
//                roots[i] -= matrix[i, j] * roots[j];
//            }
//            roots[i] /= matrix[i, i];
//        }

//        // Вывод корней
//        Console.WriteLine("Найденные корни:");
//        for (int i = 0; i < n; i++)
//        {
//            Console.WriteLine($"x{i + 1} = {roots[i]}");
//        }

//        // Проверка
//        Console.WriteLine("\nПроверка:");
//        for (int i = 0; i < n; i++)
//        {
//            double checkValue = 0;
//            for (int j = 0; j < n; j++)
//            {
//                checkValue += matrix[i, j] * roots[j];
//            }
//            Console.WriteLine($"Для уравнения {i + 1}: {checkValue} (ожидаемое значение: {matrix[i, n]})");
//        }

//        // Вывод определителя
//        Console.WriteLine($"\nОпределитель системы: {determinant}");
//    }
//}