using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            int num;
            Console.Write("Введите номер месяца (1-12): ");
            string input = Console.ReadLine();
            bool isNum = int.TryParse(input, out num);
            if (!isNum) { Console.Write("На этой планете такого месяца нет"); }
            else
            {
                int number = int.Parse(input);
                if (number == 1 | number == 2 | number == 12) Console.Write("Зима");
                if (number >= 3 & number <= 5) Console.Write("Весна");
                if (number >= 6 & number <= 8) Console.Write("Лето");
                if (number >= 9 & number <= 11) Console.Write("Осень");
                if (number >= 13 | number <= 0) Console.Write("На этой планете такого месяца нет");
            }

            Console.ReadLine();
        }
    }
}
