using System.Collections.Generic;
using System.Linq;
using LAS_Interface.Types;

namespace LAS_Interface.Util
{
    public class TimeTableUtil
    {
        /// <summary>
        /// Gets one empty TimeTable for specific class
        /// </summary>
        /// <returns>the timeTable</returns>
        public static TimeTable GetEmptyTimeTable (string cclass)
        {
            var rows = new List<TimeTableRow> ();
            for (var i = 0; i < 9; i++)
                rows.Add (new TimeTableRow (i.ToString (), "", "", "", "", ""));
            return new TimeTable (rows, cclass);
        }

        /// <summary>
        /// Gets empty timeTables for every class
        /// </summary>
        /// <returns>empty timeTables</returns>
        public static List<TimeTable> GetAllEmptyTimeTables (List<string> classes)
                    => classes.Select (GetEmptyTimeTable).ToList ();

        /// <summary>
        /// Updates every timeTable-time
        /// </summary>
        /// <returns>The updated TimeTables</returns>
        public static List<TimeTable> GetTimeTablesWithUpdatedTime (List<TimeTable> current, List<string> newTimes)
        {
            var fin = new List<TimeTable> ();
            foreach (var timeTable in current)
            {
                var newRows = new List<TimeTableRow> ();
                for (var i = 0; i < timeTable.TimeTableRows.Count && i < newTimes.Count; i++)
                {
                    var row = new List<TimeTableRow> (timeTable.TimeTableRows)[i];
                    newRows.Add (new TimeTableRow (newTimes[i], row.Monday, row.Tuesday, row.Wednesday, row.Thursday, row.Friday));
                }
                fin.Add (new TimeTable (newRows, timeTable.Class));
            }
            return fin;
        }
    }
}