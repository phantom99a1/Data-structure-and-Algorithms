using System.Text;

namespace Sexagenary_Cycle_Calendar
{
    /*Input: Given a positive integer year, return the Sexagenary Cycle Year.
          
     Constraint:
    0 < t <= 100; 
    0 < year and year is a positive integer
     */
    
    public class Program
    {
        private const int minValue = 0;
        private const int maxValue = 100;
        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            int testCases = GetPositiveInteger("Enter the number of test cases: ");
            for (int i = 0; i < testCases; i++)
            {
                Console.WriteLine($"Processing test case #{i + 1}");
                Console.Write("Enter the Gregorian year: ");
                int year;
                while (!int.TryParse(Console.ReadLine(), out year) || year <= minValue)
                {
                    Console.Write("Please enter a valid year: ");
                }

                var heavenlyStemsDictionary = new Dictionary<string, string>
                {
                    {"Giáp", "Jia"}, {"Ất", "Yi"}, {"Bính", "Bing"}, {"Đinh", "Ding"},
                    {"Mậu", "Wu"}, {"Kỷ", "Ji"}, {"Canh", "Geng"}, {"Tân", "Xin"},
                    {"Nhâm", "Ren"}, {"Quý", "Gui"}
                };

                var earthlyBranchesDictionary = new Dictionary<string, string>
                {
                    {"Tý", "Rat"}, {"Sửu", "Ox"},
                    {"Dần", "Tiger"}, {"Mão", "Cat"}, {"Thìn", "Dragon"}, {"Tỵ", "Snake"},
                    {"Ngọ", "Horse"}, {"Mùi", "Goat"}, {"Thân", "Monkey"}, {"Dậu", "Rooster"},
                    {"Tuất", "Dog"}, {"Hợi", "Pig"}
                };

                string[] heavenlyStems = ["Giáp", "Ất", "Bính", "Đinh", "Mậu", "Kỷ", "Canh", "Tân", "Nhâm", "Quý"];
                string[] earthlyBranches = ["Tý", "Sửu", "Dần", "Mão", "Thìn", "Tỵ", "Ngọ", "Mùi", "Thân", "Dậu", "Tuất", "Hợi"];

                int stemIndex = (year + 6) % 10;
                int branchIndex = (year + 8) % 12;

                string can = heavenlyStems[stemIndex];
                string chi = earthlyBranches[branchIndex];

                string canChiVietnamese = can + " " + chi;
                string canChiEnglish = heavenlyStemsDictionary[can] + " " + earthlyBranchesDictionary[chi];

                Console.WriteLine($"Year {year} is the year of {canChiEnglish} ({canChiVietnamese})");
            }
            
            Console.ReadKey();
        }

        private static int GetPositiveInteger(string prompt)
        {
            int value;
            Console.Write(prompt);
            while (!int.TryParse(Console.ReadLine(), out value) || value <= minValue || value > maxValue)
            {
                Console.Write("Invalid input. Please enter a positive integer: ");
            }
            return value;
        }
    }
}
