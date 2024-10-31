using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CountDay
{    
    public class CountDay
    {
        //Count number of days between Two date with format yyyy/MM/dd
        public static TimeSpan CountDaysBetweenTwoDate(string startDate, string endDate)
        {
            try
            {
                var startDay = DateTime.ParseExact(startDate, "yyyy/MM/dd", null);
                var endDay = DateTime.ParseExact(endDate, "yyyy/MM/dd", null);
                var differences = endDay.Subtract(startDay);
                return differences;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.OutputEncoding = Encoding.UTF8;
                Console.WriteLine("Please enter the start date: ");
                string startDayString = Console.ReadLine() ?? "";
                if (string.IsNullOrEmpty(startDayString))
                {
                    Console.WriteLine("The start date isn't empty!");
                    Console.ReadKey();
                    return;
                }
                Console.WriteLine("Please enter the end date: ");
                string endDayString = Console.ReadLine() ?? "";
                if (string.IsNullOrEmpty(endDayString))
                {
                    Console.WriteLine("The end date isn't empty!");
                    Console.ReadKey(true);
                    return;
                }
                if(DateTime.Parse(startDayString) > DateTime.Parse(endDayString))
                {
                    Console.WriteLine("The start date isn't greater than the end date!");
                    Console.ReadKey(true);
                    return;
                }
                var result = CountDay.CountDaysBetweenTwoDate(startDayString, endDayString);
                Console.WriteLine($"The differences between two dates is: {result.Days} days");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }            

        }
    }
}
