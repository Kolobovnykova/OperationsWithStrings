using System;
using System.Collections.Generic;
using System.Text;

namespace OperationsWithStrings
{
    public static class Medium
    {
        // 11. Container With Most Water
        public static int MaxArea(int[] height)
        {
            //O(n2)
            int maxResult = 0;
            //for (int i = 0; i < height.Length - 1; i++)
            //{
            //    for (int j = i + 1; j < height.Length; j++)
            //    {
            //         maxResult = Math.Max(maxResult, (j - i) * Math.Min(height[i], height[j]));              
            //     }
            // }

            // O(n)
            int i = 0;
            int j = height.Length - 1;

            while (i < j)
            {
                maxResult = Math.Max(maxResult, (j - i) * Math.Min(height[i], height[j]));
                if (height[i] > height[j])
                    j--;
                else
                    i++;
            }

            return maxResult;
        }
    }
}
