using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SherNingFrameWork
{
    public class LinearRegressionCalculator
    {
        public void Run()
        {
            double SumXY = 0;
            double SumXX = 0;
            double SumYY = 0;
            double SumX = 0;
            double SumY = 0;

            Data[] data = new Data[12];
            for (int i = 0; i < data.Length; i++)
                data[i] = new Data();

            double[] sales = new double[]
            {
                200000, 250000, 400000, 500000, 900000, 1100000,
                1500000, 1300000, 800000, 600000, 300000, 500000
            };

            double[] temp = new double[]
            {
                33, 37, 72, 65, 78, 85, 
                88, 91, 82, 73, 45, 36
            };

            for (int i = 0; i < data.Length; i++)
            {
                data[i].XX = temp[i] * temp[i];
                SumXX += data[i].XX;

                data[i].XY = temp[i] * sales[i];
                SumXY += data[i].XY;

                data[i].YY = sales[i] * sales[i];
                SumYY += data[i].YY;

                SumX += temp[i];
                SumY += sales[i];
            }

            double n = 12;
            double m = ((n * SumXY) - (SumX * SumY)) / ((n * SumXX) - (SumX * SumX));
            double b = (SumY - (m * SumX)) / n;
            double r = ((n * SumXY) - (SumX * SumY)) / Math.Sqrt((n * SumXX - (SumX * SumX)) * (n * SumYY - (SumY * SumY)));

            Console.WriteLine(m);
            Console.WriteLine(b);
            Console.WriteLine(r * r);
        }


        class Data
        {
            public double XY { get; set; }
            public double XX { get; set; }
            public double YY { get; set; }
        }
    }
}
