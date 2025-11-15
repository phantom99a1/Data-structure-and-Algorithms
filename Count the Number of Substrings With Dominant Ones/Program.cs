namespace Count_the_Number_of_Substrings_With_Dominant_Ones
{
    public class Solution
    {
        public int NumberOfSubstrings(string s)
        {
            int n = s.Length;
            int ans = 0;

            for (int zero = 0; zero + zero * zero <= n; ++zero)
            {
                int lastInvalidPos = -1;
                int[] count = new int[2]; // count[0] = zeros, count[1] = ones

                for (int l = 0, r = 0; r < n; ++r)
                {
                    count[s[r] - '0']++;

                    while (l < r)
                    {
                        if (s[l] == '0' && count[0] > zero)
                        {
                            count[0]--;
                            lastInvalidPos = l;
                            l++;
                        }
                        else if (s[l] == '1' && count[1] - 1 >= zero * zero)
                        {
                            count[1]--;
                            l++;
                        }
                        else
                        {
                            break;
                        }
                    }

                    if (count[0] == zero && count[1] >= zero * zero)
                    {
                        ans += l - lastInvalidPos;
                    }
                }
            }
            return ans;
        }
    }
}
