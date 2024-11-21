namespace Intersection_of_Multiple_Arrays
{
    public class Solution
    {
        public IList<int> Intersection(int[][] arrays)
        {
            var freq = new Dictionary<int, int>();
            int numArrays = arrays.Length; foreach (var arr in arrays)
            {
                foreach (var num in arr)
                {
                    if (freq.ContainsKey(num))
                    {
                        freq[num]++;
                    }
                    else
                    {
                        freq[num] = 1;
                    }
                }
            }
            var result = new List<int>();
            foreach (var pair in freq)
            {
                if (pair.Value == numArrays)
                {
                    result.Add(pair.Key);
                }
            }
            result.Sort();
            return result;
        }
    }

    public class Program
    {
        public static void Main()
        {
            Solution solution = new Solution(); 
            int numArrays; 
            do 
            { 
                Console.Write("Enter the number of arrays: "); 
            } 
            while (!int.TryParse(Console.ReadLine(), out numArrays) || numArrays <= 0); 
            int[][] arrays = new int[numArrays][]; 
            for (int i = 0; i < numArrays; i++) 
            { 
                string input; 
                do 
                { 
                    Console.Write($"Enter elements of array {i + 1} separated by space: "); 
                    input = Console.ReadLine(); 
                } 
                while (string.IsNullOrWhiteSpace(input)); 
                arrays[i] = input.Split(' ').Select(int.Parse).ToArray(); }
            IList<int> result = solution.Intersection(arrays); 
            Console.WriteLine("Intersection of arrays: [" + string.Join(", ", result) + "]");
            Console.ReadKey();
        }
    }
}
        
