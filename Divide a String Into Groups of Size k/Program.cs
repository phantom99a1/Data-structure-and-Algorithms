namespace Divide_a_String_Into_Groups_of_Size_k
{
    public class Solution
    {
        public IList<string> DivideString(string s, int k, char fill)
        {
            List<string> result = new List<string>();
            for (int i = 0; i < s.Length; i += k)
            {
                string chunk = s.Substring(i, Math.Min(k, s.Length - i));
                if (chunk.Length < k)
                {
                    chunk = chunk.PadRight(k, fill);
                }
                result.Add(chunk);
            }
            return result;
        }
    }
}
