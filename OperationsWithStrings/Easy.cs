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
    }
}
