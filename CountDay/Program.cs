using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CountDay
{    
    public class CountDay
    {        
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
                Console.WriteLine("Hãy nhập vào ngày bắt đầu: ");
                string startDayString = Console.ReadLine() ?? "";
                if (string.IsNullOrEmpty(startDayString))
                {
                    Console.WriteLine("Ngày bắt đầu không được để trống!");
                    Console.ReadKey();
                    return;
                }
                Console.WriteLine("Hãy nhập vào ngày kết thúc: ");
                string endDayString = Console.ReadLine() ?? "";
                if (string.IsNullOrEmpty(endDayString))
                {
                    Console.WriteLine("Ngày kết thúc không được để trống!");
                    Console.ReadKey(true);
                    return;
                }
                if(DateTime.Parse(startDayString) > DateTime.Parse(endDayString))
                {
                    Console.WriteLine("Ngày bắt đầu không được lớn hơn ngày kết thúc");
                    Console.ReadKey(true);
                    return;
                }
                var result = CountDay.CountDaysBetweenTwoDate(startDayString, endDayString);
                Console.WriteLine($"Khoảng cách giữa hai ngày là: {result.Days} ngày");
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
