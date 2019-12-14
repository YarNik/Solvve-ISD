using System;

namespace ConsoleApp11
{
    class Program
    {
        static void Main(string[] args)
        {

            int num;
            bool isGood = false;
            int number = 1;
            Random rand = new Random();
            int uknown = rand.Next(146);
            
            do
            {
                Console.Write("Угадайте число от 1 до 146 : ");
                string input = Console.ReadLine();
                isGood = int.TryParse(input, out num);
                if (isGood)
                {
                    number = int.Parse(input);
                }
            } while (isGood == false);


            do
            {
                if (number < uknown)
                {
                    do
                    {
                        Console.WriteLine($"Число больше чем {number}. Следующая попытка: ");
                        string input = Console.ReadLine();
                        isGood = int.TryParse(input, out num);
                        if (isGood)
                        {
                            number = int.Parse(input);
                        }
                    } while (isGood == false);
                }

                if (number > uknown)
                {
                    do
                    {
                        Console.WriteLine($"Число меньше чем {number}. Следующая попытка: ");
                        string input = Console.ReadLine();
                        isGood = int.TryParse(input, out num);
                        if (isGood)
                        {
                            number = int.Parse(input);
                        }
                    } while (isGood == false);
                }

                if (number == uknown) { Console.WriteLine($"Вы угадали, задуманное число было {number}."); break; }

            } while (number != uknown);

           Console.ReadLine();

        }
    }
}
