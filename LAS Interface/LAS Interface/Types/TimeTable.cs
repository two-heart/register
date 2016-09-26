using System.Collections.Generic;

namespace LAS_Interface.Types
{
    public class TimeTable
    {
        public List<TimeTableRow> TimeTableRows { get; set; }
        public string Class;

        public TimeTable(List<TimeTableRow> timeTableRows, string cclass)
        {
            TimeTableRows = timeTableRows;
            Class = cclass;
        }
    }
}