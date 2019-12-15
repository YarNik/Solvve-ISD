using System;

namespace ConsoleApp1
{
    class Program
    {
        class Printer 
        {
            public Printer() { }
            public virtual void Print(string value)
            {
                Console.WriteLine(value);
                Console.ReadLine();
            }
        }

        class PrinterYellow : Printer
        {           
            public override void Print(string value) 
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(value);
                Console.ResetColor();
                Console.ReadLine();
            }
        }

        class PrinterGreen : Printer
        {           
            public override void Print(string value)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(value);
                Console.ResetColor();
                Console.ReadLine();
            }
        }
        static void Main(string[] args)
        {
            Printer pBase = new Printer();
            pBase.Print("Print Printer");
            PrinterYellow pYellow = new PrinterYellow();
            pYellow.Print("Print PrinterYellow");
            PrinterGreen pGreen = new PrinterGreen();
            pGreen.Print("Print PrintGreen");

            Printer pBase2 = pGreen;
            pBase2.Print("Print Printer2");

            Printer pBase3 = new PrinterYellow();
            PrinterYellow pYellow2 = (PrinterYellow)pBase3;
            pYellow2.Print("Print PrinterYellow2");

            Printer pBase4 = new PrinterGreen();
            ((PrinterGreen)pBase4).Print("Print PrintGreen2");

        }
    }
}
