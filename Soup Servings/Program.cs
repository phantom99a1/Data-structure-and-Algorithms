namespace Soup_Servings
{
    public class Solution
    {
        public double SoupServings(int N)
        {
            if (N > 4800) return 1.0;

            int n = (int)Math.Ceiling(N / 25.0);
            var memo = new Dictionary<(int, int), double>();

            double Dp(int a, int b)
            {
                if (a <= 0 && b <= 0) return 0.5;
                if (a <= 0) return 1;
                if (b <= 0) return 0;

                var key = (a, b);
                if (memo.ContainsKey(key)) return memo[key];

                double result = 0.25 * (
                    Dp(a - 4, b) +
                    Dp(a - 3, b - 1) +
                    Dp(a - 2, b - 2) +
                    Dp(a - 1, b - 3)
                );

                memo[key] = result;
                return result;
            }

            return Dp(n, n);
        }
    }
}
