using System;
using System.Collections.Generic;

namespace LAS_Interface.Util
{
    public class GeneralUtil
    {
        public static List<string> GetWeekList(int year)
        {
            var fin = new List<string>();
            for (var i = 1; i < 57; i++)
                fin.Add("KW: " + i);
            return fin;
        }
    }
}