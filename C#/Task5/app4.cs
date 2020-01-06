using System;

namespace ConsoleApp4
{
    class Program
    {
        static int DaysToDate(DateTime date)
        {
            DateTime now = DateTime.Now;
            TimeSpan result = date.Subtract(now);
            return result.Days;
        }
        static int InputData(string inscription, int start, int end)
        {
            int num;
            bool isGood = false;
            int result = 0;
            do
            {
                Console.Write(inscription);
                string input = Console.ReadLine();
                isGood = int.TryParse(input, out num);
                if (isGood)
                {
                    result = int.Parse(input);
                    if (result < start | result > end) isGood = false;
                }
            } while (isGood == false);
            return result;
        }
        static void Main(string[] args)
        {          
            DateTime now = DateTime.Now;
            int year = now.Year;
            int month = InputData("Введите месяц вашего рождения (1-12): ", 1, 12);
            int day = InputData("Введите число вашего рождения (1-31): ", 1, 31);
                   
            DateTime birthday = new DateTime(year, month, day);
            int daysToBirthday = DaysToDate(birthday);                                    
            if (daysToBirthday < 0)
            {
                year += 1;
                birthday = new DateTime(year, month, day);
                daysToBirthday = DaysToDate(birthday);
            }
            Console.WriteLine($"До дня рождения осталось {daysToBirthday} дн.");
            Console.ReadLine();
        }
    }
}
