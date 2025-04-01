namespace Solving_Questions_With_Brainpower
{
    /*You are given a 0-indexed 2D integer array questions where questions[i] = [pointsi, brainpoweri].
    The array describes the questions of an exam, where you have to process the questions in order (i.e., starting from question 0)
    and make a decision whether to solve or skip each question. Solving question i will earn you pointsi 
    points but you will be unable to solve each of the next brainpoweri questions. If you skip question i, 
    you get to make the decision on the next question.For example, given questions = [[3, 2], [4, 3], [4, 4], [2, 5]]:
    If question 0 is solved, you will earn 3 points but you will be unable to solve questions 1 and 2.
    If instead, question 0 is skipped and question 1 is solved, you will earn 4 points but you will be unable to solve questions 
    2 and 3.Return the maximum points you can earn for the exam.

    Constraint:
    1 <= questions.length <= 10^5
    questions[i].length == 2
    1 <= pointsi, brainpoweri <= 10^5
     */
    using System;

    class Solution
    {
        public long MostPoints(int[][] questions)
        {
            int n = questions.Length;
            long[] dp = new long[n + 1];

            for (int i = n - 1; i >= 0; i--)
            {
                int points = questions[i][0];
                int brainpower = questions[i][1];
                dp[i] = Math.Max(
                    points + (i + brainpower + 1 < n ? dp[i + brainpower + 1] : 0), // Solve current question
                    dp[i + 1] // Skip current question
                );
            }

            return dp[0];
        }
    }

    // Example usage:
    class Program
    {
        static void Main()
        {
            int[][] questions = new int[][] {
            new int[] {3, 2},
            new int[] {4, 3},
            new int[] {4, 4},
            new int[] {2, 5}
        };
            Solution solution = new Solution();
            Console.WriteLine(solution.MostPoints(questions)); // Output: 5
        }
    }
}
