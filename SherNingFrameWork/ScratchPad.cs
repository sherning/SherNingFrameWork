using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SherNingFrameWork
{
    public static class ScratchPad
    {
        public static void Run()
        {
           
        }

        static void TrueFalse()
        {
            Random day = new Random();
            DateTime sat = new DateTime(2021, 1, 9);
            DateTime sun = new DateTime(2021, 1, 10);
            DateTime date;

            bool a = false;
            bool b = true;

            for (int i = 0; i < 20; i++)
            {
                date = new DateTime(2021, 1, day.Next(1, 30));

                if (date.DayOfWeek < DayOfWeek.Saturday && date.DayOfWeek > DayOfWeek.Sunday)
                {
                    Console.WriteLine("Date: " + date + " Day of Week: " + date.DayOfWeek);
                }
            }
        }

    }
}
