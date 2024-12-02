namespace Check_If_a_Word_Occurs_As_a_Prefix_of_Any_Word_in_a_Sentence
{
    /*Given a sentence that consists of some words separated by a single space, and a searchWord, 
     * check if searchWord is a prefix of any word in sentence.

    Return the index of the word in sentence (1-indexed) where searchWord is a prefix of this word. 
    If searchWord is a prefix of more than one word, return the index of the first word (minimum index). 
    If there is no such word return -1.

    A prefix of a string s is any leading contiguous substring of s.*/
    public class Solution
    {
        public static int FindPrefixIndex(string sentence, string word)
        {
            var words = sentence.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].StartsWith(word))
                {
                    return i;
                }
            }
            return -1;
        }

        public static void Main()
        {
            Console.WriteLine("Enter the sentence:");
            var sentence = Console.ReadLine();

            Console.WriteLine("Enter the word to check as a prefix:");
            var word = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(sentence) || string.IsNullOrWhiteSpace(word))
            {
                Console.WriteLine("Invalid input. Please ensure both the sentence and the word are non-empty.");
            }
            else
            {
                var index = FindPrefixIndex(sentence, word);
                Console.WriteLine(index != -1 ? $"The word occurs as a prefix at index {index + 1}." : "No, the word does not occur as a prefix in the sentence.");
            }
            Console.ReadKey();
        }
    }

}
