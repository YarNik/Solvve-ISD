using System;

namespace ConsoleApp8
{
    class Program
    {
        class Invoice
        {
            readonly int account;
            readonly string customer, provider;
            string article = "";
            int quantity = 0;
            double price = 0;
            double totalPrice = 0;
            double totalPriceNDS = 0;

            public Invoice(int account, string customer, string provider)
            {
                this.account = account;
                this.customer = customer;
                this.provider = provider;
            }

            public string Article { set { article = value; } }
            public int Quantity { set { quantity = value; } }

            public void Calculator(double price) 
            {
                this.price = price;
                this.totalPrice = Math.Round((price * this.quantity),2);
                this.totalPriceNDS = Math.Round((this.totalPrice * 1.2),2);
            }

            public void Show()
            {
                Console.WriteLine($"Сумма заказа: {totalPrice} грн., с НДС: {totalPriceNDS} грн.");
                Console.ReadLine();
            }

        }
        static void Main(string[] args)
        {
            Invoice order = new Invoice(1234, "'Рога и копыта'", "'Геркулес'");
            order.Quantity = 50;
            order.Article = "Рога";
            order.Calculator(99);
            order.Show();

        }
    }
}
