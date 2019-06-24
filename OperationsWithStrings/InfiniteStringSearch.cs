using System;
using System.Text;

namespace OperationsWithStrings
{
    public static class InfiniteStringSearch
    {
        /* == Infinite string search ==
         *
         * Given a string "s" that defines a pattern for a infinite string, and a number "n" that
         * defines the length of a substring that we should consider, you should create a function
         * that counts the number of letters 'a' on it.
         *
         * Example 1:
         * if the string is s = "abcac" and n = 10, the substring to be consider would be "abcacabcac".
         * There are 4 occurrences of letter 'a' in this substring.
         *
         * Example 2:
         * if the string is s = "aba" and n = 10, the substring to be consider would be "abaabaabaa".
         * There are 7 occurrences of letter 'a' in this substring. 
         *
         * Parameters:
         * - s: a string made with only lowercase letters
         * - n: the desired size of the substring
         *
         * Constraints:
         * - 1 <= s <= 100
         * - 1 <= n <= 10^12
         *
         * Returns:
         * <long> count of letters 'a' on the generated string
         */
        public static long GetNumberOfEntries(string pattern, int size, char character)
        {
            if (pattern.Length < 1 || pattern.Length > 100)
            {
                throw new ArgumentException("Length of string pattern should be between 1 and 100 charachers");
            }

            if (size < 1 || size > Math.Pow(10, 12))
            {
                throw new ArgumentException("Desired size of the substring should be a number between 1 and 10^12");
            }

            // for vizualization
            var fullString = GetFullString(pattern, size);
            Console.WriteLine($"Full string: {fullString}");

            long count = 0;

            var countOfEntriesInPattern = 0;

            foreach (var item in pattern)
            {
                if (item == character)
                {
                    countOfEntriesInPattern++;
                }
            }
            
            long countOfPatternsInSize = size / pattern.Length;
            long remainingStringLength = size % pattern.Length;

            count = countOfPatternsInSize * countOfEntriesInPattern;

            StringBuilder sb = new StringBuilder(pattern);
            sb.Remove((int)remainingStringLength, pattern.Length - (int)remainingStringLength);

            for (int i = 0; i < sb.Length; i++)
            {
                if (sb[i] == character)
                {
                    count++;
                }
            }

            return count;
        }

        private static string GetFullString(string pattern, int size)
        {
            StringBuilder s = new StringBuilder();
            while (s.Length < size)
            {
                s.Append(pattern);
            }

            if (s.Length > size)
            {
                s.Remove(size, s.Length - size);
            }

            return s.ToString();
        }
    }
}
