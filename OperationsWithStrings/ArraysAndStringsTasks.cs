using System;
using System.Collections.Generic;
using System.Linq;

namespace OperationsWithStrings
{
    public static class ArraysAndStringsTasks
    {
        // 1. Implement an algorithm to determine if a string has all unique characters. Cannot use additional data structures
        public static bool AreAllCharactersUnique(string str)
        {
            if (str.Length > 128) return false;
            bool[] charSet = new bool[128];
            for (int i = 0; i < str.Length; i++)
            {
                var value = str[i];
                if (charSet[value]) return false;

                charSet[value] = true;
            }

            return true;
        }

        // 2. Given two strings, write a method to decide if one is a permutation of the other.
        public static bool IsAPermutation(string str1, string str2)
        {
            if (str1.Length != str2.Length) return false;

            var firstArray = str1.ToCharArray();
            var secondArray = str2.ToCharArray();

            Array.Sort(firstArray);
            Array.Sort(secondArray);

            for (int i = 0; i < firstArray.Length - 1; i++)
            {
                if (firstArray[i] != secondArray[i])
                {
                    return false;
                }
            }

            return true;
        }

        // 3. Write a method to replace all spaces in a string with '%20'. You may assume that the string
        // has sufficient space at the end to hold the additional characters, and that you are given the "true"
        // length of the string.
        public static char[] URLify(char[] arr)
        {
            Console.WriteLine(new string(arr));

            char[] toReplace = { '%', '2', '0' };
            var index1 = arr.Length - 1;
            int k = arr.Length - 1; ;

            while (k >= 0 && arr[k] == ' ')
            {
                k--;
            }

            for (int i = k; i >= 0; i--)
            {
                if (arr[i] != ' ')
                {
                    arr[index1] = arr[i];
                    index1--;
                }
                else
                {
                    arr[index1] = toReplace[2];
                    arr[index1 - 1] = toReplace[1];
                    arr[index1 - 2] = toReplace[0];
                    index1 -= 3;
                }
            }

            Console.WriteLine(new string(arr));

            return arr;
        }

        // 4. There are three types of edits that can be performed on strings: insert a character,
        // remove a character, or replace a character.
        // Given two strings, write a function to check if they are one edit (or zero edits) away.
        public static bool IsOneAway(string str1, string str2)
        {
            if (Math.Abs(str1.Length - str2.Length) > 1)
            {
                return false;
            }

            var count = 0;
            var shorterArr = str1.Length < str2.Length ? str1 : str2;
            var longerArr = str1.Length >= str2.Length ? str1 : str2;
            var k = 0;

            for (int i = 0; i < shorterArr.Length; i++)
            {
                if (shorterArr[i] != longerArr[k])
                {
                    count++;
                    if (str1.Length != str2.Length)
                    {
                        if (shorterArr[i] == longerArr[k + 1])
                        {
                            k++;
                        }
                        else 
                        {
                            return false;
                        }
                    }
                }

                k++;
            }

            if (count > 1)
            {
                return false;
            }

            return true;
        }


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
    }
}
