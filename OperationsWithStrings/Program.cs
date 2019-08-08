using System;
using System.Collections.Generic;

namespace OperationsWithStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            //// 1. Get the second greatest element out of an array 
            //var secondMax = GetSecondMax();
            //Console.WriteLine(secondMax);
            //Console.WriteLine("--------------------------------------------");

            //// 2. Fill a collection with random numbers from n to m without repetitions
            //var n = 6;
            //var m = 15;
            //FillWithRandomNumbers(n, m);
            //Console.WriteLine("----------------------------------------------");

            //// 3. Implement a method that accepts a sorted collection and an element which entries are to be found
            //Console.WriteLine("реализовать метод, который принимает в качестве параметров – " +
            //    "коллекцию отсортированных целочисленных значений и элемент, который необходимо найти," +
            //    " метод должен вернуть количество вхождений данного элемента ");

            //int[] arr2 = { 1, 2, 4, 4, 5, 5, 5, 5, 5, 6, 7, 8, 9 };

            //Console.WriteLine(GetNumberOfEntries(arr2, 5));
            //Console.WriteLine("----------------------------------------------");

            //// 4. Infinite string search
            //Console.WriteLine(InfiniteStringSearch.GetNumberOfEntries("abcaadefg", 15, 'a'));

            ////
            //var isUnique = ArraysAndStringsTasks.AreAllCharactersUnique("string");
            //var isAPermutation = ArraysAndStringsTasks.IsAPermutation("string", "stgigr");
            //var url = ArraysAndStringsTasks.URLify("Mr John Smith    ".ToCharArray());
            //var url1 = ArraysAndStringsTasks.URLify("Mr John Smith and what is your name?              ".ToCharArray());
            //var isOneAway = ArraysAndStringsTasks.IsOneAway("vale", "vle");
            //var isOneAway1 = ArraysAndStringsTasks.IsOneAway("dfewsfsdfeswfs", "dfewsdfeswfs");
            //var isOneAway2 = ArraysAndStringsTasks.IsOneAway("pales", "pale");
            //var isOneAway3 = ArraysAndStringsTasks.IsOneAway("pale", "bale");
            //var isOneAway4 = ArraysAndStringsTasks.IsOneAway("pale", "bake");

            //var twoSum = Easy.TwoSum(new int[] { 2, 7, 11, 15 }, 17);
            //var twoSum2 = Easy.TwoSum(new int[] { 2, 5, 5, 11 }, 10);
            //var newInt0 = Easy.ReversedInteger(123);
            //var newInt1 = Easy.ReversedInteger(1534236469);
            //var newInt2 = Easy.ReversedInteger(-2147483648);
            //var newInt3 = Easy.IsIntegerPalindrome(1223);
            //var newInt4 = Easy.IsIntegerPalindrome(1221);
            var lcp = Easy.GetLongestCommonPrefix(new string[] { "leets", "leetcode", "leet", "leed" });
            //var compressedString = ArraysAndStringsTasks.CompressString("aabcccccaaa");
            //var compressedString1 = ArraysAndStringsTasks.CompressString("abca");
            var p = Hard.ProductArray(new int[] { 1, 2, 3, 4, 5 });
            var p1 = Hard.ProductArray(new int[] { 3, 2, 1 });
            ArraysAndStringsTasks.RotateMatrix(new int[][]
            {
                new int[] {1, 2, 3, 4},
                new int[] {5, 6, 7, 8},
                new int[] {9, 10, 11, 12},
                new int[] {13, 14, 15, 16}
            });

           var zeroMatrix = ArraysAndStringsTasks.ZeroMatrix(
                new int[,]
                {
                    { 1, 2, 3, 4 },
                    { 5, 6, 7, 8 },
                    { 9, 0, 11, 12 }
                },
                3, 4);
            
            //incorrect
            var firstMissingInteger = Hard.FirstMissingPositiveInteger(new int[] { 3, 4, -1, 1 });
            var firstMissingInteger1 = Hard.FirstMissingPositiveInteger(new int[] { -1, -1, -1, -1 });
            var firstMissingInteger2 = Hard.FirstMissingPositiveInteger(new int[] { 1, 2, 3 });
            var firstMissingInteger3 = Hard.FirstMissingPositiveInteger(new int[] { 0, 0, 0, 0 });
            var firstMissingInteger4 = Hard.FirstMissingPositiveInteger(new int[] { -5, -9, 4, 1 });

            var validParentheses = Easy.AreParenthesesValid("({[]})");
            var validParentheses1 = Easy.AreParenthesesValid("[[]");

            var countAndSay = Easy.CountAndSay(4);
            var removeElement = Easy.RemoveElement(new int[] {3, 2, 2, 3, 3, 2}, 3);

            var isSubstring = ArraysAndStringsTasks.IsSubstring("waterwall", "wallwater");
            var repeatedSubstringPattern = Easy.RepeatedSubstringPattern("abcdr");

            Easy.MergeSortedArrays(new int[] {1, 2, 3, 0, 0, 0}, 3, new int[] {2, 5, 6}, 3);
            Easy.MajorityElement(new int[] {2, 2, 1, 1, 1, 2, 2});

            var list = new LinkedListsTasks.MyLinkedList(1, 2, 3, 4, 4, 6, 7, 8, 4, 10);
            LinkedListsTasks.RemoveDuplicates(list);
            list.Print();
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
            //int[] arr0 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
            //int[] arr0 = { 1, 2, 3, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 8, 9, 10, 11, 12, 13 };
            //int[] arr0 = { 5, 5, 5, 5, 5, 5, 5, 5 };

            //var leftBoundary = FindLeftWithBinarySearch(collection, element);
            //var rightBoundary = FindRightWithBinarySearch(collection, element);

            var leftBoundary = FindWithBinarySearch(collection, element, isSearchingForRight: false);
            var rightBoundary = FindWithBinarySearch(collection, element, isSearchingForRight: true);

            return rightBoundary - leftBoundary + 1;
        }

        private static int FindWithBinarySearch(int[] arr, int search, bool isSearchingForRight)
        {
            bool isSearchingForLeft = !isSearchingForRight;
            int left = 0;
            int right = arr.Length - 1;
            while (left <= right)
            {
                var mid = left + (right - left) / 2;

                if (search == arr[mid])
                {
                    if (isSearchingForLeft && (mid == 0 || arr[mid - 1] < search)
                        || isSearchingForRight && (mid == arr.Length - 1 || arr[mid + 1] > search))
                    {
                        return mid;
                    }
                }

                if (isSearchingForLeft && search <= arr[mid]
                    || isSearchingForRight && search < arr[mid])
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return -1;
        }

        private static int FindLeftWithBinarySearch(int[] arr, int search)
        {
            int left = 0;
            int right = arr.Length - 1;
            while (left <= right)
            {
                var mid = left + (right - left) / 2;
                if ((mid == 0 || arr[mid - 1] < search)
                    && search == arr[mid])
                {
                    return mid;
                }
                if (search <= arr[mid])
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return -1;
        }

        private static int FindRightWithBinarySearch(int[] arr, int search)
        {
            int left = 0;
            int right = arr.Length - 1;
            while (left <= right)
            {
                var mid = left + (right - left) / 2;
                if ((mid == arr.Length - 1 || arr[mid + 1] > search)
                    && search == arr[mid])
                {
                    return mid;
                }
                if (search < arr[mid])
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return -1;
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
