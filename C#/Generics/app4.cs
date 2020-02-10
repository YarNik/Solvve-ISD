using System;

namespace ConsoleApp4
{
     class MyList<T>
    {
        T[] array;  
        public T[] Array
        {
            get { return array;  }
        }
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

    static class MyListExtension
    {
        public static T[] GetArray<T>(this MyList<T> list)
        {
            return list.Array;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrayInt = { 25, 45, 78, 87, 12 };
            MyList<int> myList = new MyList<int>(arrayInt);
            myList.Add(23);           
            myList.Add(67);
            int[] getMyList = myList.GetArray();
            for (int i = 0; i < getMyList.Length; i++)
                {  Console.WriteLine(getMyList[i]); }
            
            Console.ReadLine();
        }
    }
}
