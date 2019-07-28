using System;
using System.Collections.Generic;
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
    }
}
