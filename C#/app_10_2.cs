using System;

namespace ConsoleApp10_2
{
    class Program
    {
        static void Main(string[] args)
        {
            double num;
            bool isGood = false;
            double number = 1;
            do
            {
                Console.Write("Введите число : ");
                string input = Console.ReadLine();
                isGood = double.TryParse(input, out num);
                if (isGood)
                {
                    number = double.Parse(input);
                    if (number == 0) isGood = false;
                }
            } while (isGood == false);
                                   
            int digitCount = (int)Math.Log10(Math.Abs(number)) + 1;
            Console.Write($"В числе {number} - {digitCount} разрядов");

            Console.ReadLine();
        }
    }
}
