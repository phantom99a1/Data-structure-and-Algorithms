namespace Maximum_Number_of_Words_You_Can_Type
{
    public class Solution
    {
        public int CanBeTypedWords(string text, string brokenLetters)
        {
            var brokenSet = new HashSet<char>(brokenLetters);
            var words = text.Split(' ');
            int count = 0;

            foreach (var word in words)
            {
                bool canType = true;
                foreach (var c in word)
                {
                    if (brokenSet.Contains(c))
                    {
                        canType = false;
                        break;
                    }
                }
                if (canType) count++;
            }

            return count;
        }
    }
}
