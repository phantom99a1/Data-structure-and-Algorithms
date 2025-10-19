namespace Lexicographically_Smallest_String_After_Applying_Operations
{
    public class Solution
    {
        public string FindLexSmallestString(string s, int a, int b)
        {
            var seen = new HashSet<string>();
            var queue = new Queue<string>();
            string res = s;
            queue.Enqueue(s);
            seen.Add(s);

            while (queue.Count > 0)
            {
                string curr = queue.Dequeue();
                if (string.Compare(curr, res) < 0) res = curr;

                // Operation 1: Add 'a' to odd indices
                char[] arr = curr.ToCharArray();
                for (int i = 1; i < arr.Length; i += 2)
                {
                    arr[i] = (char)(((arr[i] - '0' + a) % 10) + '0');
                }
                string added = new string(arr);
                if (!seen.Contains(added))
                {
                    seen.Add(added);
                    queue.Enqueue(added);
                }

                // Operation 2: Rotate right by b
                string rotated = curr.Substring(curr.Length - b) + curr.Substring(0, curr.Length - b);
                if (!seen.Contains(rotated))
                {
                    seen.Add(rotated);
                    queue.Enqueue(rotated);
                }
            }

            return res;
        }
    }
}
