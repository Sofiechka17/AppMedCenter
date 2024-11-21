namespace ConsoleApp39
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] examScores = new int[] { 5, 4, 3, 2, 1 };
            int firstExamScore;
            int nextExamScore;
        

            for (int i = 0; i < examScores.Length - 1; i++)
            {
                firstExamScore = examScores[i];

                for (int j = i; j < examScores.Length - i - 1; j++)
                {
                    nextExamScore = examScores[j];

                    if (firstExamScore < nextExamScore)
                    {
                        examScores[i] = nextExamScore;
                        examScores[j] = firstExamScore;
                    }
                }
            }

            foreach (int examScore in examScores)
            {
                Console.WriteLine(examScore);
            }
        }
    }
}
