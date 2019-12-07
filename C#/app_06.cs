using System;

namespace ConsoleApp6
{
    class Program
    {
        static void Main(string[] args)
        {
            int num;
            int distance = 0;
            int time = 0;
            bool isGood = false;
            do
            {
                Console.Write("Введите количество км: ");
                string input = Console.ReadLine();
                isGood = int.TryParse(input, out num);
                if (isGood) 
                {
                    distance = int.Parse(input);
                    if (distance <= 0) isGood = false;
                }
                else { isGood = false; }
            } while (!isGood);

            isGood = false;
            do
            {
                Console.Write("Введите количество минут простоя:");
                string input = Console.ReadLine();
                isGood = int.TryParse(input, out num);
                if (isGood)
                {
                    time = int.Parse(input);
                    if (time < 0) isGood = false;
                }
                else { isGood = false; }
            } while (!isGood);

            int sum;
            if (distance <= 5) { sum = 20 + time; }
            else { sum = 20 + (distance - 5) * 3 + time; }

            Console.WriteLine($"Сумма к оплате {sum} грн. ");
            Console.ReadLine();
        }
    }
}
