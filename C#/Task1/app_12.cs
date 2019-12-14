using System;

namespace ConsoleApp12
{
    class Program
    {
        static void Main(string[] args)
        {
            int num;
            int number = 0;
            bool isGood;
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

            double root = Math.Floor(Math.Sqrt(number));
            Console.WriteLine($"Квадраты натуральных чисел, не превышающие {number}:");
            for (int i = 1; i <= root; i++)
            {
                Console.Write($"{i*i} ");
            }

            Console.ReadLine();
        }
    }
}
