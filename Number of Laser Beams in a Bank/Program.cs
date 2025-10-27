namespace Number_of_Laser_Beams_in_a_Bank
{
    public class Solution
    {
        public int NumberOfBeams(string[] bank)
        {
            int prevCount = 0;
            int totalBeams = 0;

            foreach (string row in bank)
            {
                int currCount = row.Count(c => c == '1');
                if (currCount > 0)
                {
                    totalBeams += prevCount * currCount;
                    prevCount = currCount;
                }
            }

            return totalBeams;
        }
    }
}
