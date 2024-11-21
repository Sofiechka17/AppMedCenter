using System.Net;

namespace ConsoleApp37
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ////Write a program that prints all even numbers from 1 to 100.

            //int startNumber = 1; 
            //int endNumber = 100;

            //for (int number = startNumber; number <= endNumber; number++)
            //{
            //    if (number % 2 == 0)
            //    {
            //        Console.WriteLine(number);
            //    }
            //}

            //Write a program that simulates rolling a dice until a 
            //    6 is rolled.The program should print the result of each roll and count how many rolls it took to get a 6.

            //int cubeValue = -1;
            //int minCubeValue = 1;
            //int neededCubeValue = 6;
            //int rollCount = 0;

            //while (cubeValue != neededCubeValue)
            //{
            //    Random random = new Random();
            //    cubeValue = random.Next(minCubeValue, neededCubeValue + 1);
            //    Console.WriteLine(cubeValue);
            //    rollCount++;
            //}
            //Console.WriteLine(rollCount);

            ////////////////////////////////////////////////////////////////////
            //Console.WriteLine("Введите время: ");
            //int minutes = int.Parse(Console.ReadLine());
            //int cookie = 10;
            //int cookiesCount = minutes * cookie;

            //Console.WriteLine($"За {minutes} минут будет испечено {cookiesCount} печенек");

            //for (int i = 0; i < minutes; i++)
            //{
            //    Console.WriteLine("*******");
            //}

            //int dayWeekCount = 7;
            //int totalStepsCount = 0;
            //int dayStepCount;
            //int startNormalActivityStepCount = 5000;
            //int startHardActivityStepCount = 10000;
            //Console.WriteLine("Введите количество шагов,пройденных за день:  ");

            //for (int day = 0; day < dayWeekCount; day++)
            //{
            //    Console.WriteLine($"День {day + 1}: ");
            //    dayStepCount = int.Parse(Console.ReadLine());
            //    totalStepsCount = totalStepsCount + dayStepCount; // += 
            //}

            //Console.WriteLine($"Общее количество шагов: {totalStepsCount}");

            //double arithmeticWeekStepsCount = (double)totalStepsCount/ dayWeekCount;

            //Console.WriteLine($"Среднее количество шагов: {arithmeticWeekStepsCount}");

            //if (arithmeticWeekStepsCount < startNormalActivityStepCount)
            //{
            //    Console.WriteLine("Рекомендация: Недостаточно активности");
            //}
            //else if (arithmeticWeekStepsCount <= startHardActivityStepCount)
            //{
            //    Console.WriteLine("Рекомендация: Нормальная активность");
            //}
            //else
            //{
            //    Console.WriteLine("Рекомендация: Высокая активность");
            //}

            //            Экзамен по вождению:
            //            Вы инструктор по вождению. У вас есть студент, который пытается сдать экзамен на
            //права, но его уровень навыков еще не достаточен.Вам необходимо создать программу,
            //которая будет имитировать уроки вождения со студентом. С каждым уроком навыки
            //студента улучшаются, и вам нужно определить, после скольких уроков он будет готов
            //сдать экзамен.

            //int cubeValue = -1;
            //int minCubeValue = 1;
            //int neededCubeValue = 6;
            //int rollCount = 0;

            //while (cubeValue != neededCubeValue)
            //{
            //    Random random = new Random();
            //    cubeValue = random.Next(minCubeValue, neededCubeValue + 1);
            //    Console.WriteLine(cubeValue);
            //    rollCount++;
            //}
            //Console.WriteLine(rollCount);

            //int 
            //bool didPassLicense = 1;
            //bool didntHandOverRight = 0;
            //while (handOverTheRight != didntHandOverRight)
            //{
            //    Random random = new Random();

            //}

            //Console.WriteLine("");

            //В игре у каждого персонажа есть свой уровень. Создайте массив с уровнями и выведите уровень каждого персонажа.


            int[] levels = new int[5];

            levels[0] = 1;
            levels[1] = 20;
            levels[2] = 35;
            levels[3] = 1;
            levels[4] = 289;

            for (int i = 0; i < levels.Length; i++)
            {
                Console.WriteLine(levels[i]);

            }
        }
    }
}
