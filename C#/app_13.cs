using System;

namespace ConsoleApp13
{
    class Program
    {
        static void Main(string[] args)
        {
            double sum = 0;
            int num;
            int number = 0;
            bool isGood;
            Console.WriteLine("Введите 5 натуральных чисел: ");
            for (int i = 1; i <= 5;)
            {
                do
                {
                    Console.Write($" {i} число: ");
                    string input = Console.ReadLine();
                    isGood = int.TryParse(input, out num);
                    if (isGood)
                    {
                        number = int.Parse(input);
                        if (number < 0) isGood = false;
                        if (number > 0) { sum = sum + number; i++; }
                    }
                    else { isGood = false; }
                } while (!isGood);
            }
            double middle = sum / 5;
            
            Console.Write($"Среднее арифметическое этих чисел: {middle}");
            Console.ReadLine();

        }
    }
}
