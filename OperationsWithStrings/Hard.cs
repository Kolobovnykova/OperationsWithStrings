using System;

namespace OperationsWithStrings
{
    public static class Hard
    {
        // Given an array of integers, return a new array such that each element at index i of the new array
        // is the product of all the numbers in the original array except the one at i.
        // For example, if our input was [1, 2, 3, 4, 5], the expected output would be [120, 60, 40, 30, 24].
        // If our input was [3, 2, 1], the expected output would be [2, 3, 6].
        // Follow-up: what if you can't use division?
        public static int[] ProductArray(int[] arr)
        {
            // O(n2)
            //int[] arr2 = new int[arr.Length];
            //var p = 1;
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    for (int j = 0; j < arr.Length; j++)
            //    {
            //        if (j != i)
            //        {
            //            p *= arr[j];
            //        }
            //        arr2[i] = p;
            //    }
            //    p = 1;
            //}

            //return arr2;

            // O(n)
            var n = arr.Length;
            //var left = new int[n];
            //var right = new int[n];
            //var prod = new int[n];

            //left[0] = 1;
            //right[n - 1] = 1;

            //for (int i = 1; i < n; i++)
            //{
            //    left[i] = arr[i - 1] * left[i - 1];
            //}

            //for (int i = n - 2; i >= 0; i--)
            //{
            //    right[i] = arr[i + 1] * right[i + 1];
            //}

            //for (int i = 0; i < n; i++)
            //{
            //    prod[i] = right[i] * left[i];
            //}

            // space O(1)
            var prod = new int[n];
            var temp = 1;
            for (int i = 0; i < n; i++)
            {
                prod[i] = 1;
            }

            for (int i = 0; i < n; i++)
            {
                prod[i] = temp;
                temp *= arr[i];
            }

            temp = 1;
            for (int i = n - 1; i >= 0; i--)
            {
                prod[i] *= temp;
                temp *= arr[i];
            }

            return prod;
        }

        // Given an array of integers, find the first missing positive integer in linear time and constant space.
        // In other words, find the lowest positive integer that does not exist in the array.
        // The array can contain duplicates and negative numbers as well.
        // For example, the input[3, 4, -1, 1] should give 2. The input[1, 2, 0] should give 3.
        // You can modify the input array in-place.
        public static int FirstMissingPositiveInteger(int[] arr)
        {
            // O(n2)
            //var n = arr.Length;
            //for (int j = 1; j < n + 2; j++)
            //{
            //    var temp = 1;
            //    for (int i = 0; i < n; i++)
            //    {
            //        arr[i] -= 1;
            //        temp *= arr[i];
            //    }
            //    if (temp != 0)
            //    {
            //        return j;
            //    }
            //}


            // get min
            var min = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (min > arr[i])
                {
                    min = arr[i];
                }
            }

            if (min < 0)
            {
                var mod = Math.Abs(min);
                // make arr positive
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] += mod;
                }

                var minPositive = int.MaxValue;

                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] < arr.Length + 1)
                    {
                        arr[i] *= -1;
                    }
                    else
                    {
                        if (arr[i] < minPositive)
                        {
                            minPositive = arr[i];
                        }
                    }
                }

                return Math.Abs(minPositive) - mod + 1;
            }    

            return arr.Length + 1;
        }
    }
}
