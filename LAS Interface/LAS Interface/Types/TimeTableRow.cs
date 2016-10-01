namespace LAS_Interface.Types
{
    public class TimeTableRow
    {
        public TimeTableRow(string time, string monday, string tuesday, string wednesday, string thursday, string friday)
        {
            Time = time;
            Monday = monday;
            Tuesday = tuesday;
            Wednesday = wednesday;
            Thursday = thursday;
            Friday = friday;
        }

        public string Time { get; set; }
        public string Monday { get; set; }
        public string Tuesday { get; set; }
        public string Wednesday { get; set; }
        public string Thursday { get; set; }
        public string Friday { get; set; }
    }
}