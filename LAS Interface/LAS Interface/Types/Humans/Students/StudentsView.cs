namespace LAS_Interface.Types.Humans.Students
{
    public class StudentsView
    {
        /// <summary>
        /// Initializes a new StudentsView - that is that what's shown to the user from the Student
        /// </summary>
        /// <returns>nothing</returns>
        public StudentsView (string name)
        {
            Name = name;
        }

        /// <summary>
        /// The name of the student
        /// </summary>
        /// <value>the name</value>
        public string Name { get; set; }
    }
}