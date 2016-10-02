using System.Collections.Generic;
using System.Linq;

namespace LAS_Interface.Types.Humans.Teacher
{
    public class Teacher
    {
        /// <summary>
        /// Initializes a new Teacher
        /// </summary>
        /// <returns>nothing</returns>
        public Teacher (string name, List<TeacherPropertiesForSpecificClass> properties)
        {
            TeacherProperties = properties;
            Name = name;
            TeachersViews =
                properties.Select (property => property.Class).ToList ().Select (s => new TeachersView (this, s)).ToList ();
        }

        /// <summary>
        /// The name of the teacher
        /// </summary>
        /// <value>the name</value>
        public string Name { get; set; }
        /// <summary>
        /// The Properties of the teacher - for each class the teacher educates he has a property
        /// </summary>
        /// <value>the properties</value>
        public List<TeacherPropertiesForSpecificClass> TeacherProperties { get; set; }
        /// <summary>
        /// The views of the teacher - one of them (the one with the current class) or no one (if he doesn't educates the class) is shown to the user
        /// </summary>
        /// <value>the views</value>
        public List<TeachersView> TeachersViews { get; set; }
    }
}