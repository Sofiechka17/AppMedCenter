namespace ConsoleApp38
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] examScores = new int[] { 5, 4, 3, 2, 1 };
            int firstMaxExamScore = -1;
            int secondMaxExamScore = -2;
            int thirdMaxExamScore = -3;

            for (int examScoreIndex = 0; examScoreIndex < examScores.Length; examScoreIndex++)
            {
                if (examScores[examScoreIndex] > firstMaxExamScore)
                {
                    firstMaxExamScore = examScores[examScoreIndex];
                }
            }

            for (int examScoreIndex = 0; examScoreIndex < examScores.Length; examScoreIndex++)
            {
                if (examScores[examScoreIndex] > secondMaxExamScore && examScores[examScoreIndex] < firstMaxExamScore)
                {
                    secondMaxExamScore = examScores[examScoreIndex];
                }
            }

            for (int examScoreIndex = 0; examScoreIndex < examScores.Length; examScoreIndex++)
            {
                if (examScores[examScoreIndex] > thirdMaxExamScore && examScores[examScoreIndex] < secondMaxExamScore)
                {
                    thirdMaxExamScore = examScores[examScoreIndex];
                }
            }

            Console.WriteLine(firstMaxExamScore);
            Console.WriteLine(secondMaxExamScore);
            Console.WriteLine(thirdMaxExamScore);     
        }
    }
}
