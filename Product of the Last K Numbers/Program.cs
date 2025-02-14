namespace Product_of_the_Last_K_Numbers
{
    /*Design an algorithm that accepts a stream of integers and retrieves the product of the last k integers of the stream.
    Implement the ProductOfNumbers class:
    ProductOfNumbers() Initializes the object with an empty stream.
    void add(int num) Appends the integer num to the stream.
    int getProduct(int k) Returns the product of the last k numbers in the current list. 
    You can assume that always the current list has at least k numbers.
    The test cases are generated so that, at any time, the product of any contiguous sequence of 
    numbers will fit into a single 32-bit integer without overflowing.
    
    Constraint:
    0 <= num <= 100
    1 <= k <= 4 * 10^4
    At most 4 * 104 calls will be made to add and getProduct.
    The product of the stream at any point in time will fit in a 32-bit integer.
     */
    using System;
    using System.Collections.Generic;

    public class ProductOfNumbers
    {
        private List<int> products;

        public ProductOfNumbers()
        {
            products = new List<int>() { 1 };
        }

        public void Add(int num)
        {
            if (num < 0 || num > 100)
            {
                Console.WriteLine("Error: num should be an integer between 0 and 100");
                return;
            }
            if (num == 0)
            {
                products = new List<int>() { 1 };
            }
            else
            {
                products.Add(products[products.Count - 1] * num);
            }
        }

        public int GetProduct(int k)
        {
            if (k < 1 || k > 40000)
            {
                Console.WriteLine("Error: k should be an integer between 1 and 40,000");
                return -1;
            }
            int n = products.Count;
            if (k >= n)
            {
                return 0;
            }
            else
            {
                return products[products.Count - 1] / products[products.Count - 1 - k];
            }
        }

        public static void Main(string[] args)
        {
            ProductOfNumbers productOfNumbers = new ProductOfNumbers();
            Console.WriteLine("Enter commands (e.g., \"add 5\" or \"getProduct 3\"). Type \"exit\" to quit.");

            while (true)
            {
                string input = Console.ReadLine();
                if (input.ToLower() == "exit")
                {
                    break;
                }
                string[] parts = input.Trim().Split(' ');
                if (parts[0] == "add")
                {
                    if (int.TryParse(parts[1], out int num))
                    {
                        productOfNumbers.Add(num);
                    }
                    else
                    {
                        Console.WriteLine("Error: num should be an integer between 0 and 100");
                    }
                }
                else if (parts[0] == "getProduct")
                {
                    if (int.TryParse(parts[1], out int k))
                    {
                        Console.WriteLine(productOfNumbers.GetProduct(k));
                    }
                    else
                    {
                        Console.WriteLine("Error: k should be an integer between 1 and 40,000");
                    }
                }
                else
                {
                    Console.WriteLine("Error: Command should be either \"add\" or \"getProduct\" followed by an integer value");
                }
            }
        }
    }
}
