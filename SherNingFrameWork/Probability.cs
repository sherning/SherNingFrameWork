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
        
        }

        private static double Factorial(int n)
        {
            double ret = 1;
            for (int i = n; i > 0; i--)
                ret *= i;

            return ret;
        }

    }
}
