namespace Maximum_Manhattan_Distance_After_K_Changes
{
    internal class Program
    {
        public int MaxDistance(string s, int k)
        {
            var directions = new List<(char, char)> { ('N', 'E'), ('N', 'W'), ('S', 'E'), ('S', 'W') };

            int Calc(char a, char b)
            {
                int max = 0, dist = 0, changes = 0;
                foreach (char ch in s)
                {
                    if (ch == a || ch == b)
                    {
                        dist++;
                    }
                    else if (changes < k)
                    {
                        changes++;
                        dist++;
                    }
                    else
                    {
                        dist--;
                    }
                    max = Math.Max(max, dist);
                }
                return max;
            }

            return directions.Max(pair => Calc(pair.Item1, pair.Item2));
        }
    }
}
