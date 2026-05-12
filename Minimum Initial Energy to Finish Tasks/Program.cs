namespace Minimum_Initial_Energy_to_Finish_Tasks
{
    public class Solution
    {

        public int MinimumEffort(int[][] tasks)
        {

            tasks.ToList().Sort((x, y) => {

                var a = x[1] - x[0];
                var b = y[1] - y[0];

                return a.CompareTo(b);
            });

            int result = 0;

            foreach (var task in tasks)
            {

                result = Math.Max(result + task[0], task[1]);
            }

            return result;
        }
    }
}
