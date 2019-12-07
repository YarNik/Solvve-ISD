using System;

namespace ConsoleApp10
{
    class Program
    {
        static void Main(string[] args)
        {
            int num;
            bool isGood = false;
            int number = 1;
            do
            {
                Console.Write("Введите число от 1 до 20: ");
                string input = Console.ReadLine();
                isGood = int.TryParse(input, out num);
                if (isGood)
                {
                    number = int.Parse(input);
                    if (number < 1 | number > 20) isGood = false;
                }
            } while (isGood == false);

            for (int i = 1; i <= 20; i++) 
            {
                Console.WriteLine($"{i} * {number} = {i*number}");
            }

            Console.ReadLine();
        }
    }
}
