using System;

namespace ConsoleApp5
{   enum Colour
    {
        Black = 0,
        Blue = 9,
        Cyan = 11,
        DarkBlue = 1,
        DarkCyan = 3,
        DarkGray = 8,
        DarkGreen = 2,
        DarkMagenta = 5,
        DarkRed = 4,
        DarkYellow = 6,
        Gray = 7,
        Green = 10,
        Magenta = 13,
        Red = 12,
        White = 15,
        Yellow = 14
    }
    class Program
    {
        static int InputData(string inscription, int start, int end)
        {
            int num;
            bool isGood = false;
            int result = 0;
            do
            {
                Console.Write(inscription);
                string input = Console.ReadLine();
                isGood = int.TryParse(input, out num);
                if (isGood)
                {
                    result = int.Parse(input);
                    if (result < start | result > end) isGood = false;
                }
            } while (isGood == false);
            return result;
        }

        public static void Print(string stroka, int color)
        {           
            Console.ForegroundColor = (System.ConsoleColor)color;
            Console.WriteLine(stroka);            
            Console.ResetColor();
        }
        static void Main(string[] args)
        {
            Console.Write("Enter text: ");
            string stroka = Console.ReadLine();
            
            for (int i = 0; i <= 15; i++)
            {
                Colour col = (Colour)i;
                Console.WriteLine($"{i}. {col}");
            }
            int color = InputData("Select number of color: ", 0, 15);
            Console.Clear();
            Print(stroka, color);      
            Console.ReadLine();
        }
    }
}
