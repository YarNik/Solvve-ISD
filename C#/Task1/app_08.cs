using System;

namespace ConsoleApp8
{
    class Program
    {
        static void Main(string[] args)
        {
            int num;
            int sum = 0;
            bool isGood = false;
            do
            {
                Console.Write("Сделайте вашу ставку (грн.): ");
                string input = Console.ReadLine();
                isGood = int.TryParse(input, out num);
                if (isGood)
                {
                    sum = int.Parse(input);
                    if (sum < 0) isGood = false;
                }
                else { isGood = false; }
            } while (!isGood);

            Random rand = new Random();
            int number = rand.Next(12);
            if (number <= 5) Console.Write($"Выпало {number}, вы проиграли {sum}грн. ");
            if (number > 5 & number <= 8) Console.Write($"Выпало {number}, вы получаете свои {sum}грн. обратно");
            if (number > 8 & number < 12) Console.Write($"Выпало {number}, вы выиграли {sum}грн. ");
            if (number == 12) Console.Write($"Выпало {number}, вы выиграли {sum*10}грн. ");

            Console.ReadLine();
        }
    }
}
