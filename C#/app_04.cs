using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            string number;
            do
            {
                Console.Write("Введите 0 или 1: ");
                number = Console.ReadLine();
                if (number == "0") break;
                if (number == "1") break;
            } while (true);

            Console.Write(number == "1" ? "Хорошо" : "Плохо");

            Console.ReadLine();
        }
    }
}
