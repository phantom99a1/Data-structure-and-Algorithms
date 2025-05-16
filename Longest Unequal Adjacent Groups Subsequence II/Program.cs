namespace Longest_Unequal_Adjacent_Groups_Subsequence_II
{
    /*You are given a string array words, and an array groups, both arrays having length n.
    The hamming distance between two strings of equal length is the number of positions at which the corresponding characters 
    are different. You need to select the longest subsequence from an array of indices [0, 1, ..., n - 1], 
    such that for the subsequence denoted as [i0, i1, ..., ik-1] having length k, the following holds:
    For adjacent indices in the subsequence, their corresponding groups are unequal, i.e., groups[ij] != groups[ij+1], 
    for each j where 0 < j + 1 < k. words[ij] and words[ij+1] are equal in length, and the hamming distance 
    between them is 1, where 0 < j + 1 < k, for all indices in the subsequence.
    Return a string array containing the words corresponding to the indices (in order) in the selected subsequence. 
    If there are multiple answers, return any of them. Note: strings in words may be unequal in length.
    
     Constraint:
    1 <= n == words.length == groups.length <= 1000
    1 <= words[i].length <= 10
    1 <= groups[i] <= n
    words consists of distinct strings.
    words[i] consists of lowercase English letters.
     */

    public class Solution
    {
        public IList<string> GetWordsInLongestSubsequence(string[] words, int[] groups)
        {
            int n = words.Length;
            int[] dp = new int[n];       // dp[i] = length of longest valid subsequence ending at i
            int[] prev = new int[n];     // prev[i] = index of previous word in the sequence
            Array.Fill(dp, 1);
            Array.Fill(prev, -1);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (groups[i] != groups[j] &&
                        words[i].Length == words[j].Length &&
                        HammingDistance(words[i], words[j]) == 1)
                    {
                        if (dp[j] + 1 > dp[i])
                        {
                            dp[i] = dp[j] + 1;
                            prev[i] = j;
                        }
                    }
                }
            }

            // Find the index with the maximum dp value
            int maxLength = 0;
            int endIndex = 0;
            for (int i = 0; i < n; i++)
            {
                if (dp[i] > maxLength)
                {
                    maxLength = dp[i];
                    endIndex = i;
                }
            }

            // Reconstruct the sequence
            List<string> result = new List<string>();
            while (endIndex != -1)
            {
                result.Add(words[endIndex]);
                endIndex = prev[endIndex];
            }

            result.Reverse();
            return result;
        }

        private int HammingDistance(string a, string b)
        {
            int count = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i]) count++;
            }
            return count;
        }
    }
}
