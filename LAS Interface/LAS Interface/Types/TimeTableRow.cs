namespace LAS_Interface.Types
{
    public class TimeTableRow
    {
        /// <summary>
        /// Initializes a new TimeTable row - so one row in the timeTable (e.g. 1 Mathe Deutsch Englisch ...)
        /// </summary>
        /// <returns>one row</returns>
        public TimeTableRow (string time, string monday, string tuesday, string wednesday, string thursday, string friday)
        {
            Time = time;
            Monday = monday;
            Tuesday = tuesday;
            Wednesday = wednesday;
            Thursday = thursday;
            Friday = friday;
        }

        /// <summary>
        /// The time of the current row
        /// </summary>
        /// <value>the time as a string</value>
        public string Time { get; set; }
        public string Monday { get; set; }
        public string Tuesday { get; set; }
        public string Wednesday { get; set; }
        public string Thursday { get; set; }
        /// <summary>
        /// One cell (the friday cell). Same for Monday, Tuesday, ...
        /// </summary>
        /// <value>the cell data</value>
        public string Friday { get; set; }
    }
}