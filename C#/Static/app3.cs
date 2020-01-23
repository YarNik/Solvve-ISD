using System;

namespace ConsoleApp3
{
    public static class ArraySorting
    {
        public static int[] Sorting(this int[] arr)
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

        public static int[] SortingIncrease(this int[] arr, bool increase)
        {
            if (increase) return arr.Sorting();
            else { 
                Array.Reverse(arr.Sorting());
                return arr;
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 12, 32, 31, 510, 18, 44, 5 };
            array.SortingIncrease(true);
            for (int i = 0; i < array.Length; i++) { Console.WriteLine(array[i]); }
            array.SortingIncrease(false);
            for (int i = 0; i < array.Length; i++) { Console.WriteLine(array[i]); }

            Console.ReadLine();

        }
    }
}