using System;

namespace ConsoleApp7
{
    
    class ArrayList 
    {
        object[] array = new object[0];
        public object[] getArray
        {
            get { return array; }
        }
        public int Count
        {
            get { return array.Length; }
        }
        
        public void Add(object item)
        {
            object[] newArray = new object[array.Length + 1];
            for (int i = 0; i < array.Length; i++)
                { newArray[i] = array[i]; }
            newArray[newArray.Length - 1] = item;
            array = newArray;
        }
        public void AddRange(object[] items)
        {
            object[] newArray = new object[array.Length + items.Length];
            for (int i = 0; i < array.Length; i++)
                { newArray[i] = array[i]; }
            for (int j = 0; j < items.Length; j++)
            {
                newArray[array.Length + j] = items[j];
            }
            array = newArray;
        }
        public void Clear()
        {
            array = new object[0];
        }
        public bool Contains(object value)
        {
            bool result = false;
            for (int i = 0; i < array.Length; i++)
            {
                if (Equals(array[i], value)) { result = true; break; }
            }
            return result;
        }
        public void CopyTo(ref object[] toArray)
        {
            object[] tempToArray = new object[array.Length];
            for (int i = 0; i < array.Length; i++)
                { tempToArray[i] = array[i]; }
            toArray = tempToArray;
        }
        public ArrayList GetRange(int index, int count)
        {
            ArrayList partOfArray = new ArrayList();
            for (int i = index; i < index + count; i++)
                { partOfArray.Add(array[i]); }
            return partOfArray;
        }
        public int IndexOf(object value)
        {
            int result = -1;
            for (int i = 0; i < array.Length; i++)
            {
                if (Equals(array[i], value)) { result = i; break; }
            }
            return result;
        }
        public void Insert(int index, object value)
        {
            object[] newArray = new object[array.Length + 1];
            for (int i = 0; i < index; i++)
                { newArray[i] = array[i]; }
            newArray[index] = value;
            for (int i = index + 1; i < newArray.Length; i++)
                { newArray[i] = array[i - 1]; }
            array = newArray;
        }
        public void InsertRange(int index, object[] items)
        {
            object[] newArray = new object[array.Length + items.Length];
            for (int i = 0; i < index; i++)
                { newArray[i] = array[i]; }
            for (int j = 0; j < items.Length; j++)
                { newArray[index + j] = items[j]; }
            for (int k = index + items.Length; k < items.Length + array.Length; k++)
                { newArray[k] = array[k - items.Length]; }
            array = newArray;
        }
        public int LastIndexOf(object value)
        {
            int result = -1;
            for (int i = array.Length - 1; i >= 0; i--)
            {
                if (Equals(array[i], value)) { result = i; break; }
            }
            return result;
        }
        public void Remove(object value)
        {
            int index = -1;
            for (int i = 0; i < array.Length; i++)
            {
                if (Equals(array[i], value)) { index = i; break; }
            }
            if (index != -1) RemoveAt(index);
        }
        public void RemoveAt(int index)
        {
            object[] newArray = new object[array.Length - 1];
            for (int i = 0; i < index; i++)
            { newArray[i] = array[i]; }
            for (int j = index; j < newArray.Length; j++)
            { newArray[j] = array[j + 1]; }
            array = newArray;
        }
        public void RemoveRange(int index, int count)
        {
            object[] newArray = new object[array.Length - count];
            for (int i = 0; i < index; i++)
                { newArray[i] = array[i]; }           
            for (int k = index; k < newArray.Length; k++)
                { newArray[k] = array[k + count]; }
            array = newArray;
        }
        public void Reverse()
        {
            object[] newArray = new object[array.Length];
            for (int i = 0; i < array.Length; i++)
                { newArray[array.Length - 1 - i] = array[i]; }
            array = newArray;
        }        
    }
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList myList = new ArrayList();
            myList.Add(897);
            myList.Add("first");
            myList.AddRange(new string[] { "Hello", "world" });
            myList.Add("first");
            //myList.Clear();
            for (int i = 0; i < myList.Count; i++) Console.WriteLine(myList.getArray[i]);
            Console.WriteLine($" Есть ли элемент '897'? {myList.Contains(897)}");
            object[] target = new object[0];
            myList.CopyTo(ref target);
            Console.WriteLine(" Копия myList:");
            for (int i = 0; i < target.Length; i++) Console.WriteLine(target[i]);
            ArrayList PartOfMyList = myList.GetRange(1, 2);
            Console.WriteLine(" Часть 'myList' начиная с элемента 1, длиной 2: ");
            for (int i = 0; i < PartOfMyList.Count; i++) Console.WriteLine(PartOfMyList.getArray[i]);
            Console.WriteLine($" Индекс элемента 'Hello': {myList.IndexOf("Hello")}.");
            myList.Insert(3, "Bye");
            Console.WriteLine(" myList после вставки элемента 'Bye': ");
            for (int i = 0; i < myList.Count; i++) Console.WriteLine(myList.getArray[i]);
            myList.InsertRange(3, new string[] { "Hi", "Venera" });
            Console.WriteLine(" myList после вставки массива ['Hi', 'Venera']:");
            for (int i = 0; i < myList.Count; i++) Console.WriteLine(myList.getArray[i]);
            Console.WriteLine($" Последнее вхождение элемента 'first': {myList.LastIndexOf("first")}");
            myList.Remove("Hi");
            Console.WriteLine(" myList после удаления элемента 'Hi': ");
            for (int i = 0; i < myList.Count; i++) Console.WriteLine(myList.getArray[i]);
            myList.RemoveAt(3);
            Console.WriteLine(" myList после удаления элемента с индексом '3':");
            for (int i = 0; i < myList.Count; i++) Console.WriteLine(myList.getArray[i]);
            myList.RemoveRange(1, 2);
            Console.WriteLine(" myList после удаления двух элементов, начиная с индексa '1':");
            for (int i = 0; i < myList.Count; i++) Console.WriteLine(myList.getArray[i]);
            myList.Add(false);
            myList.Add(1111);
            myList.Add("last element");
            Console.WriteLine(" Добавили в myList 3 элемента:");
            for (int i = 0; i < myList.Count; i++) Console.WriteLine(myList.getArray[i]);
            myList.Reverse();
            Console.WriteLine(" myList перевернули: ");
            for (int i = 0; i < myList.Count; i++) Console.WriteLine(myList.getArray[i]);
            
            Console.ReadLine();
        }
    }
}
