using System.Collections.Generic;
using System.Linq;

namespace LAS_Interface.Types.Humans.Teacher
{
    public class TeachersView
    {
        public string Name { get; set; }
        public bool ClassTeacher { get; set; }
        public string Subjects { get; set; }
        public string Class { get; set; }

        public TeachersView(string cclass, string name, List<TeacherPropertiesForSpecificClass> properties)
        {
            Class = cclass;
            Name = name;
            var prop = properties.Find(p => p.Class.Equals(cclass));
            ClassTeacher = prop.ClassTeacher;
            if (prop.Subjects == null || prop.Subjects.Count <= 0)
                return;
            for (var index = 0; index < prop.Subjects.Count; index++)
            {
                var subject = prop.Subjects[index];
                Subjects += subject + (index < prop.Subjects.Count - 1 ? "," : "");
            }
        }

        public TeachersView(Teacher teacher, string cclass)
        {
            Class = cclass;
            Name = teacher.Name;
            var prop = teacher.TeacherProperties.Find(p => p.Class.Equals(cclass));
            if (prop == null)
                return;
            ClassTeacher = prop.ClassTeacher;
            if (prop.Subjects == null || prop.Subjects.Count <= 0)
                return;
            for (var index = 0; index < prop.Subjects.Count; index++)
            {
                var subject = prop.Subjects[index];
                Subjects += subject + (index < prop.Subjects.Count - 1 ? "," : "");
            }
        }
    }
}