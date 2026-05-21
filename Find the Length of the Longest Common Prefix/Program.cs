namespace Find_the_Length_of_the_Longest_Common_Prefix
{
    /*
Title: 3043. Find the Length of the Longest Common Prefix
Solution:
Difficulty: Medium
Approach: Trie (digit-by-digit, without string conversion)
Tags: Array, Trie
1) Build a Trie by inserting each number from arr1 digit by digit (left to right).
2) Each Trie node has 10 children — one per digit 0–9.
3) Digits are extracted without string conversion using modulo and division, then reversed.
4) For each number in arr2, traverse the Trie digit by digit to measure the longest matching prefix.
5) Track and return the maximum prefix length found across all arr2 numbers.

Time Complexity: O((m + n) * d) where m = arr1.length, n = arr2.length, d = max digits (~10)
Space Complexity: O(m * d) for the Trie nodes
Tip: Avoid string conversion by extracting digits via % 10 and / 10, then reversing — this keeps the solution purely numeric and avoids allocation overhead from ToString().
Similar Problems: 14. Longest Common Prefix, 208. Implement Trie (Prefix Tree), 212. Word Search II
*/
    public class TrieNode
    {
        public TrieNode[] Children = new TrieNode[10];      // 10 children for digits 0–9
    }

    public class Solution
    {
        private TrieNode CreateNode()
        {
            return new TrieNode();                          // Allocate and return a fresh Trie node
        }

        // Extract digits from left to right without using string conversion
        private int[] GetDigits(int number)
        {
            if (number == 0)
                return new int[] { 0 };                     // Edge case: number is zero

            int[] temp = new int[10];                       // Temporary buffer (max 10 digits for int)
            int index = 0;

            // Extract digits in reverse order (least significant first)
            while (number > 0)
            {
                temp[index++] = number % 10;                // Extract last digit
                number /= 10;                               // Remove last digit
            }

            // Reverse to get correct left-to-right order
            int[] digits = new int[index];                  // Final array sized to digit count
            for (int i = 0; i < index; i++)
            {
                digits[i] = temp[index - i - 1];            // Fill in correct (left-to-right) order
            }

            return digits;
        }

        private void InsertNumber(int number, TrieNode root)
        {
            TrieNode currentNode = root;                    // Start from root

            int[] digits = GetDigits(number);               // Get digits left to right

            foreach (int digit in digits)
            {
                if (currentNode.Children[digit] == null)
                {
                    currentNode.Children[digit] = CreateNode();     // Create node if path does not exist
                }

                currentNode = currentNode.Children[digit];  // Advance down the Trie
            }
        }

        private int GetLongestPrefixLength(int number, TrieNode root)
        {
            TrieNode currentNode = root;                    // Start traversal from root
            int[] digits = GetDigits(number);               // Get digits left to right

            int prefixLength = 0;                           // Track matched prefix length

            foreach (int digit in digits)
            {
                if (currentNode.Children[digit] != null)
                {
                    prefixLength++;                                 // Prefix extends by one digit
                    currentNode = currentNode.Children[digit];     // Move deeper into Trie
                }
                else
                {
                    break;                                  // Prefix breaks here — stop traversal
                }
            }

            return prefixLength;
        }

        public int LongestCommonPrefix(int[] arr1, int[] arr2)
        {
            TrieNode root = CreateNode();                   // Root of the Trie

            // Step 1: Insert all numbers from arr1 into the Trie
            foreach (int number in arr1)
            {
                InsertNumber(number, root);                 // Build Trie digit by digit
            }

            int maxPrefixLength = 0;                        // Track global maximum prefix length

            // Step 2: Query the Trie with each number from arr2
            foreach (int number in arr2)
            {
                int currentLength = GetLongestPrefixLength(number, root);          // Find longest prefix match
                maxPrefixLength = Math.Max(maxPrefixLength, currentLength);         // Update global max
            }

            return maxPrefixLength;                         // Return the longest common prefix length
        }
    }
}
