using System.Collections.Generic;
using System.Linq;
using LAS_Interface.Types;

namespace LAS_Interface.Util
{
    public class TimeTableUtil
    {
        public static TimeTable GetEmptyTimeTable(string cclass)
        {
            var rows = new List<TimeTableRow>();
            for (var i = 0; i < 9; i++)
                rows.Add(new TimeTableRow(i.ToString(), "", "", "", "", ""));
            return new TimeTable(rows, cclass);
        }

        public static List<TimeTable> GetAllEmptyTimeTables(List<string> classes)
            => classes.Select(GetEmptyTimeTable).ToList();
    }
}