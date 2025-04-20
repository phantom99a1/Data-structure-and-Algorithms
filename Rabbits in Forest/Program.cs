namespace Rabbits_in_Forest
{
    /*There is a forest with an unknown number of rabbits. We asked n rabbits "How many rabbits have the same color as you?" 
    and collected the answers in an integer array answers where answers[i] is the answer of the ith rabbit.
    Given the array answers, return the minimum number of rabbits that could be in the forest.
    
     Constraint:
    1 <= answers.length <= 1000
    0 <= answers[i] < 1000
     */
    using System;
    using System.Collections.Generic;

    public class Solution
    {
        public int NumRabbits(int[] answers)
        {
            Dictionary<int, int> count = new Dictionary<int, int>();
            int result = 0;

            foreach (int answer in answers)
            {
                if (!count.ContainsKey(answer))
                {
                    count[answer] = 0;
                }
                count[answer]++;
            }

            foreach (var kvp in count)
            {
                int x = kvp.Key;       // rabbit says x others have same color
                int freq = kvp.Value;  // how many times this answer appeared
                int groupSize = x + 1;
                int groups = (freq + groupSize - 1) / groupSize; // ceiling division
                result += groups * groupSize;
            }

            return result;
        }
    }
}
