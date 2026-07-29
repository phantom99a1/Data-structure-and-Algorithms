namespace Smallest_Palindromic_Rearrangement_II
{
    public class Solution
    {
        public string SmallestPalindrome(string s, int k)
        {
            var lettersCount = 'z' - 'a' + 1;
            var freq = new int[lettersCount];
            for (var i = 0; i < s.Length / 2; i += 1)
                freq[s[i] - 'a'] += 1;
            var smallest = new int[s.Length / 2];
            var pos = 0;
            for (var i = 0; i < freq.Length; i += 1)
            {
                while (freq[i] > 0)
                {
                    smallest[pos] = i;
                    freq[i] -= 1;
                    pos += 1;
                }
            }
            var total = 1L;
            pos = smallest.Length - 1;
            while (pos >= 0)
            {
                total *= smallest.Length - pos;
                freq[smallest[pos]] += 1;
                total /= freq[smallest[pos]];
                if (total >= k)
                    break;
                pos -= 1;
            }
            if (total < k)
                return string.Empty;
            var current = 1L;
            while (current < k)
            {
                for (var i = 0; i < freq.Length; i += 1)
                {
                    if (freq[i] < 1)
                        continue;
                    var d = total * freq[i];
                    d /= smallest.Length - pos;
                    smallest[pos] = i;
                    if (current + d > k)
                        break;
                    current += d;
                }
                total *= freq[smallest[pos]];
                total /= smallest.Length - pos;
                freq[smallest[pos]] -= 1;
                pos += 1;
            }
            for (var i = 0; i < freq.Length; i += 1)
            {
                while (freq[i] > 0)
                {
                    smallest[pos] = i;
                    freq[i] -= 1;
                    pos += 1;
                }
            }
            var arr = new char[s.Length];
            for (var i = 0; i < smallest.Length; i += 1)
            {
                arr[i] = (char)(smallest[i] + 'a');
                arr[^(i + 1)] = arr[i];
            }
            if ((s.Length & 1) != 0)
                arr[s.Length / 2] = s[s.Length / 2];
            return new string(arr);
        }
    }
}
