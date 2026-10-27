namespace Create_Grid_With_Exactly_One_Path
{
    public class Solution
    {
        public string[] CreateGrid(int m, int n)
        {
            var rs = new string[m];
            var firstRow = new char[n];
            for (int i = 0; i < firstRow.Length; i++)
            {
                firstRow[i] = '.';
            }
            rs[0] = new string(firstRow);
            for (int i = 1; i < rs.Length; i++)
            {
                var row = new char[n];
                for (int j = 0; j < row.Length - 1; j++)
                {
                    row[j] = '#';
                }
                row[row.Length - 1] = '.';
                rs[i] = new string(row);
            }
            return rs;
        }
    }
}
