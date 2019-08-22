using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OperationsWithStrings
{
    public static class Easy
    {
        // Given an array of integers, return indices of the two numbers such that they add up to a specific target.
        // You may assume that each input would have exactly one solution, and you may not use the same element twice.
        // Given nums = [2, 7, 11, 15], target = 9,
        // Because nums[0] + nums[1] = 2 + 7 = 9,
        // return [0, 1].
        public static int[] TwoSum(int[] nums, int target)
        {
            // O(n2)
            //for (int i = 0; i < nums.Length; i++)
            //{
            //    for (int j = i + 1; j < nums.Length; j++)
            //    {
            //        if (nums[i] + nums[j] == target)
            //        {
            //            return new int[] { i, j };
            //        }
            //    }
            //}

            // O(nLogN)
            // if arr is sorted find (target - x) using binary search 


            // O(n)
            var dict = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (dict.TryGetValue(nums[i], out int value))
                {
                    return new int[] { value, i };
                }

                var comp = target - nums[i];
                dict.TryAdd(comp, i);
            }

            // O(n)
            // for sorted arrays
            //var k = 0;
            //var l = nums.Length - 1;

            //while (k < l)
            //{
            //    var sum = nums[k] + nums[l];
            //    if (sum == target)
            //    {
            //        return new int[] { k, l };
            //    }
            //    if (sum > target)
            //    {
            //        l--;
            //    }
            //    else
            //    {
            //        k++;
            //    }
            //}

            throw new Exception("No pairs found");
        }

        // Given a 32-bit signed integer, reverse digits of an integer.
        // Assume we are dealing with an environment which could only store integers within the 32-bit signed integer range: [−2^31,  2^31 − 1].
        // For the purpose of this problem, assume that your function returns 0 when the reversed integer overflows.
        // Input: -123 Output: -321
        // Input: 120 Output: 21
        public static int ReversedInteger(int x)
        {
            var newInt = 0;
            //try
            //{
            //    checked
            //    {
            //        while (Math.Abs(x) >= 1)
            //        {
            //            newInt = newInt * 10 + x % 10;
            //            x = x / 10;
            //        }
            //    }                
            //}
            //catch (OverflowException)
            //{
            //    newInt = 0;
            //}

            while (x != 0)
            {
                if (newInt < int.MinValue / 10 || newInt > int.MaxValue / 10)
                    return 0;
                newInt = newInt * 10 + x % 10;
                x /= 10;
            }

            return newInt;
        }

        // Determine whether an integer is a palindrome. An integer is a palindrome when it reads the same backward as forward.
        // 121 true
        // -121 false
        // 10 false
        public static bool IsIntegerPalindrome(int x)
        {
            if (x < 0 || x % 10 == 0 && x != 0)
                return false;

            //if (x == ReversedInteger(x))
            //    return true;

            int newInt = 0;
            while (x != 0 && newInt < x)
            {
                newInt = newInt * 10 + x % 10;
                x /= 10;
            }

            return x == newInt || x == newInt / 10;
        }

        // Write a function to find the longest common prefix string amongst an array of strings.
        // If there is no common prefix, return an empty string "".
        // All given inputs are in lowercase letters a-z.
        public static string GetLongestCommonPrefix(string[] strs)
        {
            if (strs.Length == 0)
            {
                return "";
            }

            // horizontal scanning
            //var prefix = strs[0];
            //for (int i = 1; i < strs.Length; i++)
            //{
            //    while (strs[i].IndexOf(prefix) != 0)
            //    {
            //        prefix = prefix.Substring(0, prefix.Length - 1);
            //        if (string.IsNullOrEmpty(prefix))
            //        {
            //            return "";
            //        }
            //    }
            //}

            // vertical scanning
            //for (int i = 0; i < strs[0].Length; i++)
            //{
            //    char c = strs[0][i];
            //    for (int j = 0; j < strs.Length; j++)
            //    {
            //        if (i == strs[j].Length || strs[j][i] != c)
            //        {
            //            return strs[0].Substring(0, i);
            //        }
            //    }
            //}

            // divide and conquer
            // O(n * s) s - length of the strings
            var n = strs.Length;
            var prefix = GetLongestLongestCommonPrefix(strs, 0, n - 1);

            return prefix;
        }
        
        private static string GetLongestLongestCommonPrefix(string[] arr, int left, int right)
        {
            string prefix = "";
            if (left == right)
            {
                return arr[left];
            }
            else
            {
                var mid = (left + right) / 2;
                var leftWord = GetLongestLongestCommonPrefix(arr, left, mid);
                var rightWord = GetLongestLongestCommonPrefix(arr, mid + 1, right);
                prefix = CountLCP(leftWord, rightWord);
            }
            
            return prefix;
        }

        private static string CountLCP(string left, string right)
        {
            var n = Math.Min(left.Length, right.Length);
            var prefix = left.Substring(0, n);
            while (prefix != right.Substring(0, prefix.Length))
            {
                prefix = prefix.Substring(0, prefix.Length - 1);
                if (string.IsNullOrEmpty(prefix))
                {
                    return "";
                }
            }

            return prefix;
        }

        // []{}()
        public static bool AreParenthesesValid(string str)
        {
            var mapping = new Dictionary<char, char>();
            mapping.Add('}', '{');
            mapping.Add(']', '[');
            mapping.Add(')', '(');
            var stack = new Stack<char>();

            for (int i = 0; i < str.Length; i++)
            {
                if (mapping.ContainsKey(str[i]))
                {
                    char c = stack.Count > 0 ? stack.Peek() : '#';
                    if (mapping[str[i]] == c)
                    {
                        stack.Pop();
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    stack.Push(str[i]);
                }
            }

            return stack.Count == 0;
        }

        // The count-and-say sequence is the sequence of integers with the first five terms as following:
        // 1 is read off as "one 1" or 11.
        // 11 is read off as "two 1s" or 21.
        // 21 is read off as "one 2, then one 1" or 1211.
        // Given an integer n where 1 ≤ n ≤ 30, generate the nth term of the count-and-say sequence.
        public static string CountAndSay(int n)
        {
            if (n < 1)
                return "";

            var sb = new StringBuilder();
            sb.Append('1');

            for (int i = 1; i < n; i++)
            {
                sb = Count(sb);
            }

            return sb.ToString();
        }

        private static StringBuilder Count(StringBuilder str)
        {
            var c = str[0];
            var sb = new StringBuilder();
            var count = 1;

            for (int i = 1; i < str.Length; i++)
            {
                if (str[i] == c)
                {
                    count++;
                }
                else
                {
                    sb.Append(count);
                    sb.Append(c);
                    c = str[i];
                    count = 1;
                }
            }

            sb.Append(count);
            sb.Append(c);

            return sb;
        }

        public static int SearchInsertPosition(int[] nums, int target)
        {
            var right = nums.Length - 1;
            var left = 0;
            var mid = 0;

            while (left <= right)
            {
                mid = left + (right - left) / 2;
                if (nums[mid] == target)
                {
                    return mid;
                }
                else if (nums[mid] > target)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            if (nums[mid] > target)
            {
                return mid;
            }
            else
            {
                return mid + 1;
            }
        }

        // 290. Word Pattern. Given a pattern and a string str, find if str follows the same pattern.
        // Here follow means a full match, such that there is a bijection between a letter in pattern and a non-empty word in str.
        // Input: pattern = "abba", str = "dog cat cat dog"
        // Output: true
        public static bool WordPattern(string pattern, string str)
        {
            var arr = str.Split(' ');
            if (arr.Length != pattern.Length)
                return false;
            var dict = new Dictionary<char, string>();

            for (int i = 0; i < pattern.Length; i++)
            {
                if (!dict.ContainsKey(pattern[i]))
                {
                    if (dict.ContainsValue(arr[i]))
                    {
                        return false;
                    }
                    dict.Add(pattern[i], arr[i]);
                }
                else
                {
                    if (arr[i] != dict[pattern[i]])
                    {
                        return false;
                    }
                }
            }

            return true;
        }


        // 27. Given an array nums and a value val, remove all instances of that value in-place and return the new length.
        // Do not allocate extra space for another array, you must do this by modifying the input array in-place with O(1) extra memory.
        // The order of elements can be changed. It doesn't matter what you leave beyond the new length.
        public static int RemoveElement(int[] nums, int val)
        {
            if (nums.Length == 0)
                return 0;
            int i = 0;
            var n = nums.Length;

            while (i < n)
            {
                if (nums[i] == val)
                {
                    nums[i] = nums[n - 1];
                    n--;
                }
                else
                {
                    i++;
                }
            }

            return n;

            //int n = 0;
            //for (int j = 0; j < nums.Length; j++)
            //{
            //    if (nums[j] != val)
            //    {
            //        nums[n] = nums[j];
            //        n++;
            //    }
            //}

            //return n;
        }

        // 189. Rotate Array. Given an array, rotate the array to the right by k steps, where k is non-negative.
        // Input: [1,2,3,4,5,6,7] and k = 3
        // Output: [5,6,7,1,2,3,4]
        public static void RotateArray(int[] nums, int k)
        {
            // O(n) time, O(1) space
            int count = 0;
            for (int i = 0; count < nums.Length; i++)
            {
                var prev = nums[i];
                var current = i;
                do
                {
                    current = (current + k) % nums.Length;
                    var temp = nums[current];
                    nums[current] = prev;
                    prev = temp;
                    count++;
                } while (i != current);
            }
        }

        // 66. Plus One. Given a non-empty array of digits representing a non-negative integer, plus one to the integer.
        // The digits are stored such that the most significant digit is at the head of the list, and each element in the array contain a single digit.
        // You may assume the integer does not contain any leading zero, except the number 0 itself.
        // Input: [1,2,3]
        // Output: [1,2,4]
        public static int[] PlusOne(int[] arr)
        {
            var carry = true;
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                if (carry)
                {
                    if (arr[i] + 1 > 9)
                    {
                        arr[i] = 0;
                        if (i - 1 < 0)
                        {
                            var newArr = new int[arr.Length + 1];
                            newArr[0] = 1;
                            return newArr;
                        }
                    }
                    else
                    {
                        arr[i] += 1;
                        carry = false;
                    }
                }
            }

            return arr;
        }

        // 459. Repeated Substring Pattern
        // Given a non-empty string check if it can be constructed by taking a substring of it and appending
        // multiple copies of the substring together. You may assume the given string consists
        // of lowercase English letters only and its length will not exceed 10000.
        public static bool RepeatedSubstringPattern(string s)
        {
            var sb = new StringBuilder();
            var n = s.Length;

            for (int i = 2; i <= n; i++)
            {
                sb.Clear();
                if (n % i == 0)
                {
                    for (int j = 0; j < i; j++)
                    {
                        sb.Append(s.Substring(0, n / i));
                    }
                    if (s == sb.ToString())
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        // 202. Happy Number
        // Write an algorithm to determine if a number is "happy".
        // A happy number is a number defined by the following process: Starting with any positive integer,
        // replace the number by the sum of the squares of its digits, and repeat the process
        // until the number equals 1 (where it will stay), or it loops endlessly in a cycle which does not include 1.
        // Those numbers for which this process ends in 1 are happy numbers.
        public static bool IsHappy(int n)
        {
            var count = 0;
            var k = 0;

            while (count < 99)
            {
                while (n > 0)
                {
                    k = k + (int)Math.Pow(n % 10, 2);
                    n = n / 10;
                }

                if (k == 1)
                {
                    return true;
                }
                n = k;
                k = 0;
                count++;
            }

            return false;
        }

        // 88. Merge Sorted Array
        // Given two sorted integer arrays nums1 and nums2, merge nums2 into nums1 as one sorted array.
        // The number of elements initialized in nums1 and nums2 are m and n respectively.
        // You may assume that nums1 has enough space (size that is greater or equal to m + n) to hold additional elements from nums2.
        public static void MergeSortedArrays(int[] nums1, int n, int[] nums2, int m)
        {
            int k = n - 1;
            int p = m - 1;
            for (int i = n + m - 1; i >= 0; i--)
            {
                if (p < 0)
                {
                    nums1[i] = nums1[k];
                    k--;
                }
                else if (k < 0)
                {
                    nums1[i] = nums2[p];
                    p--;
                }

                if (p >= 0 && k >= 0)
                {
                    if (nums1[k] >= nums2[p])
                    {
                        nums1[i] = nums1[k];
                        k--;
                    }
                    else
                    {
                        nums1[i] = nums2[p];
                        p--;
                    }
                }
            }
        }

        // 349. Intersection of Two Arrays
        // Given two arrays, write a function to compute their intersection.
        // Input: nums1 = [1,2,2,1], nums2 = [2,2]
        // Output: [2]
        // Each element in the result must be unique.
        // The result can be in any order.
        public static int[] Intersection(int[] arr1, int[] arr2)
        {
            HashSet<int> set1 = new HashSet<int>();
            HashSet<int> set2 = new HashSet<int>();
            foreach (var i in arr1)
            {
                set1.Add(i);
            }

            foreach (var i in arr2)
            {
                set2.Add(i);
            }

            var hashSet = new HashSet<int>();
            foreach (var i in set1)
            {
                if (set2.Contains(i))
                {
                    hashSet.Add(i);
                }
            }

            return hashSet.ToArray();
        }

        // 169. Majority Element
        // Given an array of size n, find the majority element. The majority element is the element that appears more than n/2 times.
        // You may assume that the array is non-empty and the majority element always exist in the array.
        // Input: [3,2,3]
        // Output: 3
        public static int MajorityElement(int[] nums)
        {
            var n = nums.Length;
            var x = n / 2 + 1;
            var dict = new Dictionary<int, int>();
            var key = 0;

            for (int i = 0; i < n; i++)
            {
                key = nums[i];
                if (dict.ContainsKey(key))
                {
                    dict[key]++;
                    if (dict[key] == x)
                    {
                        return key;
                    }
                }
                else
                {
                    dict.Add(key, 1);
                }
            }

            return key;
        }

        // 283. Move Zeroes
        // Given an array nums, write a function to move all 0's to the end of it while maintaining the relative order of the non-zero elements.
        public static void MoveZeroes(int[] nums)
        {
            var p = 0;
            // O(n)
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    nums[p++] = nums[i];
                }
            }

            for (int i = p; i < nums.Length; i++)
            {
                nums[i] = 0;
            }
        }

        //Definition for singly-linked list.
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        // 83. Remove Duplicates from Sorted List
        // Given a sorted linked list, delete all duplicates such that each element appear only once.
        public static ListNode DeleteDuplicates(ListNode head)
        {
            ListNode node = head;
            if (head == null)
            {
                return head;
            }

            while (node.next != null)
            {
                if (node.val == node.next.val)
                {
                    node.next = node.next.next;
                }
                else
                {
                    node = node.next;
                }
            }

            return head;
        }

        // 203. Remove all elements from a linked list of integers that have value val.
        public static ListNode RemoveElementsFromLinkedList(ListNode head, int val)
        {
            ListNode temp = head, prev = null;
            while (temp != null)
            {
                if (temp.val == val)
                {
                    if (temp == head)
                    {
                        head = head.next;
                    }
                    else
                    {
                        prev.next = temp.next;
                    }
                }
                else
                {
                    prev = temp;
                }

                temp = temp.next;
            }

            return head;
        }

        // 206. Reverse Linked List. Reverse a singly linked list.
        public static ListNode ReverseList(ListNode head)
        {
            // time O(n), space O(n)
            //var nodeOrder = head;
            //ListNode nodeReverse = null;

            //while (nodeOrder != null)
            //{
            //    var temp = new ListNode(nodeOrder.val);
            //    temp.next = nodeReverse;
            //    nodeReverse = temp;
            //    nodeOrder = nodeOrder.next;
            //}

            //return nodeReverse;

            // time O(n), space O(1)
            ListNode prev = null;
            ListNode curr = head;

            while (curr != null)
            {
                var temp = curr.next;
                curr.next = prev;
                prev = curr;
                curr = temp;
            }

            return prev;
        }

        // 268. Missing Number
        // Given an array containing n distinct numbers taken from [0, 1, 2, ..., n], find the one that is missing from the array.
        public static int MissingNumber(int[] nums)
        {
            //Array.Sort(nums);

            //if (nums[nums.Length - 1] != nums.Length)
            //{
            //    return nums.Length;
            //}

            //if (nums[0] != 0)
            //{
            //    return 0;
            //}

            //for (int i = 1; i < nums.Length; i++)
            //{
            //    var expected = nums[i - 1] + 1;
            //    if (nums[i] != expected)
            //    {
            //        return expected;
            //    }
            //}

            //return -1;

            var hash = new HashSet<int>();
            foreach (var h in nums)
            {
                hash.Add(h);
            }

            var count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (!hash.Contains(count))
                {
                    return count;
                }
                count++;
            }

            return count;
        }

        public static void RotateArrayToRight(int[] arr, int k)
        {
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine();
                var current = i;
                var prev = arr[current];
                do
                {
                    current = (current + (arr.Length - k)) % arr.Length;
                    var temp = arr[current];
                    arr[current] = prev;
                    prev = temp;
                    count++;
                    if (count >= arr.Length)
                        return;
                }
                while (current != i);
                arr.Print();
                
            }
        }

        // 961. N-Repeated Element in Size 2N Array
        // In a array A of size 2N, there are N+1 unique elements, and exactly one of these elements is repeated N times.
        // Return the element repeated N times.
        public static int RepeatedNTimes(int[] arr)
        {
            var hash = new HashSet<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (hash.Contains(arr[i]))
                {
                    return arr[i];
                }

                hash.Add(arr[i]);
            }

            return -1;
        }

        // 167. Two Sum II - Input array is sorted
        // Given an array of integers that is already sorted in ascending order, find two numbers such that they add up to a specific target number.
        public static int[] TwoSumSorted(int[] arr, int target)
        {
            var i1 = 0;
            var i2 = arr.Length - 1;

            while (i1 != i2)
            {
                var result = arr[i1] + arr[i2];
                if (result == target)
                {
                    return new int[] { i1 + 1, i2 + 1 };
                }
                else if (result > target)
                {
                    i2--;
                }
                else
                {
                    i1++;
                }
            }
            return new int[] { i1 + 1, i2 + 1 };
        }

        // 26. Remove Duplicates from Sorted Array in place
        public static int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0)
                return 0;
            var index = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] != nums[i - 1])
                {
                    nums[index] = nums[i];
                    index++;
                }
            }

            return index;
        }

    }
}
