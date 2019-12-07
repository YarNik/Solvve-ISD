using System;

namespace ConsoleApp16
{
    class Program
    {
        static void Main(string[] args)
        {
            string password;
            do
            {
                Console.Write("Введите пароль: ");
                password = Console.ReadLine();
                if (password == "root") { Console.WriteLine("Правильный пароль"); break; }
                else { Console.WriteLine("Неверный пароль"); }
            } while (true);

            Console.ReadLine();
        }
    }
}
