using System;
using System.Collections.Generic;
using LAS_Interface.PublicStuff;
using LAS_Interface.Types;

namespace LAS_Interface.Util
{
    public class GeneralUtil
    {
        public static List<string> GetWeekList(int year) //TODO
        {
            var fin = new List<string>();
            for (var i = 1; i <= GeneralPublicStuff.WeeksPerYear; i++)
                fin.Add("KW: " + i);
            return fin;
        }

        public static List<string> GetClasses() //TODO
        {
            var fin = new List<string>();
            for (var i = 1; i < 13; i++)
                for (var j = 0; j < 4; j++)
                    fin.Add(i.ToString() + (char) (j + 'a'));
            return fin;
        }
    }
}