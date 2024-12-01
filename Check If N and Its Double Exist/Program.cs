namespace Check_If_N_and_Its_Double_Exist
{
    /*Given an array arr of integers, check if there exist two indices i and j such that :

        i != j
        0 <= i, j < arr.length
        arr[i] == 2 * arr[j]*/    
    public class Solution
    {
        public static bool CheckIfExist(int[] arr)
        {
            var set = new HashSet<int>();
            foreach (var num in arr)
            {
                if (set.Contains(2 * num) || (num % 2 == 0 && set.Contains(num / 2)))
                {
                    return true;
                }
                set.Add(num);
            }
            return false;
        }

        public static void Main()
        {
            Console.WriteLine("Enter the numbers separated by spaces:");
            var input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Input cannot be empty. Please enter a list of integers.");
                return;
            }

            var arr = input.Split(' ').Select(x => {
                bool success = int.TryParse(x, out int num);
                return (success, num);
            }).ToArray();

            if (arr.Any(x => !x.success))
            {
                Console.WriteLine("Invalid input. Please enter a list of integers.");
            }
            else
            {
                var result = CheckIfExist(arr.Select(x => x.num).ToArray());
                Console.WriteLine(result ? "Yes, there exists N and its double." : "No, there does not exist N and its double.");
                Console.ReadKey();
            }
        }
    }

}
