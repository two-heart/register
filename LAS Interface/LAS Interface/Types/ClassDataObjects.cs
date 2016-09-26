using System.Collections.Generic;

namespace LAS_Interface.Types
{
    public class ClassDataObjects
    {
        public List<WeekDataObjects> WeekDataObjects;
        public string Class;

        public ClassDataObjects(List<WeekDataObjects> weekDataObjects, string cclass)
        {
            WeekDataObjects = weekDataObjects;
            Class = cclass;
        }
    }
}