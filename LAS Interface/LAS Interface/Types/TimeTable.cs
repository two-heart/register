using System.Collections.Generic;

namespace LAS_Interface.Types
{
    public class TimeTable
    {
        /// <summary>
        /// Initializes a new TimeTable
        /// </summary>
        /// <returns>nothing</returns>
        public TimeTable (List<TimeTableRow> timeTableRows, string cclass)
        {
            TimeTableRows = timeTableRows;
            Class = cclass;
        }

        /// <summary>
        /// The data of the timeTable in form of rows.
        /// </summary>
        /// <value>the data</value>
        public List<TimeTableRow> TimeTableRows { get; set; }
        /// <summary>
        /// The class from the timeTable
        /// </summary>
        /// <value>the class</value>
        public string Class { get; set; }
    }
}