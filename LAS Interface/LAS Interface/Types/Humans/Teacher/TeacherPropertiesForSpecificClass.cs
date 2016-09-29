using System.Collections.Generic;
using System.Linq;

namespace LAS_Interface.Types.Humans.Teacher
{
    public class TeacherPropertiesForSpecificClass
    {
        public string Class { get; set; }
        public bool ClassTeacher { get; set; }
        public List<string> Subjects { get; set; }

        public TeacherPropertiesForSpecificClass(string cclass, bool classTeacher, List<string> subjects)
        {
            Class = cclass;
            ClassTeacher = classTeacher;
            Subjects = subjects.FindAll(a => true).ToList();
        }
    }
}