namespace Maximum_Average_Pass_Ratio_Verson_2
{
    public class Solution
    {
        public double MaxAverageRatio(int[][] classes, int extraStudents)
        {
            var pq = new PriorityQueue<(int pass, int total), double>();

            foreach (var c in classes)
            {
                int pass = c[0], total = c[1];
                double gain = Gain(pass, total);
                pq.Enqueue((pass, total), -gain);
            }

            while (extraStudents-- > 0)
            {
                var (pass, total) = pq.Dequeue();
                pass++;
                total++;
                pq.Enqueue((pass, total), -Gain(pass, total));
            }

            double sum = 0;
            while (pq.Count > 0)
            {
                var (pass, total) = pq.Dequeue();
                sum += (double)pass / total;
            }

            return sum / classes.Length;
        }

        private double Gain(int pass, int total)
        {
            return (double)(pass + 1) / (total + 1) - (double)pass / total;
        }
    }
}
