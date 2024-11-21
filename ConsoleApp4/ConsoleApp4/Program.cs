//////Создать Метод GetArea принимающий значение боковой стороны 
////конуса и радиуса основания и возвращающий площадь 
////поверхности консуса.         ctrl + k + c    ctrl + k + u

//using System;

//class Program
//{
//    static void Main(string[] args)
//    {
//        Console.WriteLine("Введите значение боковой стороны конуса:");
//        double bHeight = double.Parse(Console.ReadLine());

//        Console.WriteLine("Введите значение радиуса основания:");
//        double Radius = double.Parse(Console.ReadLine());

//        double surfaceArea = GetArea(bHeight, Radius);

//        Console.WriteLine("Площадь поверхности конуса: " + surfaceArea);
//    }

//    static double GetArea(double bHeight, double Radius)
//    {
//        double baseArea = Math.PI * Math.Pow(Radius, 2);
//        double lateralArea = Math.PI * Radius * bHeight;

//        return baseArea + lateralArea;
//    }
//}


using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите размерность массива:");
        int p = int.Parse(Console.ReadLine());

        ArrayGeneration(p);
    }

    static void ArrayGeneration(int p)
    {
        int[,] array = new int[p, p];

        Random random = new Random();

        for (int i = 0; i < p; i++)
        {
            for (int j = 0; j < p; j++)
            {
                array[i, j] = random.Next(100);
                Console.Write(array[i, j] + " ");
            }

            Console.WriteLine();
        }
    }
}