namespace ConsoleApp40
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] examScores = new int[] { 5, 7, 1, 3, 10 };
            int maxExamScore;
            int averageExamScore;

            Array.Sort(examScores);

            foreach (int examScore in examScores)
            {
                Console.WriteLine(examScore);
            }

            Console.WriteLine($"Минимальный балл: {examScores[0]}");

            maxExamScore = examScores.Length;

            Console.WriteLine($"Максимальный балл: {maxExamScore}");
        }
    }
}
