using System;

namespace ConsoleApp3
{
    class MyClass
    {
        public string change;
    }

    struct MyStruct
    {
        public string change;
    }
    class Program
    {
        static void ClassTaker(MyClass myClass)
        {
            myClass.change = "изменено";
        }
        static void StruktTaker(MyStruct myStruct)
        {
            myStruct.change = "изменено";
        }
        static void Main(string[] args)
        {
            MyClass myClass = new MyClass();
            MyStruct myStruct = new MyStruct();
            myClass.change = "не изменено";
            myStruct.change = "не изменено";
            ClassTaker(myClass);
            StruktTaker(myStruct);
            MyClass myClass2 = new MyClass();
            Console.WriteLine($"myClass.change: {myClass.change}");     // "изменено"
            Console.WriteLine($"myStruct.change: {myStruct.change}");   // "не изменено"      
            Console.ReadLine();
        }
    }
}

        /*  Метод StruktTaker не отработал (по моему мнению) потому что при передаче параметра 
         *  myStruct в метод StruktTaker он передается как локальная копия переменной myStruct
         *  (т.к. MyStruct это структура).
         *  Метод StruktTaker отработал потому что передача параметра myClass прошла как передача
         *  ссылки на  myClass (т.к. MyClass это класс).   */
