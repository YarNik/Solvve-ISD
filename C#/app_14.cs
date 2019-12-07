using System;

namespace ConsoleApp14
{
    class Program
    {
        static void Main(string[] args)
        {
            double sum = 0;
            for (int i = 1; i <= 5;)
            {
                Random rand = new Random();
                sum = sum + rand.Next(100);
                i++;
            }
            double middle = sum / 5;

            Console.Write($"Среднее арифметическое 5 случайных чисел: {middle}");
            Console.ReadLine();

        }
    }
}
