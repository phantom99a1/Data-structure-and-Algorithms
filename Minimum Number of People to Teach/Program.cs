namespace Minimum_Number_of_People_to_Teach
{
    internal class Program
    {
        public int MinimumTeachings(int n, IList<IList<int>> languages, IList<IList<int>> friendships)
        {
            var knows = new Dictionary<int, HashSet<int>>();
            for (int i = 0; i < languages.Count; i++)
            {
                knows[i + 1] = new HashSet<int>(languages[i]);
            }

            var toTeach = new HashSet<int>();
            foreach (var pair in friendships)
            {
                int u = pair[0], v = pair[1];
                var uLangs = knows[u];
                var vLangs = knows[v];
                if (!uLangs.Intersect(vLangs).Any())
                {
                    toTeach.Add(u);
                    toTeach.Add(v);
                }
            }

            int minTeach = int.MaxValue;
            for (int lang = 1; lang <= n; lang++)
            {
                int count = 0;
                foreach (int user in toTeach)
                {
                    if (!knows[user].Contains(lang)) count++;
                }
                minTeach = Math.Min(minTeach, count);
            }

            return minTeach;
        }
    }
}
