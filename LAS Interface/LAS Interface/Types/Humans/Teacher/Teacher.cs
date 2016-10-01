using System.Collections.Generic;
using System.Linq;

namespace LAS_Interface.Types.Humans.Teacher
{
    public class Teacher
    {
        public Teacher(string name, List<TeacherPropertiesForSpecificClass> properties)
        {
            TeacherProperties = properties;
            Name = name;
            TeachersViews =
                properties.Select(property => property.Class).ToList().Select(s => new TeachersView(this, s)).ToList();
        }

        public string Name { get; set; }
        public List<TeacherPropertiesForSpecificClass> TeacherProperties { get; set; }
        public List<TeachersView> TeachersViews { get; set; }
    }
}