using System;

namespace ConsoleApp2
{
    static class Sorting
    {
        public static int[] Sort(int[] arr)
        {
            int temp;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
            return arr;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 12, 32, 31, 510, 18, 44, 5 };
            int[] sortedArray = Sorting.Sort(array);
            for (int i = 0; i < sortedArray.Length; i++) { Console.WriteLine(sortedArray[i]); }

            Console.ReadLine();

        }
    }
}
