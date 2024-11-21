//namespace ConsoleAppCheclenMetd
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            //Дано
//            float a = 3.845f;
//            float ba = 0.004f;   //погрешность a
//            float b = 16.2f;
//            float bb = 0.05f;
//            float c = 10.8f;
//            float bc = 0.1f;

//            //Истинное значение х
//            double truth_x = Math.Sqrt(a * b) / c;

//            //Относительная погрешность х
//            double rel_x = (ba/ (2 * a) + bb/ (2 * b) + bc/c) * (100/100);

//            //Умножение на 100% в математике — это умножение на 1 (потому что 100% = 1).
//            //Поэтому, если хотим оставить результат в виде десятичной дроби, мы не умножаем на 100 в коде.
//            //Здесь * (100 / 100) фактически не меняет значение.
//            //Это отражает математическую формулу с * 100 %, но результат остается в виде десятичной дроби.

//            //Абсолютная погрешность х
//            double abs_x = (truth_x * rel_x) / (100/100);

//            //Округление
//            truth_x = Math.Round(truth_x, 3);
//            rel_x = Math.Round(rel_x, 4);
//            abs_x = Math.Round(abs_x, 6);

//            //Вывод результатов
//            Console.WriteLine($"Истинное значение х: {truth_x}");
//            Console.WriteLine($"Относительная погрешность х: {rel_x}");
//            Console.WriteLine($"Абсолютная погрешность х: {abs_x}");
//        }
//    }
//}
