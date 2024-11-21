//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Cryptography.X509Certificates;
//using System.Text;
//using System.Threading.Tasks;

//namespace ConsoleApp27
//{
//    internal class Program
//    {

//        static void Main(string[] args)
//        {
//            double E = 0.01;
//            double x1 = -5.85;
//            double x2 = -0.077;
//            double x3 = 2.882;
//            double x4 = 0.84;
//            for (int i = 1; i < 20; i++)
//            {
//                Console.WriteLine($"Значение x1 = {Func1(x1, x2, x3, x4)}");
//                Console.WriteLine($"Значение x2 = {Func2(x1, x2, x3, x4)}");
//                Console.WriteLine($"Значение x3 = {Func3(x1, x2, x3, x4)}");
//                Console.WriteLine($"Значение x4 = {Func4(x1, x2, x3, x4)}\n------------------------------------");
//                x1 = Func1(x1, x2, x3, x4);
//                x2 = Func2(x1, x2, x3, x4);
//                x3 = Func3(x1, x2, x3, x4);
//                x4 = Func4(x1, x2, x3, x4);
//                if (Math.Abs(x1) - Math.Abs(Func1(x1, x2, x3, x4)) <= E &&
//                    Math.Abs(x2) - Math.Abs(Func2(x1, x2, x3, x4)) <= E &&
//                    Math.Abs(x3) - Math.Abs(Func3(x1, x2, x3, x4)) <= E &&
//                    Math.Abs(x1) - Math.Abs(Func1(x1, x2, x3, x4)) <= E)
//                {
//                    Console.WriteLine($"Решение было найдено за {i} итераций");
//                    break;
//                }
//            }
//        }

//        static double Func1(double x1, double x2, double x3, double x4)
//        {
//            return -5.85 - 0.25 * x2 - 0.35 * x3 - 0.05 * x4;
//        }

//        static double Func2(double x1, double x2, double x3, double x4)
//        {
//            return -0.077 + 0.077 * x1 + 0.538 * x4;
//        }

//        static double Func3(double x1, double x2, double x3, double x4)
//        {
//            return 2.882 - 0.235 * x1 + 0.353 * x2 - 0.294 * x4;
//        }

//        static double Func4(double x1, double x2, double x3, double x4)
//        {
//            return 0.84 - 0.36 * x1 + 0.32 * x2 + 0.16 * x3;
//        }
//    }
//}