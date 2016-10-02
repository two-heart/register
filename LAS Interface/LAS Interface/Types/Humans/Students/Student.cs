namespace LAS_Interface.Types.Humans.Students
{
    public class Student
    {
        private string _name;

        /// <summary>
        /// Initializes a new student
        /// </summary>
        /// <returns>nothing</returns>
        public Student (string name, string cclass)
        {
            StudentsView = new StudentsView (name);
            Name = name;
            Class = cclass;
        }

        /// <summary>
        /// The name of the student
        /// </summary>
        /// <value>the name</value>
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                StudentsView.Name = value;
            }
        }

        /// <summary>
        /// The class the student goes to
        /// </summary>
        /// <value>the class as a string</value>
        public string Class { get; set; }
        /// <summary>
        /// The view for the student - so not the whole student must be shown but the values in the view
        /// </summary>
        /// <value>the view</value>
        public StudentsView StudentsView { get; set; }
    }
}