namespace Sort_Vowels_in_a_String
{
    internal class Program
    {
        public string SortVowels(string s)
        {
            HashSet<char> vowels = new HashSet<char>("aeiouAEIOU");
            List<char> vowelList = new List<char>();
            List<int> indices = new List<int>();
            char[] chars = s.ToCharArray();

            // Extract vowels and their positions
            for (int i = 0; i < chars.Length; i++)
            {
                if (vowels.Contains(chars[i]))
                {
                    vowelList.Add(chars[i]);
                    indices.Add(i);
                }
            }

            // Sort vowels
            vowelList.Sort();

            // Reinsert sorted vowels
            for (int i = 0; i < indices.Count; i++)
            {
                chars[indices[i]] = vowelList[i];
            }

            return new string(chars);
        }
    }
}
