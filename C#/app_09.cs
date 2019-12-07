using System;

namespace ConsoleApp9
{
    class Program
    {
        static void Main(string[] args)
        {
            double num;
            double sum = 0;
            bool isGood = false;
            do
            {
                Console.Write("Введите сумму: ");
                string input = Console.ReadLine();
                isGood = double.TryParse(input, out num);
                if (isGood)
                {
                    sum = double.Parse(input);
                    if (sum < 0) isGood = false;
                }
                else { isGood = false; }
            } while (!isGood);

            string currency;
            double rate_usUA = 25;
            double rate_euUA = 27;
            double rate_euUS = 1.08;
            do
            {
                Console.Write("В какой валюте ваша сумма (евро, доллар, гривна) ");
                currency = Console.ReadLine();
                if (currency == "евро") break;
                if (currency == "доллар") break;
                if (currency == "гривна") break;
            } while (true);

            if (currency == "гривна")
            {
                Console.WriteLine
                    ($"{sum} грн. это {Math.Round(sum/ rate_usUA,2)} долл. или {Math.Round(sum / rate_euUA,2)} евро");
            }
            if (currency == "доллар")
            {
                Console.WriteLine
                    ($"{sum} долл. это {Math.Round(sum * rate_usUA,2)} грн. или {Math.Round(sum / rate_euUS,2)} евро");
            }
            if (currency == "евро")
            {
                Console.WriteLine
                    ($"{sum} евро. это {Math.Round(sum * rate_euUA,2)} грн. или {Math.Round(sum * rate_euUS,2)} долл.");
            }

            Console.ReadLine();
        }
    }
}
