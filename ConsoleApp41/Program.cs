namespace ConsoleApp41
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Создайте программу, которая копирует три средних элемента из массива из пяти элементов в новый массив и выводит их.

            int[] appleCounts = new int[] { 1, 2, 3, 4, 5};
            int[] centralAppleCounts = new int[3];

            Array.Copy(appleCounts, 1, centralAppleCounts, 0, 3);

            foreach (int appleCount in appleCounts)
            {
                Console.WriteLine(appleCount);
            }

            Console.WriteLine("");

            foreach (int centralAppleCount in centralAppleCounts)
            {
                Console.WriteLine(centralAppleCount);
            }

            //int[] userActivityHours = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23 };

            //Array.Sort(userActivityHours);

            //foreach (int userActivityHour in userActivityHours)
            //{
            //    Console.WriteLine(userActivityHour);
            //}

            //int minUserActivityHourIndex = 0;
            //int minUserActivityHour = userActivityHours[minUserActivityHourIndex];

            //Console.WriteLine($"Наименьшая активность пользователей: { minUserActivityHour}");

            //int maxUserActivityHourIndex = userActivityHours.Length - 1;
            //int maxUserActivityHour = userActivityHours[maxUserActivityHourIndex];

            //Console.WriteLine($"Наибольшая активность пользователей: {maxUserActivityHour}");

        }
    }
}
