using System;

namespace ConsoleApp6
{
    class Program
    {
        class Converter 
        {
            double usd, eur, rub;            
            public Converter (double usd, double eur, double rub) 
            {
                this.usd = usd;
                this.eur = eur;
                this.rub = rub;
            }

            public double UahToUsd(double sumUah) { return sumUah / usd ; }
            public double UahToEur(double sumUah) { return sumUah / eur; }
            public double UahToRub(double sumUah) { return sumUah / rub; }
            public double UsdToUah(double sumUsd) { return usd * sumUsd; }
            public double EurToUah(double sumEur) { return eur * sumEur; }
            public double RubToUah(double sumRub) { return usd * sumRub; }
            
        }
        static void Main(string[] args)
        {
            Converter rate = new Converter(25.0, 27.0, 0.4);

            string currency;
            double resultSum = 0;
            string currencyTarget;
            do
            {
                Console.Write("Введите валюту (USD, EUR, RUB, UAH): ");
                currency = Console.ReadLine();
                if (currency == "USD") break;
                if (currency == "EUR") break;
                if (currency == "RUB") break;
                if (currency == "UAH") break;
            } while (true);

            int num;
            int amounts = 0;
            bool isGood;
            do
            {
                Console.Write("Введите сумму: ");
                string input = Console.ReadLine();
                isGood = int.TryParse(input, out num);
                if (isGood)
                {
                    amounts = int.Parse(input);
                    if (amounts < 0) isGood = false;
                }
                else { isGood = false; }
            } while (!isGood);

            if (currency != "UAH") 
            {
                if (currency == "USD") { resultSum = rate.UsdToUah(amounts); }
                if (currency == "EUR") { resultSum = rate.EurToUah(amounts); }
                if (currency == "RUB") { resultSum = rate.RubToUah(amounts); }
                Console.WriteLine($"{amounts} {currency} это {Math.Round(resultSum,2)} грн.");
                Console.ReadLine();
            }

            if (currency == "UAH") 
            {                
                do
                {
                    Console.Write("На какую валюту меняем? (USD, EUR, RUB): ");
                    currencyTarget = Console.ReadLine();
                    if (currencyTarget == "USD") break;
                    if (currencyTarget == "EUR") break;
                    if (currencyTarget == "RUB") break;                    
                } while (true);
                if (currencyTarget == "USD") { resultSum = rate.UahToUsd(amounts); }
                if (currencyTarget == "EUR") { resultSum = rate.UahToEur(amounts); }
                if (currencyTarget == "RUB") { resultSum = rate.UahToRub(amounts); }
                Console.WriteLine($"{amounts}грн. это {Math.Round(resultSum, 2)} {currencyTarget}");
                Console.ReadLine();
            }

        }
    }
}
