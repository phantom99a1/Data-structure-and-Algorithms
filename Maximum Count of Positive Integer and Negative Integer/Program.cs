namespace Maximum_Count_of_Positive_Integer_and_Negative_Integer
{
    /*Given an array nums sorted in non-decreasing order, return the maximum between the number of 
     positive integers and the number of negative integers.
    In other words, if the number of positive integers in nums is pos and the number of negative integers is neg, 
    then return the maximum of pos and neg. Note that 0 is neither positive nor negative.
    
     Constraint:
    1 <= nums.length <= 2000
    -2000 <= nums[i] <= 2000
    nums is sorted in a non-decreasing order.
     */
    class Program
    {
        static void Main()
        {
            var nums = new List<int>();
            Console.WriteLine("Enter integers (-2000 to 2000) separated by space (Press Enter when done):");

            while (true)
            {
                try
                {
                    string input = Console.ReadLine() ?? "";
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        throw new Exception("Input cannot be empty. Please enter valid integers.");
                    }

                    string[] inputs = input.Split(' ');

                    foreach (string s in inputs)
                    {
                        if (int.TryParse(s, out int num))
                        {
                            if (num < -2000 || num > 2000)
                            {
                                throw new Exception($"Number {num} is out of range. Valid range is -2000 to 2000.");
                            }
                            nums.Add(num);
                        }
                        else
                        {
                            throw new Exception($"'{s}' is not a valid integer.");
                        }
                    }

                    // Check the length constraint
                    if (nums.Count < 1 || nums.Count > 2000)
                    {
                        throw new Exception($"The total number of integers ({nums.Count}) is out of range. Must be between 1 and 2000.");
                    }

                    break; // Exit the loop when input is valid
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    Console.WriteLine("Please re-enter the integers.");
                    nums.Clear(); // Clear the list to retry
                }
            }

            // Sort the list in non-decreasing order (though input is expected to be already sorted)
            nums.Sort();

            // Calculate positive and negative counts
            int positiveCount = 0, negativeCount = 0;
            foreach (int num in nums)
            {
                if (num > 0)
                    positiveCount++;
                else if (num < 0)
                    negativeCount++;
            }

            // Output the results
            Console.WriteLine($"Maximum Count of Positive Integers: {positiveCount}");
            Console.WriteLine($"Maximum Count of Negative Integers: {negativeCount}");
            Console.ReadKey();
        }
    }

}
