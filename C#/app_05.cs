using System;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            int num;
            bool isGood = false;
            int day = 1;
            do
            {
                Console.Write("Введите число от 1 до 7: ");
                string input = Console.ReadLine();
                isGood = int.TryParse(input, out num);
                if (isGood)
                {
                    day = int.Parse(input);
                    if (day < 1 | day > 7) isGood = false;
                }
            } while (isGood == false);  

            if (day == 1) Console.Write("Понедельник");
            if (day == 2) Console.Write("Вторник");
            if (day == 3) Console.Write("Среда");
            if (day == 4) Console.Write("Четверг");
            if (day == 5) Console.Write("Пятница");
            if (day == 6) Console.Write("Суббота");
            if (day == 7) Console.Write("Воскресенье");

            Console.ReadLine();
        }
    }
}
