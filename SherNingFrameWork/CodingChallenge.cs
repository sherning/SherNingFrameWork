using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SherNingFrameWork
{
    static class CodingChallenge
    {
        //================================= Project Documentation =================================
        // Project Name : Coding Challenge
        // Platform     : Console Application
        // Class Type   : Static 
        // Date         : 
        // Developer    : Sher Ning
        //=========================================================================================
        // Copyright    : 2020, Sher Ning Technologies           
        // License      : Internal use
        // Client       : Sher Ning
        // Contact      : sherning@hotmail.com
        //=========================================================================================
        // References   :         
        // Obectives    : 
        // Remarks      :
        //=========================================================================================

        /*/
         *======================================== Version ========================================
         *  15/09/2020 - Test Reading CSV file
         * 
         *======================================== Version ========================================
        /*/
        public static void Call()
        {
            Challenge_1();
        } 

        #region Challenge 1
        //================================= Project Documentation =================================
        // Challenge Name : Coding Challenge
        // Objectives     : f(523,76) -> 763, f(9132,5564) -> 9655, f(8732,91255) -> 9755
        // Description    : Make the first number as large as possible
        // Solution       : 
        //
        // Step 1: Convert Digit to Array first
        // Step 2: Convert Array back to Digits
        // Step 3: Compare two arrays
        //=========================================================================================
        private static void Challenge_1()
        {
            int number = LargestFirstNumber(9132, 5564);
            Console.WriteLine(number);
        }
        private static int LargestFirstNumber(int first, int second)
        {
            // convert digits to array
            int[] arr1 = DigitsToArr(first);
            int[] arr2 = DigitsToArr(second);

            // pointer
            int x = 0;

            while (x < arr1.Length)
            {
                int yValue = LargestNumberCorrespondingIndex(arr2, out int yIndex);
                if (yValue == -1) break;

                if (arr1[x] < yValue)
                {
                    // swap the value
                    arr1[x] = yValue;

                    // cannot reuse number
                    arr2[yIndex] = -1;
                }

                x++;
            }

            return IntArrToDigits(arr1);
        }

        private static int LargestNumberCorrespondingIndex(int[] arr, out int index)
        {
            int ret = index = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (ret < arr[i])
                {
                    ret = Math.Max(ret, arr[i]);

                    // return corresponding index
                    index = i;
                }
            }

            return ret;
        }

        private static int IntArrToDigits(int[] numArr)
        {
            int num = 0;
            for (int i = 0; i < numArr.Length; i++)
                num += numArr[i] * Convert.ToInt32(Math.Pow(10, numArr.Length - i - 1));

            return num;
        }

        private static int[] DigitsToArr(int num)
        {
            if (num == 0) return new int[1] { 0 };

            List<int> digits = new List<int>();

            // same as while loop
            //for (; num != 0; num /= 10)
            //    digits.Add(num % 10);

            while (num != 0)
            {
                digits.Add(num % 10);
                num /= 10;
            }

            var arr = digits.ToArray();
            Array.Reverse(arr);

            return arr;
        }
        #endregion
    }
}
