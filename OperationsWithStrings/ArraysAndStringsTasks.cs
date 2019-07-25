using System;
using System.Collections;
using System.Text;

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

        // 5. There are three types of edits that can be performed on strings: insert a character,
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

        // 6. Implement a method to perform basic string compression using the counts
        // of repeated characters. For example, the string aabcccccaaa would become a2blc5a3. If the
        // "compressed" string would not become smaller than the original string, your method should return
        // the original string. You can assume the string has only uppercase and lowercase letters(a - z).
        public static string CompressString(string str)
        {
            if (str.Length == 0)
            {
                return "";
            }

            char c = str[0];
            int count = 1;
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i < str.Length; i++)
            {
                if (c == str[i])
                {
                    count++;
                }
                else
                {
                    sb = sb.Append(c).Append(count);
                    if (sb.Length >= str.Length)
                    {
                        return str;
                    }

                    count = 1;
                    c = str[i];
                }
            }

            sb = sb.Append(c).Append(count);

            return sb.Length >= str.Length ? str : sb.ToString();
        }

        // 7. Given an image represented by an NxN matrix, where each pixel in the image is 4
        // bytes, write a method to rotate the image by 90 degrees. Can you do this in place?

        // Try thinking about it layer by layer. Can you rotate a specific layer? 
        // Rotating a specific layer would just mean swapping the values in four arrays.
        // If you were asked to swap the values in two arrays, could you do this? Can you then extend it to four arrays? 
        public static void RotateMatrix(int[][] matrix)
        {
            PrintMatrix(matrix);

            var n = matrix.Length;
            for (int i = 0; i < n / 2; i++)
            {
                for (int j = i; j < n - 1 - i; j++)
                {
                    var temp = matrix[i][j];
                    matrix[i][j] = matrix[n - 1 - j][i];
                    matrix[n - 1 - j][i] = matrix[n - 1 - i][n - 1 - j];
                    matrix[n - 1 - i][n - 1 - j] = matrix[j][n - 1 - i];
                    matrix[j][n - 1 - i] = temp;
                }
            }

            PrintMatrix(matrix);
        }

        private static void PrintMatrix(int[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix.Length; j++)
                {
                    Console.Write(matrix[i][j] + " ");
                }
                Console.WriteLine();
            }
        }

        // 8. Write an algorithm such that if an element in an MxN matrix is 0,
        // its entire row and column are set to 0.
        public static int[,] ZeroMatrix(int[,] matrix, int n, int m)
        {
            var arrIth = new ArrayList();
            var arrJth = new ArrayList();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        arrIth.Add(i);
                        arrJth.Add(j);
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (arrIth.Contains(i) || arrJth.Contains(j))
                    {
                        matrix[i, j] = 0;
                    }
                }
            }
            
            return matrix;
        }
    }
}
