using System;
using System.Collections.Generic;
using LAS_Interface.PublicStuff;

namespace LAS_Interface.Util
{
    public class TimeUtil
    {
        public static List<string> GetWeekList(int year) //TODO
        {
            var fin = new List<string>();
            for (var i = 1; i <= GeneralPublicStuff.WeeksPerYear; i++)
                fin.Add("KW: " + i);
            return fin;
        }

        public static List<string> GetWeekList(DateTime beginning, int weekCount)
        {
            var fin = new List<string>();
            if (beginning.DayOfWeek != DayOfWeek.Monday)
            {
                fin.Add(beginning.ToShortDateString() + "-" + (beginning = GetNextMonday(beginning)).ToShortDateString());
                fin[0] += beginning.ToShortDateString();
            }
            while (weekCount > 0)
            {
                fin.Add(beginning.ToShortDateString() + "-" + (beginning = beginning.AddDays(7)).ToShortDateString());
                weekCount--;
            }
            return fin;
        }

        public static DateTime GetNextMonday(DateTime now)
        {
            while (now.DayOfWeek != DayOfWeek.Monday)
                now = now.AddDays(1);
            return now;
        }
    }
}