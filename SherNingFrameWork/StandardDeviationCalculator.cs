using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SherNingFrameWork
{
    class StandardDeviationCalculator
    {
        public static void Run()
        {
            double[] data = new double[] { 600, 470, 170, 430, 300 };

            double mean = Mean(600, 470, 170, 430, 300);
        }

        private static double Mean(params double[] data)
        {
            double mean = 0;
            for (int i = 0; i < data.Length; i++)
                mean += data[i];

            return mean / data.Length;
        }

        private static double StdDev1(params double[] data)
        {
            double mean = Mean(data);
            double variance = 0;

            for (int i = 0; i < data.Length; i++)
                variance += Math.Pow(data[i] - mean, 2);

            return Math.Sqrt(variance / data.Length);
        }

        private static double StdDev2(params double[] data)
        {
            double mean = Mean(data);
            double variance = 0;

            for (int i = 0; i < data.Length; i++)
                variance += Math.Abs(data[i] - mean);

            return variance / data.Length;
        }
    }
}
