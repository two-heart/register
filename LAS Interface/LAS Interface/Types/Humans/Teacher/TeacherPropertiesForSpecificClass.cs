using System.Collections.Generic;
using System.Linq;

namespace LAS_Interface.Types.Humans.Teacher
{
    public class TeacherPropertiesForSpecificClass
    {
        /// <summary>
        /// Initializes a new Teacher property - a teacher property contains stuff for a single class the teacher educates.
        /// </summary>
        /// <returns>nothing</returns>
        public TeacherPropertiesForSpecificClass (string cclass, bool classTeacher, List<string> subjects)
        {
            Class = cclass;
            ClassTeacher = classTeacher;
            Subjects = subjects.FindAll (a => true).ToList ();
        }

        /// <summary>
        /// The class that is connected with this property
        /// </summary>
        /// <value>the class</value>
        public string Class { get; set; }
        /// <summary>
        /// A boolean that says, wether or not the teacher is the class teacher of the current class
        /// </summary>
        /// <value>is he classteacher</value>
        public bool ClassTeacher { get; set; }
        /// <summary>
        /// A list of the subjects connected to this property
        /// </summary>
        /// <value>the subjects</value>
        public List<string> Subjects { get; set; }
    }
}