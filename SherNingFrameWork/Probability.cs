using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SherNingFrameWork
{
    static class Probability
    {
        //================================= Project Documentation =================================
        // Project Name : Probability
        // Platform     : Console Application
        // Class Type   : Static 
        // Date         : 03-Nov-2020
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
         *  03/11/2020 - Factorial
         * 
         *======================================== Version ========================================
        /*/

        public static void Call()
        {
            Test1();
        }

        private static void Test1()
        {
            int n = 5;
            int r = 3;
            Console.WriteLine("Permutation: " + Permutation(n, r));
            Console.WriteLine("Combination: " + Combination(n, r));
            Console.WriteLine("Math Power: " + Math.Pow(3, -4));
            Console.WriteLine("Power: " + Power(3, -4));
            Console.WriteLine("Dependent Events: " + (DependentEvents(4, 36) * Combination(9, 4)));
        }

        private static void Test2(bool cast = true)
        {
            int i = 5;
            int j = 3;
            double ans;
            if (cast)
                // you will need to cast to preserve results
                ans = (double)i / (double)j;
            else
                ans = i / j;
            Console.WriteLine(ans);
        }

        private static double Factorial(int n)
        {
            // 0! = 1
            if (n == 0) return 1;

            double ret = 1;

            // 3! = 3 X 2 X 1
            for (int i = n; i > 0; i--)
                ret *= i;

            return ret;
        }

        private static double Permutation(int n, int r)
        {
            // nPr 
            if (n == r) return Factorial(n);
            return Factorial(n) / Factorial(n - r);
        }

        private static double Combination(int n, int r)
        {
            // nCr
            if (n == r) return 1;

            // xC1 = x 
            if (r == 1) return n;

            // permutation / nPn == (n!) 
            return Permutation(n, r) / Factorial(r);
        }

        private static double Power(int num, int exponent)
        {
            // 0^0, defined to be 1, and not exception
            if (num == 0 && exponent == 0) return 1;
            if (num == 0) return 0;

            // a^0 = 1, a^b x a^c = a^(b+c)
            double ret = 1;

            if (exponent >= 0)
            {
                for (int i = 0; i < exponent; i++)
                    ret *= num;
            }
            else
            {
                // -exponent = abs(exponent)
                for (int i = 0; i < -exponent; i++)
                    ret /= num;
            }

            return ret;
        }

        private static double DependentEvents(double numerator, double denominator)
        {
            if (denominator == 0 || numerator == 0) return 1;

            // P(X) = 4/5 * 3/4 * 2/3 * 1/2 * 1
            return numerator / denominator * DependentEvents(numerator - 1, denominator - 1);
        }
    }
}
