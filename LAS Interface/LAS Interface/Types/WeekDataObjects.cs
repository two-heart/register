using System.Collections.Generic;

namespace LAS_Interface.Types
{
    public class WeekDataObjects
    {
        /// <summary>
        /// Initializes a new List of WeekDataObjects
        /// </summary>
        /// <returns>nothing</returns>
        public WeekDataObjects (List<DataObject> monday, List<DataObject> tuesday, List<DataObject> wednesday,
                    List<DataObject> thursday, List<DataObject> friday, string week)
        {
            Monday = monday;
            Tuesday = tuesday;
            Wednesday = wednesday;
            Thursday = thursday;
            Friday = friday;
            Week = week;
        }

        public List<DataObject> Monday { get; set; }
        public List<DataObject> Tuesday { get; set; }
        public List<DataObject> Wednesday { get; set; }
        public List<DataObject> Thursday { get; set; }
        /// <summary>
        /// The Dataobjects for Friday. Same for Monday, Tuesday, ...
        /// </summary>
        /// <value>the dataObjects</value>
        public List<DataObject> Friday { get; set; }
        /// <summary>
        /// The week of the Objects in form of a string
        /// </summary>
        /// <value>the week</value>
        public string Week { get; set; }
    }
}