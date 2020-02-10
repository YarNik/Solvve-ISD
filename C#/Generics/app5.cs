using System;

namespace ConsoleApp5
{
    class CarCollection<T>
    {
        T[,] array;
        public int Length
        {
            get { return array.Length / 2; }
        }

        public CarCollection() { array = new T[0,0]; }
        public CarCollection(T[,] arr) { array = arr; }

        public void Add(T model, T year)
        {
            T[,] newArray = new T[array.Length/2 + 1, 2];
            for (int i = 0; i < array.Length / 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    newArray[i,j] = array[i,j];
                }
            }            
            newArray[newArray.Length/2 - 1, 0] = model;
            newArray[newArray.Length / 2 - 1, 1] = year;
            array = newArray;
        }
        public T[] this[int index]
        {
            get { return new T[2] { array[index, 0], array[index, 1] }; }
        }
        public void Remove()
        {
            array = new T[0, 0];
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[,] garage = { {"Mersedes SL", "2015"}, {"Mc Laren", "2019"}, {"Ferrari", "2001"}, {"BMW X5", "2018"} };
            CarCollection<string> cars = new CarCollection<string>(garage);
            cars.Add("VAZ2109", "2005");
            cars.Add("Kamaz", "2003");
            Console.WriteLine($" {cars[2][0]} - {cars[2][1]}");
            Console.WriteLine($" Всего машин в гараже - {cars.Length}.");
            cars.Remove();
            Console.WriteLine($" Всего машин в гараже - {cars.Length}.");
            Console.ReadLine();
        }
    }
}
