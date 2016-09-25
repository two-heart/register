﻿using System.Collections.Generic;
using LAS_Interface.Types;

namespace LAS_Interface.Util
{
    public class DataObjectsUtil
    {
        public static List<DataObject> GetnEmptyDataObjects (int n)
        {
            var fin = new List<DataObject>();
            while (n > 0)
            {
                fin.Add(new DataObject("", "", "", ""));
                n--;
            }
            return fin;
        }

        public static WeekDataObjects GetEmptyWeekDataObjects (int entriesPerDay)
        {
            return new WeekDataObjects (
                GetnEmptyDataObjects (entriesPerDay),
                GetnEmptyDataObjects (entriesPerDay),
                GetnEmptyDataObjects (entriesPerDay),
                GetnEmptyDataObjects (entriesPerDay),
                GetnEmptyDataObjects (entriesPerDay));
        }

        public static List<WeekDataObjects> GetEmptyAllDataObjects(int entriesPerDay, int count)
        {
            var that = new List<WeekDataObjects>();
            while (count > 0)
            {
                that.Add(GetEmptyWeekDataObjects(entriesPerDay));
                count--;
            }
            return that;
        }
    }
}