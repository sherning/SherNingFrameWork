using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SherNingFrameWork
{
    static class Statistics
    {
        //================================= Project Documentation =================================
        // Project Name : Statistics
        // Platform     : Console Application
        // Class Type   : Static Class
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
         *  15/09/2020 - Sample vs Population
         * 
         *======================================== Version ========================================
        /*/
        public static void Call()
        {
            PopulationVsSampleVariance();
            Console.WriteLine(GetPopulationStdDev(1,2,3,4,5));
            Console.WriteLine(GetPopulationStdDevAlgebra(1,2,3,4,5));
        }

        private static void PopulationVsSampleVariance()
        {
            int[] population = GenerateDataSet(50);
            Console.WriteLine("Population Set");
            foreach (var item in population)
            {
                Console.Write(item + ", ");
            }

            Console.WriteLine("\n");
            Console.WriteLine("Sample Set");

            // sample percentage has to be 50% to be close to population std dev
            int[] sample = SampleSelector(population, 0.5);
            foreach (var item in sample)
            {
                Console.Write(item + ", ");
            }

            Console.WriteLine("\n");
            Console.WriteLine("Compute Population Std Dev");
            double populationStdDev = GetPopulationStdDev(population);
            Console.WriteLine(populationStdDev);
            Console.WriteLine("\n");

            Console.WriteLine("Compute Sample Std Dev");
            double sampleStdDev = GetSampleStdDev(sample);
            Console.WriteLine(sampleStdDev);
            Console.WriteLine("\n");

            Console.WriteLine("Difference between population vs sample std dev: " 
                + (populationStdDev - sampleStdDev));
        }

        private static int[] GenerateDataSet(int elements)
        {
            // numbers maybe repeated

            int[] arr = new int[elements];
            Random random = new Random();

            for (int i = 0; i < elements; i++)
                arr[i] = random.Next(1, 100);

            return arr;
        }

        private static int[] SampleSelector(int[] dataSet, double percentage)
        {
            // check
            if (percentage <= 0 || percentage >= 1) return null;

            int sampleSize = (int)(dataSet.Length * percentage);
            int[] sampleArr = new int[sampleSize];

            // generate a set of non-repeating numbers
            Random random = new Random();
            List<int> nonRepeatingNum = new List<int>();
            while (nonRepeatingNum.Count <= sampleSize)
            {
                int num = random.Next(0, dataSet.Length - 1);

                // if does not contain repeated num
                if (!nonRepeatingNum.Contains(num))
                    nonRepeatingNum.Add(num);
            }

            // generate a random sample from population set
            for (int i = 0; i < sampleSize; i++)
                sampleArr[i] = dataSet[nonRepeatingNum[i]];

            return sampleArr;
        }

        private static double GetPopulationStdDev(params int[] population)
        {
            // for trading, use population since the population is usually less than 100 data entries
            // population mean denoted by miu
            double miu = Mean(population);

            // calculate variance sigmaSquared
            double variance = 0;
            for (int i = 0; i < population.Length; i++)
                variance += Math.Pow(population[i] - miu, 2);

            // divided by N (population length)
            variance /= population.Length;

            // return standard deviation, sigma
            return Math.Sqrt(variance);
        }

        private static double GetPopulationStdDevAlgebra(params int[] population)
        {
            // population mean denoted by miu
            double miu = Mean(population);

            // calculate variance sigmaSquared
            double variance = 0;
            for (int i = 0; i < population.Length; i++)
                variance += Math.Pow(population[i], 2);

            // new algebra formula for calculating variance, only for population.
            variance /= population.Length;
            variance -= Math.Pow(miu, 2);

            // return standard deviation, sigma
            return Math.Sqrt(variance);
        }

        private static double GetSampleStdDev(params int[] sample)
        {
            // population mean denoted by x Bar
            double xBar = Mean(sample);

            // calculate variance sSquared
            double variance = 0;
            for (int i = 0; i < sample.Length; i++)
                variance += Math.Pow(sample[i] - xBar, 2);

            // divided by n - 1 (sample length)
            variance /= (sample.Length - 1);

            // return standard deviation, s
            return Math.Sqrt(variance);
        }

        private static double Mean(params int[] arr)
        {
            if (arr == null) return 0;

            double sum = 0;
            for (int i = 0; i < arr.Length; i++)
                sum += arr[i];

            return sum / arr.Length;
        }
    }
}
