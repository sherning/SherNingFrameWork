using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SherNingFrameWork
{
    class NumberOfSundays
    {
        public void Run()
        {
            int totalYears = 20;
            int baseYear = 2010;

            // 10 years
            Sundays[] sundays = new Sundays[totalYears];

            for (int i = 1; i <= totalYears; i++)
            {
                int[] NumOfDaysInMth = new int[12];

                for (int j = 1; j <= 12; j++)
                    // count only 5 sundays
                    if(HowManySundaysIn(baseYear + i, j) == 5)
                        NumOfDaysInMth[j - 1] = 1;

                int sum = 0;
                for (int k = 0; k < NumOfDaysInMth.Length; k++)
                    sum += NumOfDaysInMth[k];

                // cache each object for one year
                sundays[i - 1] = new Sundays();
                sundays[i - 1].Year = baseYear + i;
                sundays[i - 1].NumOfSundays = sum;
            }

            for (int i = 0; i < sundays.Length; i++)
                Console.WriteLine("Year: " + sundays[i].Year + " Num Of 5 Sundays in Current Year: " + sundays[i].NumOfSundays);

            Console.WriteLine("Mean: " + Mean(sundays));
            Console.WriteLine("Standard Deviation: " + StandardDeviation(sundays));
        }

        private int HowManySundaysIn(int year, int month)
        {
            DateTime lastSundayOfMonth = new DateTime(year, month, LastSundayOfTheMonth(year, month));

            // floored
            int numSundays = lastSundayOfMonth.Day / 7;

            int remainder = lastSundayOfMonth.Day - (numSundays * 7);

            if (remainder == 0) return numSundays;

            DateTime day = new DateTime(year, month, remainder);

            if (day.DayOfWeek == DayOfWeek.Sunday)
                return numSundays + 1;
            else 
                return numSundays;
            
        }

        private int LastDayOfTheMonth(int year, int month)
        {
            // there maybe leap year
            DateTime day;

            // december
            if (month == 12)
                day = new DateTime(year + 1, 1, 1);
            else
                day = new DateTime(year, month + 1, 1);

            day = day.AddDays(-1);

            return day.Day;
        }

        private int LastSundayOfTheMonth(int year, int month)
        {
            DateTime day = new DateTime(year, month, LastDayOfTheMonth(year, month));

            while (day.DayOfWeek != DayOfWeek.Sunday)
                day = day.AddDays(-1);

            return day.Day;
        }

        private double Mean(Sundays[] data)
        {
            double mean = 0;
            for (int i = 0; i < data.Length; i++)
                mean += data[i].NumOfSundays;

            return mean / data.Length;
        }
        private double StandardDeviation(Sundays[] data)
        {
            double mean = Mean(data);

            double variance = 0;
            for (int i = 0; i < data.Length; i++)
                variance += Math.Pow(data[i].NumOfSundays - mean, 2);

            // small sample size
            variance /= (data.Length - 1);

            return Math.Sqrt(variance);
        }

        class Sundays
        {
            public int Year { get; set; }
            public int NumOfSundays { get; set; }
        }
    }
}
