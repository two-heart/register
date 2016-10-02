using System.Collections.Generic;

namespace LAS_Interface.Types.Humans.Teacher
{
    public class TeachersView
    {
        /// <summary>
        /// Initializes a new teachers view - the thing the user can see from the teacher. It later takes the data from a property that fits to the class
        /// </summary>
        /// <returns>nothing</returns>
        public TeachersView (string cclass, string name, List<TeacherPropertiesForSpecificClass> properties)
        {
            Class = cclass;
            Name = name;
            var prop = properties.Find (p => p.Class.Equals (cclass));
            ClassTeacher = prop.ClassTeacher;
            if ((prop.Subjects == null) || (prop.Subjects.Count <= 0))
                return;
            for (var index = 0; index < prop.Subjects.Count; index++)
            {
                var subject = prop.Subjects[index];
                Subjects += subject + (index < prop.Subjects.Count - 1 ? "," : "");
            }
        }

        /// <summary>
        /// see other initialization of TeachersView
        /// </summary>
        /// <returns>nothing</returns>
        public TeachersView (Teacher teacher, string cclass)
        {
            Class = cclass;
            Name = teacher.Name;
            var prop = teacher.TeacherProperties.Find (p => p.Class.Equals (cclass));
            if (prop == null)
                return;
            ClassTeacher = prop.ClassTeacher;
            if ((prop.Subjects == null) || (prop.Subjects.Count <= 0))
                return;
            for (var index = 0; index < prop.Subjects.Count; index++)
            {
                var subject = prop.Subjects[index];
                Subjects += subject + (index < prop.Subjects.Count - 1 ? "," : "");
            }
        }

        /// <summary>
        /// The name of the Teacher
        /// </summary>
        /// <value>the name</value>
        public string Name { get; set; }
        /// <summary>
        /// Determines wether or not the teacher is a class teacher of the current class
        /// </summary>
        /// <value>Is he ClassTeacher?</value>
        public bool ClassTeacher { get; set; }
        /// <summary>
        /// A list of the subjects the teacher educates to the current class in form of a string
        /// </summary>
        /// <value>the subjects</value>
        public string Subjects { get; set; }
        /// <summary>
        /// The current class of this view
        /// </summary>
        /// <value>the class</value>
        public string Class { get; set; }
    }
}