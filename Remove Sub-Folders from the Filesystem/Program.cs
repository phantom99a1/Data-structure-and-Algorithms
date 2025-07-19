namespace Remove_Sub_Folders_from_the_Filesystem
{
    public class Solution
    {
        public IList<string> RemoveSubfolders(string[] folder)
        {
            Array.Sort(folder);
            List<string> result = new List<string> { folder[0] };

            for (int i = 1; i < folder.Length; i++)
            {
                string prev = result[result.Count - 1];
                if (!folder[i].StartsWith(prev + "/"))
                {
                    result.Add(folder[i]);
                }
            }

            return result;
        }
    }
}
