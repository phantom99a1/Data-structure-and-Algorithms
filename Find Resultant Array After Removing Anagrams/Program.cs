namespace Find_Resultant_Array_After_Removing_Anagrams
{
    public class Solution
    {
        public IList<string> RemoveAnagrams(string[] words)
        {
            List<string> result = new List<string>();
            result.Add(words[0]);

            for (int i = 1; i < words.Length; i++)
            {
                string prevSorted = String.Concat(result[result.Count - 1].OrderBy(c => c));
                string currSorted = String.Concat(words[i].OrderBy(c => c));

                if (prevSorted != currSorted)
                {
                    result.Add(words[i]);
                }
            }

            return result;
        }
    }
}
