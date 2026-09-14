namespace Rectangle_Overlap
{
    public class Solution
    {

        public bool IsRectangleOverlap(int[] rec1, int[] rec2)
        {

            bool flag = true;

            if (
                rec2[0] >= rec1[2] ||  // rec2 is to the right
                rec1[3] <= rec2[1] ||  // rec1 is below
                rec2[2] <= rec1[0] ||  // rec2 is to the left
                rec2[3] <= rec1[1]     // rec2 is below
            )
            {
                flag = false;
            }

            return flag;
        }
    }
}
