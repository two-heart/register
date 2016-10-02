using System.Collections.Generic;

namespace LAS_Interface.Types
{
    public class ClassRegister
    {
        /// <summary>
        /// Initializes the ClassRegister. This is the whole Register for one specific class.
        /// </summary>
        /// <returns>nothing</returns>
        public ClassRegister (List<WeekDataObjects> weekDataObjects, string cclass)
        {
            WeekDataObjects = weekDataObjects;
            Class = cclass;
        }

        /// <summary>
        /// This is the content of the register - so for every week one entry with all the register data
        /// </summary>
        /// <value>the content</value>
        public List<WeekDataObjects> WeekDataObjects { get; set; }
        /// <summary>
        /// This is the specific class of the Register
        /// </summary>
        /// <value>the class</value>
        public string Class { get; set; }
    }
}