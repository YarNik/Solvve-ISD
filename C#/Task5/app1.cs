using System;

namespace ConsoleApp1
{
    class Program
    {
        struct Notebook
        {
            public string model;
            public string manufacturer;
            public int price;
            public Notebook(string model, string manufacturer, int price)
            {
                this.model = model;
                this.manufacturer = manufacturer;
                this.price = price;
            }
            public void DisplayInfo()
            {
                Console.WriteLine($"Model: {model}, manufacturer: {manufacturer}, price: {price}.");
            }

        }
        static void Main(string[] args)
        {
            Notebook note = new Notebook("ZX", "Atary", 550);
            note.DisplayInfo();
            Console.ReadLine();
        }
    }
}
