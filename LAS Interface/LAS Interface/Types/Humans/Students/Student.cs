namespace LAS_Interface.Types.Humans.Students
{
    public class Student
    {
        private string _name;
        public string Name {
            get { return _name; }
            set
            {
                _name = value;
                StudentsView.Name = value;
            } }
        public string Class { get; set; }
        public StudentsView StudentsView { get; set; }

        public Student(string name, string cclass)
        {
            StudentsView = new StudentsView (name);
            Name = name;
            Class = cclass;
        }
    }
}