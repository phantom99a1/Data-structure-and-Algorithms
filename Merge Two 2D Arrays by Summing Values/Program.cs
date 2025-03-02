namespace Merge_Two_2D_Arrays_by_Summing_Values
{
    /*You are given two 2D integer arrays nums1 and nums2.
    nums1[i] = [idi, vali] indicate that the number with the id idi has a value equal to vali.
    nums2[i] = [idi, vali] indicate that the number with the id idi has a value equal to vali.
    Each array contains unique ids and is sorted in ascending order by id.
    Merge the two arrays into one array that is sorted in ascending order by id, respecting the following conditions:
    Only ids that appear in at least one of the two arrays should be included in the resulting array.
    Each id should be included only once and its value should be the sum of the values of this id in the two arrays. 
    If the id does not exist in one of the two arrays, then assume its value in that array to be 0.
    Return the resulting array. The returned array must be sorted in ascending order by id.
    
    Constraint:
    1 <= nums1.length, nums2.length <= 200
    nums1[i].length == nums2[j].length == 2
    1 <= idi, vali <= 1000
    Both arrays contain unique ids.
    Both arrays are in strictly ascending order by id.
     */
   
    public class Solution
    {
        public int[][] MergeArrays(int[][] nums1, int[][] nums2)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();

            // Merge first array
            foreach (var pair in nums1)
            {
                if (!map.ContainsKey(pair[0]))
                    map[pair[0]] = 0;
                map[pair[0]] += pair[1];
            }

            // Merge second array
            foreach (var pair in nums2)
            {
                if (!map.ContainsKey(pair[0]))
                    map[pair[0]] = 0;
                map[pair[0]] += pair[1];
            }

            // Convert the map to a sorted list
            List<int[]> mergedList = map.OrderBy(pair => pair.Key)
                                        .Select(pair => new int[] { pair.Key, pair.Value })
                                        .ToList();
            return mergedList.ToArray();
        }

        public static List<int[]> InputArrayFromKeyboard(string promptMessage)
        {
            List<int[]> nums = [];
            string input;

            while (true)
            {
                Console.Write(promptMessage);
                input = Console.ReadLine() ?? "";
                if (input.Equals("done", StringComparison.CurrentCultureIgnoreCase)) break;

                string[] values = input.Split(' ');
                if (values.Length != 2 || !int.TryParse(values[0], out int id) || !int.TryParse(values[1], out int val) ||
                    id < 1 || id > 1000 || val < 1 || val > 1000)
                {
                    Console.WriteLine("Invalid input. Each line must contain exactly two integers (id and value) between 1 and 1000.");
                    continue;
                }

                nums.Add([id, val]);
                if (nums.Count >= 200)
                {
                    Console.WriteLine("Reached the maximum length of 200.");
                    break;
                }
            }

            return nums;
        }

        public static void Main()
        {
            List<int[]> nums1 = InputArrayFromKeyboard("Enter the first array (enter 'done' to finish): ");
            List<int[]> nums2 = InputArrayFromKeyboard("Enter the second array (enter 'done' to finish): ");

            var solution = new Solution();
            var result = solution.MergeArrays([.. nums1], [.. nums2]);

            Console.Write("[");
            for (int i = 0; i < result.Length; i++)
            {
                Console.Write($"[{result[i][0]},{result[i][1]}]");
                if (i != result.Length - 1)
                    Console.Write(",");
            }
            Console.WriteLine("]");
            Console.ReadKey();
        }
    }
}
