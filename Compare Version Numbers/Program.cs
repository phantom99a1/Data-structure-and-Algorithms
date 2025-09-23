namespace Compare_Version_Numbers
{
    public class Solution
    {
        public int CompareVersion(string version1, string version2)
        {
            var v1 = version1.Split('.');
            var v2 = version2.Split('.');
            int len = Math.Max(v1.Length, v2.Length);

            for (int i = 0; i < len; i++)
            {
                int num1 = i < v1.Length ? int.Parse(v1[i]) : 0;
                int num2 = i < v2.Length ? int.Parse(v2[i]) : 0;

                if (num1 > num2) return 1;
                if (num1 < num2) return -1;
            }
            return 0;
        }
    }
}
