using System;

namespace ConsoleApp3
{
    class MyDictionary<TKey, TValue>
    {
        TKey[] Keys = new TKey[0];
        TValue[] Values = new TValue[0];
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
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyDictionary<string, string> myDict1 = new MyDictionary<string, string>();
            myDict1.Add("first", "Volodimir");
            Console.WriteLine($" Добавили: key - 'first', value - {myDict1["first"]}.");
            myDict1.Add("second", "Stepan");
            Console.WriteLine($" Добавили: key - 'second', value - {myDict1["second"]}.");
            Console.WriteLine($"Значение элемента по индексу 'second' - {myDict1["second"]}.");
            Console.WriteLine($" Общее количество элементов myDict1 - {myDict1.Length}");

            Console.ReadLine();
        }
    }
}
