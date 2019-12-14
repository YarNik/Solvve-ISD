using System;

namespace ConsoleApp7
{
    class Program
    {
        static void Main(string[] args)
        {
            int num;
            int number = 1;
            bool isGood = false;
            do
            {
                Console.Write("Введите натуральное число: ");
                string input = Console.ReadLine();
                isGood = int.TryParse(input, out num);
                if (isGood) 
                { 
                    number = int.Parse(input);
                    if (number < 0) isGood = false;
                }
                else { isGood = false; }                
            } while (!isGood);

            bool simple = true;            
            if (number % 2 == 0) simple = false;
            for (int i = 3; i <= Convert.ToInt32(Math.Sqrt(number)); i = i + 2)
            {
                double rest = number % i;
                if (rest == 0) { simple = false; break; }
            }

            if (!simple) { Console.WriteLine($"{number} - не является простым числом "); }
            else { Console.WriteLine($"{number} - простое число"); }

            Console.ReadLine();
        }
    }
}
