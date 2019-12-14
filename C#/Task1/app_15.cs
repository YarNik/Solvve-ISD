using System;

namespace ConsoleApp15
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i <= 32;) 
            {
                Console.WriteLine($"Гусей: {i}, кроликов{(64-i*2)/4}");
                i = i + 2;
            }
            Console.ReadLine();
        }
    }
}
