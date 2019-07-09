using System;
using System.Linq;
using System.Collections.Generic;

namespace OperationsWithStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Get the second greatest element out of an array 
            var secondMax = GetSecondMax();
            Console.WriteLine(secondMax);
            Console.WriteLine("--------------------------------------------");

            // 2. Fill a collection with random numbers from n to m without repetitions
            var n = 6;
            var m = 15;
            FillWithRandomNumbers(n, m);
            Console.WriteLine("----------------------------------------------");

            // 3. Implement a method that accepts a sorted collection and an element which entries are to be found
            Console.WriteLine("реализовать метод, который принимает в качестве параметров – " +
                "коллекцию отсортированных целочисленных значений и элемент, который необходимо найти," +
                " метод должен вернуть количество вхождений данного элемента ");

            int[] arr2 = { 1, 2, 3, 4, 5, 5, 5, 5, 5, 6, 7, 8, 9 };

            Console.WriteLine(GetNumberOfEntries(arr2, 5));
            Console.WriteLine("----------------------------------------------");

            // 4. Infinite string search
            Console.WriteLine(InfiniteStringSearch.GetNumberOfEntries("abcaadefg", 15, 'a'));
            Console.ReadKey();
        }

        private static int GetSecondMax()
        {
            int[] arr = { 12, 35, 1, 10, 34, 1 };

            var max = -1;

            var secondMax = -1;
            max = secondMax = arr[0];

            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] > max)
                {
                    secondMax = max;
                    max = arr[i];
                }
                else if (arr[i] > secondMax)
                {
                    secondMax = arr[i];
                }
            }

            return secondMax;
        }

        public static int GetNumberOfEntries(int[] collection, int element)
        {
            var count = 0;

            for (int i = 0; i < collection.Length - 1; i++)
            {
                if (collection[i] == element)
                {
                    count++;
                    for (int j = i + 1; j < collection.Length - 1; j++)
                    {
                        if (collection[j] == element)
                        {
                            count++;
                        }
                        else
                        {
                            return count;
                        }
                    }
                }
            }

            return count;
        }

        private static void FillWithRandomNumbers(int n, int m)
        {
            var size = m - n;

            Random rnd = new Random();
            var list = new HashSet<int>();

            while (list.Count < size)
            {
                list.Add(rnd.Next(n, m));
            }

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
