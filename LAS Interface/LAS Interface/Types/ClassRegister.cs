using System.Collections.Generic;

namespace LAS_Interface.Types
{
    public class ClassRegister
    {
        public List<WeekDataObjects> WeekDataObjects;
        public string Class;

        public ClassRegister(List<WeekDataObjects> weekDataObjects, string cclass)
        {
            WeekDataObjects = weekDataObjects;
            Class = cclass;
        }
    }
}