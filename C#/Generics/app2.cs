using System;

namespace ConsoleApp2
{
    class MyList<T>
    {
        public T[] array;
        public int Length
        {
            get { return array.Length; }
        } 

        public MyList() { array = new T[0]; }
        public MyList(T[] arr) { array = arr; }
        public void Add(T item)
        {
            T[] newArray = new T[array.Length + 1];
            for (int i = 0; i < array.Length; i++)
                { newArray[i] = array[i]; }
            newArray[newArray.Length - 1] = item;
            array = newArray;
        }
        public T this[int index]
        {
           get { return array[index]; }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> myList = new MyList<int>();
            myList.Add(23);
            Console.WriteLine($" Добавили {myList.array[0]}");
            myList.Add(45);
            Console.WriteLine($" Добавили {myList.array[1]}");
            Console.WriteLine($" Длина myList - {myList.Length}");
            Console.WriteLine($" Первый элемент - {myList[0]}");

            string[] arrayString = {"John", "Ivan", "Olga", "Elena"};
            MyList<string> myListString = new MyList<string>(arrayString);
            Console.WriteLine($" Первый элемент - {myListString[0]}");
            myListString.Add("Kisa");
            Console.WriteLine($" Последний элемент - {myListString[myListString.Length - 1]}");
            Console.ReadLine();
        }
    }
}
