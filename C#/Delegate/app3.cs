using System;

namespace ConsoleApp3
{
    delegate int GetRandom();
    delegate double GetAverage(params GetRandom[] randoms);
    class Program
    {
        static int Random()
        {
            Random rnd = new Random();
            int value = rnd.Next(0, 100);
            return value;
        }
        static void Main(string[] args)
        {
            int lengthRandoms = 10;
            GetRandom[] randoms = new GetRandom[lengthRandoms];
            for (int i = 0; i < randoms.Length; i++)
            {
                GetRandom random = Random;
                randoms[i] = random;               
            }

            GetAverage average = delegate(GetRandom[] arrayRandoms)
            {
                double result = 0;
                foreach (GetRandom i in arrayRandoms)
                {
                    result += i();
                    Console.WriteLine(i());
                }
                return result / arrayRandoms.Length;
            };

            double resultAverage = average(randoms);
            Console.WriteLine($"Среднее арифметическое: {resultAverage}");
            
            Console.ReadLine();

        }
    }
}
