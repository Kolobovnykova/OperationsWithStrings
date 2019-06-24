using System;
using System.Linq;
using System.Collections.Generic;

namespace OperationsWithStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get the second greatest element out of an array 
            int[] arr = { 12, 35, 1, 10, 34, 1 };

            var max = -1;

            //Array.Sort(arr);
            //Array.Reverse(arr);
            //max = arr[1];

            //for (int i = 0; i < arr.Length - 1; i++)
            //{
            //    if (max < arr[i])
            //    {
            //        max = arr[i];
            //    }               
            //}
            //var max2 = -1;
            //for (int i = 0; i < arr.Length - 1; i++)
            //{
            //    if (max2 < arr[i] && arr[i] < max)
            //    {
            //        max2 = arr[i];
            //    }
            //}

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
            Console.WriteLine(secondMax);
            Console.WriteLine("--------------------------------------------");

            // Fill a collection with random numbers from n to m without repetitions
            var n = 6;
            var m = 15;
            var size = m - n;

            var list = new HashSet<int>();
            while (list.Count < size)
            {
                list.Add(GetRandomNumber(n, m));
            }

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("----------------------------------------------");
            // Implement a method that accepts a sorted collection and an element which entries are to be found
            Console.WriteLine("реализовать метод, который принимает в качестве параметров – " +
                "коллекцию отсортированных целочисленных значений и элемент, который необходимо найти," +
                " метод должен вернуть количество вхождений данного элемента ");

            int[] arr2 = { 1, 2, 3, 4, 5, 5, 5, 5, 5, 6, 7, 8, 9 };

            Console.WriteLine(GetNumberOfEntries(arr2, 5));
            Console.WriteLine("----------------------------------------------");

            // Infinite string search
            Console.WriteLine(InfiniteStringSearch.GetNumberOfEntries("abcaadefg", 15, 'a'));
            Console.ReadKey();
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

        public static int GetRandomNumber(int n, int m)
        {
            Random rnd = new Random();
            return rnd.Next(n, m);
        }   
    }
}
