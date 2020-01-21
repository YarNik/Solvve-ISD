using System;

namespace ConsoleApp1
{
    static class Calculator 
    {
        

        public static double Calculate(string sign, double a, double b) 
        {
            double result = 0;
            switch (sign) 
            {
                case "+":
                    result = a + b;
                    break;
                case "-":
                    result = a - b;
                    break;
                case "*":
                    result = a * b;
                    break;
                case "/":
                    result = a / b;
                    break;
            }
            return Math.Round(result, 4);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
        
            Console.WriteLine($"2 + 2 = {Calculator.Calculate("+", 2, 2)}");
            Console.WriteLine($"54.2 - 24.54 = {Calculator.Calculate("-", 54.2, 24.54)}");
            Console.WriteLine($"25 * 20 = {Calculator.Calculate("*", 25, 20)}");
            Console.WriteLine($"81 / 4 = {Calculator.Calculate("/", 81, 4)}");

            Console.ReadLine();
        }
    }
}
