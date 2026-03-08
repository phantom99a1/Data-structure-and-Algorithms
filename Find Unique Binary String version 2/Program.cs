namespace Find_Unique_Binary_String_version_2
{
    public class Solution
    {
        public string FindDifferentBinaryString(string[] nums)
        {
            return string.Create(nums.Length, nums, static (span, arr) => {
                for (int i = 0; i < span.Length; i++)
                {
                    span[i] = (char)(arr[i][i] ^ 1);
                }
            });
        }
    }
}
