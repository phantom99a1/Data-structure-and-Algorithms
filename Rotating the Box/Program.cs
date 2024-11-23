namespace Rotating_the_Box
{
    public class Solution
    {
        public static char[][] RotateTheBox(char[][] box)
        {
            if (box == null || box[0].Length == 0)
                return new char[0][];

            int m = box.Length, n = box[0].Length;
            for (int i = 0; i < m; i++)
            {
                int empty = n - 1;
                for (int j = n - 1; j >= 0; j--)
                {
                    if (box[i][j] == '*')
                        empty = j - 1;
                    else if (box[i][j] == '#')
                    {
                        // swap the stone and empty 
                        // In case stone and empty are the same cell, we should set '.' first, then set '#'
                        box[i][j] = '.';
                        box[i][empty] = '#';
                        empty--;
                    }
                }
            }

            char[][] res = new char[n][];
            for (int i = 0; i < n; i++)
                res[i] = new char[m];

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    res[j][m - 1 - i] = box[i][j];
                }
            }

            return res;
        }

        public static void Main()
        {
            int numRows; 
            do 
            { 
                Console.Write("Enter the number of rows: "); 
            } 
            while (!int.TryParse(Console.ReadLine(), out numRows) || numRows <= 0); 
            char[][] box = new char[numRows][]; 
            for (int i = 0; i < numRows; i++) 
            { 
                string input; 
                do 
                { 
                    Console.Write($"Enter elements of row {i + 1}: "); 
                    input = Console.ReadLine() ?? ""; 
                } 
                while (string.IsNullOrWhiteSpace(input)); 
                box[i] = input.ToCharArray(); 
            }
            char[][] rotatedBox = RotateTheBox(box); 
            Console.WriteLine("Rotated Box:"); 
            foreach (var row in rotatedBox) 
            { 
                Console.WriteLine(new string(row)); 
            }
            Console.ReadKey();
        }
    }
}
