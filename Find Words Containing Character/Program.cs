namespace Find_Words_Containing_Character
{
    /*You are given a 0-indexed array of strings words and a character x.
    Return an array of indices representing the words that contain the character x.
    Note that the returned array may be in any order.*/
    public class Solution
    {
        public IList<int> FindWordsContaining(string[] words, char x)
        {
            var res = new List<int>(words.Length);
            for (int i = 0; i < words.Length; ++i)
            {
                if (words[i].IndexOf(x) >= 0)
                {
                    res.Add(i);
                }
            }
            return res;
        }
    }
}
