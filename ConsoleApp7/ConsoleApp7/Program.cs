namespace ConsoleApp7
{
    internal class Program
    {
        static void Main(string[] args)
        {
           char a = 'A';
            char b = 'B';
            char c = 'C';

            int n = 3;

            int result = Hanoy(n, a, b, c);
        }


        static int Hanoy(int n, Char A, Char B, Char C) 
        {
            int count = 0;
        if (n == 1) // базовый случай когда осталось последнее корльцо
                Console.WriteLine($"перенос кольца с {A} на {C} ");
        else // рекурсивный случай когда переносится 1 кольцо на свободный стержень с исполшьзованеим вспомогательного
            {
                count = Hanoy(n-1, A, C, B);
                Console.WriteLine($"перенос кольца с {A} на {C} ");
                count++;
                count += Hanoy(n - 1, B, A, C);
            }
            return count;
        }
    }
}