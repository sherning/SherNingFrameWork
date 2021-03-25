using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SherNingFrameWork
{
    public class FinanceCalculator
    {
        public static void Run()
        {
            Console.WriteLine("YTM: " + YieldToMaturity(5, 4, 100000, 92227));
        }

        private static double GeometricReturns(params double[] data)
        {
            // compounded rate of return 
            double mean = 1;
            double power = 1.0 / data.Length;

            for (int i = 0; i < data.Length; i++)
                mean *= 1.0 + (data[i] / 100);

            return Math.Pow(mean, power) - 1;
        }

        private static double StandardError(params double[] data)
        {
            // standard error is the standard deviation of the sampling distribution of the  sample mean
            double stdDev = StandardDeviation(data);
            return stdDev / Math.Sqrt(data.Length);
        }

        private static double Arithmetic(params double[] data)
        {
            double mean = 0;
            for (int i = 0; i < data.Length; i++)
                mean += data[i];

            return mean / data.Length;
        }

        private static double StandardDeviation(params double[] data)
        {
            double mean = Arithmetic(data);
            double variance = 0;

            for (int i = 0; i < data.Length; i++)
                variance += Math.Pow(data[i] - mean, 2);

            return data.Length < 30 ?
                Math.Sqrt(variance / (data.Length - 1)) :
                Math.Sqrt(variance / data.Length);
        }

        private static double YieldToMaturity(double period, double interest, int parValue, double presentValue, int limitsInDollars = 20)
        {
            // Yield to Maturity
            // rate of return you receive on a bond you buy and hold to maturity
            // par value is the face value you will receive at maturity
            double ytm = 0;

            // zero coupon bond
            if (interest == 0)
            {
                period = 1.0 / period;
                ytm = Math.Pow((parValue / presentValue), period) - 1;
                return ytm;
            }

            double couponPayment = (interest / 100) * parValue;

            // maximum interest is 20%, by trial and error
            for (double i = 0.001; i < 0.2; i += 0.0001)
            {
                double calc = (couponPayment * (1.0 / i) * (1.0 - (1.0 / Math.Pow(1.0 + i, period))))
                    + (parValue / Math.Pow(1.0 + i, period));

                // calc == present value (v close to)
                double bestEstimate = presentValue - (int)calc;
                if (bestEstimate > 0 && bestEstimate <= limitsInDollars) return i;
            }

            return ytm;
        }
    }
}
