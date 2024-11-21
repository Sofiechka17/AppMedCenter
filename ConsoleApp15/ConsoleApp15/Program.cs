using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<int> sequence = new List<int>();

        // Ввод последовательности
        Console.WriteLine("Введите последовательность натуральных чисел (для завершения введите нечисловую строку):");

        // Считывание последовательности до тех пор, пока вводятся натуральные числа
        while (true)
        {
            string input = Console.ReadLine();
            int number;

            bool isNumber = Int32.TryParse(input, out number);

            // Если введена нечисловая строка, завершаем ввод
            if (!isNumber)
            {
                break;
            }

            sequence.Add(number);
        }

        // Находим самую сильную пару
        int maxSum = 0;
        for (int i = 0; i < sequence.Count; i++)
        {
            for (int j = i + 1; j < sequence.Count; j++)
            {
                int sum = sequence[i] + sequence[j];
                if (sum % 29 == 0 && sum > maxSum)
                {
                    maxSum = sum;
                }
            }
        }

        // Вывод результата
        Console.WriteLine("Самая сильная сумма: " + maxSum);
    }
}