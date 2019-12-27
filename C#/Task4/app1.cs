using System;

namespace ConsoleApp1
{
    abstract class AbstractHandler
    {
        public abstract void Open();
        public abstract void Create();
        public abstract void Change();
        public abstract void Save();
    }

    class XMLHandler : AbstractHandler
    {
        public override void Change()
        {
            Console.WriteLine("XML-документ изменен.");
        }
        public override void Create()
        {
            Console.WriteLine("Документ создан в формате XML.");
        }
        public override void Open()
        {
            Console.WriteLine("XML-документ открыт.");
        }
        public override void Save()
        {
            Console.WriteLine("Документ сохранен в формате XML.");
        }
    }

    class TXTHandler : AbstractHandler
    {
        public override void Change()
        {
            Console.WriteLine("TXT-документ изменен.");
        }
        public override void Create()
        {
            Console.WriteLine("Документ создан в формате TXT.");
        }
        public override void Open()
        {
            Console.WriteLine("TXT-документ открыт.");
        }
        public override void Save()
        {
            Console.WriteLine("Документ сохранен в формате TXT.");
        }
    }

    class DOCHandler : AbstractHandler
    {
        public override void Change()
        {
            Console.WriteLine("DOC-документ изменен.");
        }
        public override void Create()
        {
            Console.WriteLine("Документ создан в формате DOC.");
        }
        public override void Open()
        {
            Console.WriteLine("DOC-документ открыт.");
        }
        public override void Save()
        {
            Console.WriteLine("Документ сохранен в формате DOC.");
        }
    }

    class Program
    {
        static AbstractHandler Definition(string name)
        {
            if (name == "xml") return new XMLHandler();
            if (name == "txt") return new TXTHandler();
            if (name == "doc") return new DOCHandler();
            throw new Exception("Invalid format of document.");
        }
        static void AllMethods(AbstractHandler document) 
        {
            document.Create();
            document.Open();
            document.Change();
            document.Save();
        }
        static void Main(string[] args)
        {
            AbstractHandler doc = new DOCHandler();
            AllMethods(doc);
            doc.Save();
            TXTHandler txt = new TXTHandler();
            AllMethods(txt);                        
            try
            {
                AbstractHandler xml = Definition("xml");
                AllMethods(xml);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка: {e.Message}");
            }
            Console.ReadLine();
        }
    }
}
