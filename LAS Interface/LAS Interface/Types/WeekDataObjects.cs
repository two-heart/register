﻿using System.Collections.Generic;

namespace LAS_Interface.Types
{
    public class WeekDataObjects
    {
        public List<DataObject> Monday { get; set; }
        public List<DataObject> Tuesday { get; set; }
        public List<DataObject> Wednesday { get; set; }
        public List<DataObject> Thursday { get; set; }
        public List<DataObject> Friday { get; set; }

        public WeekDataObjects(List<DataObject> monday, List<DataObject> tuesday, List<DataObject> wednesday, List<DataObject> thursday, List<DataObject> friday)
        {
            Monday = monday;
            Tuesday = tuesday;
            Wednesday = wednesday;
            Thursday = thursday;
            Friday = friday;
        }
    }
}