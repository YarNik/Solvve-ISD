using System;

namespace ConsoleApp1
{
    
    class Program
    {
        class MyClass<T>
        {
            public static T FactoryMethod<T>() where T : new()
            {
                return new T();
            }
        }
        class Test
        {
            public int Id { get; set; }
        }
        static void Main(string[] args)
        {            
            int x = MyClass<int>.FactoryMethod<int>();
            Test test = MyClass<Test>.FactoryMethod<Test>();
            test.Id = 254;
            Console.WriteLine(x);
            Console.WriteLine(test.Id);
            Console.ReadLine();
        }
    }
}
