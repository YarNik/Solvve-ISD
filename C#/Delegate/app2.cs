using System;

namespace ConsoleApp2
{
    delegate double Operation(double x, double y);
    class Program
    {        
        static void Main(string[] args)
        {
            Operation Add = (x, y) => x + y;
            Operation Sub = (x, y) => x - y;
            Operation Mul = (x, y) => x * y;
            Operation Div = (x, y) => y != 0 ? x / y : x < 0 ? -1.7e308 : 1.7e308;

            bool isGood = false;
            double num, number1 = 0, number2 = 0;
            do
            {
                Console.Write("Введите первое число: ");
                string input = Console.ReadLine();
                isGood = double.TryParse(input, out num);
                if (isGood)
                {
                    number1 = double.Parse(input);                    
                }
                else { isGood = false; }
            } while (!isGood);
            isGood = false;
            do
            {
                Console.Write("Введите второе число: ");
                string input = Console.ReadLine();
                isGood = double.TryParse(input, out num);
                if (isGood)
                {
                    number2 = double.Parse(input);
                }
                else { isGood = false; }
            } while (!isGood);

            string operation;
            do
            {
                Console.WriteLine("Выберите операцию ('+', '-', '*', '/')");               
                operation = Console.ReadLine();
                if (operation == "+") break;
                if (operation == "-") break;
                if (operation == "*") break;
                if (operation == "/") break;
            } while (true);

            void Calculate()
                {
                    double result = 0;
                    if (operation == "+") result = Add(number1, number2);
                    if (operation == "-") result = Sub(number1, number2);
                    if (operation == "*") result = Mul(number1, number2);
                    if (operation == "/") result = Div(number1, number2);
                    result = Math.Round(result, 3);
                    Console.WriteLine($"{number1} {operation} {number2} = {result}");
                }

            Calculate();           
            Console.ReadLine();
        }
    }
}
