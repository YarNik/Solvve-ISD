using System;

namespace ConsoleApp6
{
    class Dictionary<TKey, TValue>
    {         
        TKey[] Keys = new TKey[0];
        TValue[] Values = new TValue[0];
        public TKey[] keys
        {
            get { return Keys; }
        }
        public TValue[] values
        {
            get { return Values; }
        }
        public int Length
        {
            get { return Keys.Length; }
        }       

        public void Add(TKey key, TValue value)
        {
            TKey[] newKeys = new TKey[Keys.Length + 1];
            TValue[] newValues = new TValue[Values.Length + 1];
            for (int i = 0; i < Keys.Length; i++)
            {
                newKeys[i] = Keys[i];
                newValues[i] = Values[i];
            }
            newKeys[newKeys.Length - 1] = key;
            newValues[newValues.Length - 1] = value;
            Keys = newKeys;
            Values = newValues;
        }
        public TValue this[TKey key]
        {
            get
            {
                TValue result = default(TValue);
                for (int i = 0; i < Keys.Length; i++)
                {
                    if (Equals(Keys[i], key)) { result = Values[i]; break; }
                }
                return result;
            }
            set
            {
                for (int i = 0; i < Keys.Length; i++)
                {
                    if (Equals(Keys[i], key)) { Values[i] = value; break; }
                }
            }
        }
        public void Remove(TKey key)
        {
            int index;
            for (int i = 0; i < Keys.Length; i++)
            {
                if (Equals(Keys[i], key))
                {
                    index = i;
                    TKey[] newKeys = new TKey[Keys.Length - 1];
                    TValue[] newValues = new TValue[Values.Length - 1];
                    for (int j = 0; j < index; j++)
                    {
                        newKeys[j] = Keys[j];
                        newValues[j] = Values[j];
                    }
                    for (int j = index; j < newKeys.Length; j++)
                    {
                        newKeys[j] = Keys[j + 1];
                        newValues[j] = Values[j + 1];
                    }
                    Keys = newKeys;
                    Values = newValues;
                    break;
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> myDict = new Dictionary<int, string>();
            myDict.Add(1, "first");
            Console.WriteLine($" Добавили: key - '1', value - {myDict[1]}.");
            myDict.Add(2, "second");
            Console.WriteLine($" Добавили: key - '2', value - {myDict[2]}.");
            Console.WriteLine($"Значение элемента по индексу '2' - {myDict[2]}.");
            myDict[2] = "changed second";
            Console.WriteLine($"Значение элемента по индексу(изменение объекта) '2' - {myDict[2]}.");
            myDict.Add(3, "last");
            Console.WriteLine($" Общее количество элементов myDict - {myDict.Length}");
                // перебор ключей
            Console.WriteLine(" Перебор ключей");
            foreach (var key in myDict.keys)  { Console.WriteLine(key); }
                // перебор значений
            Console.WriteLine(" Перебор значений");
            foreach (var value in myDict.values) { Console.WriteLine(value); }            
            myDict.Remove(2);
            Console.WriteLine(" Перебор значений после удаления элемента с ключом '2'");
            foreach (var value in myDict.values) { Console.WriteLine(value); }
            Console.ReadLine();
        }
    }
}
