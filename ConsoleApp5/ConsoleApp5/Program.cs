namespace ConsoleApp5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = 10;
            int[,] mainArray;
            PrintArray(ref size, 10, 99, out mainArray);
          
            Console.WriteLine($"значение перемпенной size после работы метода {size}");

            //Console.WriteLine("первая строка массива:");
            //for (int i = 0; i < 10; i++) 
            //{
            //    Console.Write(mainArray[0,i]+", ");
            //}
        }
        static void PrintArray(ref int size, int min, int max, out int[,] array) 
        {
            size = 5;
             array = new int[size, size];
            Random rnd = new Random();
            for (int i = 0; i < size; i++) 
            {
             for (int j = 0; j < size; j++) 
                {
                    array[i, j] = rnd.Next(min, max);
                    Console.Write(array[i, j]+", ");
                }
             Console.WriteLine();
            }
            return;
        }
    }
}