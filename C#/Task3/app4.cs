using System;

namespace ConsoleApp4
{
    class Program
    {
        class DoсumentWorker 
        {
            public void OpenDocument() { Console.WriteLine("Документ открыт."); }
            public virtual void EditDocument() { Console.WriteLine("Редактирование документа доступно в версии Про."); }
            public virtual void SaveDocument() { Console.WriteLine("Сохранение документа доступно в версии Про."); }
            public void Show()
            {
                OpenDocument();
                EditDocument();
                SaveDocument();                
            }
        }

        class ProDocumentWorker : DoсumentWorker 
        {
            public override void EditDocument() { Console.WriteLine("Документ отредактирован."); }
            public override void SaveDocument() { Console.WriteLine("Документ сохранен в старом формате, сохранение в остальных форматах доступно в версии Эксперт."); }
        }

        class ExpertDocumentWorker : ProDocumentWorker
        {           
            public override void SaveDocument() { Console.WriteLine("Документ сохранен в новом формате."); }
        }
        static void Main(string[] args)
        {      
            string key;
            do
            {
                Console.Write("Введите ключ доступа pro(1111) или exp(2222): ");
                key = Console.ReadLine();
                if (key == "1111") break;
                if (key == "2222") break;
                if (key == "") break;
            } while (true);
            if (key == "") 
            {
                DoсumentWorker dw = new DoсumentWorker();
                dw.Show();
            }
            if (key == "1111") 
            { 
                DoсumentWorker pdw = new ProDocumentWorker();
                pdw.Show();
            }
            if (key == "2222")
            {
                DoсumentWorker edw = new ExpertDocumentWorker();
                edw.Show();
            }

            Console.ReadLine();
        }
    }
}
