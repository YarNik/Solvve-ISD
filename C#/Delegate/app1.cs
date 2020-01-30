using System;

namespace ConsoleApp1
{
    delegate double Average(int x, int y, int z);
    class Program
    {
        static void Main(string[] args)
        {
            Average average = delegate (int x, int y, int z)
                {
                    return (double)(x + y + z) / 3;
                };
            double result = Math.Round(average(4, 4, 5), 2);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
