using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using LAS_Interface.Automation;
using LAS_Interface.ForeignStuff;
using LAS_Interface.PublicStuff;
using LAS_Interface.Types;
using LAS_Interface.Types.Humans.Students;
using LAS_Interface.Types.Humans.Teacher;
using LAS_Interface.Util;
using DataObject = LAS_Interface.Types.DataObject;

namespace LAS_Interface.UI
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly MainWindow _mainWindow;
        private List<string> _classItems;
        private string _currentWeek;

        private List<string> _weekListItems;
        private string _selectedClass;
        private DateTime _selectedDate;
        private StudentsView _selectedStudent;
        private TeachersView _selectedTeacher;
        private List<Student> _students;
        private List<Teacher> _teachers;

        /// <summary>
        /// Initializes the MainViewModel - the ViewModel to the MainWindow - so literally everything
        /// </summary>
        /// <returns>nothing</returns>
        public MainViewModel (MainWindow mw)
        //TODO Handle Runtime Changed Date
        {
            _mainWindow = mw;

            SelectedDate = DateTime.Now;
            ClassItems = GeneralUtil.GetClasses ();
            AllRegisters = DataObjectsUtil.GenerateAllEmptyClassDataObjectses (ClassItems, SelectedDate, SelectedDate.AddYears (1), WeekListItems);
            AllTimeTables = TimeTableUtil.GetAllEmptyTimeTables (ClassItems);

            FillRegisterButtonClickCommand = new DelegateCommand (FillRegisterButtonClick);
            AddStudentCommand = new DelegateCommand (AddStudent);
            AddTeacherCommand = new DelegateCommand (AddTeacher);
            DeleteStudentCommand = new DelegateCommand (DeleteStudent);
            DeleteTeacherCommand = new DelegateCommand (DeleteTeacher);

            Teachers = new List<Teacher> ();
            Students = new List<Student> ();
            SelectedClass = ClassItems.FirstOrDefault ();
        }

        public ClassRegister RegisterOfCurrentClass
        {
            get
            {
                return AllRegisters.FirstOrDefault(classDataObjectse => classDataObjectse.Class.Equals(SelectedClass));
            }
            set
            {
                for (var i = 0; i < AllRegisters.Count; i++)
                    if (AllRegisters[i].Class.Equals(SelectedClass))
                        AllRegisters[i] = value;
            }
        }

        public WeekDataObjects RegisterOfCurrentWeek
        {
            get { return RegisterOfCurrentClass.WeekDataObjects.FirstOrDefault(objects => objects.Week.Equals(CurrentWeek)); }
            set
            {
                for (var i = 0; i < RegisterOfCurrentClass.WeekDataObjects.Count; i++)
                    if (RegisterOfCurrentClass.WeekDataObjects[i].Week.Equals(CurrentWeek))
                        RegisterOfCurrentClass.WeekDataObjects[i] = value;
            }
        }

        public TimeTable TimeTableOfCurrentClass
        {
            get { return AllTimeTables.FirstOrDefault(timeTable => timeTable.Class.Equals(SelectedClass)); }
            set
            {
                for (var i = 0; i < AllTimeTables.Count; i++)
                    if (AllTimeTables[i].Class.Equals(SelectedClass))
                        AllTimeTables[i] = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// The method to the FillRegister Button. Applies the Autofill to the register
        /// </summary>
        public void FillRegisterButtonClick (object param)
        {
            AllRegisters = AutoFill.GetFilledRegisters (AllRegisters, AllTimeTables, Teachers);
            PropertyChangedClass ();
        }

        /// <summary>
        /// The method that is called when the option AddStudent is Selected in the ContextMenu of the Students list. Simply adds an empty student to the Students list
        /// </summary>
        public void AddStudent (object param)
        {
            var temp = Students.ToList ();
            temp.Add (new Student ("", SelectedClass));
            Students = temp;
        }

        /// <summary>
        /// The method that is called when the option AddTeacher  is Selected in the ContextMenu of the Teacher list. Simply adds an empty Teacher to the Teacher list
        /// </summary>
        public void AddTeacher (object param)
        {
            var temp = Teachers.ToList ();
            temp.Add (new Teacher ("",
                new List<TeacherPropertiesForSpecificClass>
                {
                    new TeacherPropertiesForSpecificClass(SelectedClass, false, new List<string>())
                }));
            Teachers = temp;
        }

        /// <summary>
        /// The method that is called when the option DeleteStudent is selected in the ContextMenu of the Studentslist - deletes the current selelcted Student
        /// </summary>
        public void DeleteStudent (object param)
        {
            var temp = Students.ToList ();
            temp.Remove (temp.FirstOrDefault (
                student =>
                    student.Class.Equals (SelectedClass) && student.StudentsView.Equals (SelectedStudent) &&
                    student.Name.Equals (SelectedStudent.Name)));
            Students = temp;
        }

        /// <summary>
        /// The method that is called when the option DeleteTeacher is selected in the ContextMenu of the Teacherslist - deletes the current selelcted Teacher
        /// </summary>
        public void DeleteTeacher (object param)
        {
            var temp = Teachers.ToList ();
            var ct =
                temp.FirstOrDefault (
                    teacher =>
                        teacher.Name.Equals (SelectedTeacher.Name) &&
                        teacher.TeachersViews.Any (view => view.Equals (SelectedTeacher)) &&
                        teacher.TeacherProperties.Any (
                            c => c.Class.Equals (SelectedClass) && Equals (c.ClassTeacher, SelectedTeacher.ClassTeacher)));
            ct?.TeacherProperties.Remove (ct.TeacherProperties.FirstOrDefault (c => c.Class.Equals (SelectedClass)));
            Teachers = temp;
        }

        #region External Called Methods

        /// <summary>
        /// This method can be used whenever the user doubleclicks an item in the MainWindow - which item the user clicked on is specified in the name parameter
        /// </summary>
        public void OnMouseDoubleClick (object sender, MouseButtonEventArgs e, string clickedItem)
        {
            if (clickedItem.Equals (nameof (_mainWindow.ClassLabel)))
            {
                var editClassesPopUpWindow = new EditClassesPopUpWindow (this);
                editClassesPopUpWindow.InitializeComponent ();
                editClassesPopUpWindow.ShowDialog ();
            }
        }

        #endregion

        /// <summary>
        /// Calls the OnPropertyChanged Method on all for class-changes relevant Properties
        /// </summary>
        public void PropertyChangedClass ()
        {
            OnPropertyChanged (nameof (SelectedClass));
            OnPropertyChanged (nameof (RegisterOfCurrentWeek));
            OnPropertyChanged (nameof (RegisterDataObjectsMonday));
            OnPropertyChanged (nameof (RegisterDataObjectsTuesday));
            OnPropertyChanged (nameof (RegisterDataObjectsWednesday));
            OnPropertyChanged (nameof (RegisterDataObjectsThursday));
            OnPropertyChanged (nameof (RegisterDataObjectsFriday));
            OnPropertyChanged (nameof (TimeTableForView));
            OnPropertyChanged (nameof (TeachersViews));
            OnPropertyChanged (nameof (StudentsViews));
            OnPropertyChanged (nameof (Students));
            OnPropertyChanged (nameof (Teachers));
        }

        /// <summary>
        /// Tells the view that a specific property has changed
        /// </summary>
        protected void OnPropertyChanged (string name)
                    => PropertyChanged?.Invoke (this, new PropertyChangedEventArgs (name));

        #region External Variables -> Those four vars & the two other vars (SelectedDate & ClassItems) should be saved/loaded to/from the Data Source

        /// <summary>
        /// Contains all the registers (for every week) from all the classes
        /// </summary>
        /// <value>registers</value>
        public List<ClassRegister> AllRegisters { get; set; }
        /// <summary>
        /// Contains all the TimeTables for every class
        /// </summary>
        /// <value>The timeTables</value>
        public List<TimeTable> AllTimeTables { get; set; }
        public List<Teacher> Teachers
        {
            get { return _teachers; }
            set
            {
                if ((value != null) && (value.Count > 0))
                    foreach (var teacher in value.ToList())
                        if (teacher.TeacherProperties?.Count <= 0)
                            value.Remove(teacher);
                _teachers = value;
                OnPropertyChanged(nameof(TeachersViews));
            }
        }
        public List<Student> Students
        {
            get { return _students; }
            set
            {
                _students = value;
                OnPropertyChanged(nameof(StudentsViews));
            }
        }

        #endregion //Don't forget the SelectedDate & the ClassItems!

        #region BoundVariables

        public List<DataObject> RegisterDataObjectsMonday
        {
            get { return RegisterOfCurrentWeek.Monday; }
            set
            {
                RegisterOfCurrentWeek.Monday = value;
                OnPropertyChanged(nameof(RegisterDataObjectsMonday));
            }
        }

        public List<DataObject> RegisterDataObjectsTuesday
        {
            get { return RegisterOfCurrentWeek.Tuesday; }
            set
            {
                RegisterOfCurrentWeek.Tuesday = value;
                OnPropertyChanged(nameof(RegisterDataObjectsTuesday));
            }
        }

        public List<DataObject> RegisterDataObjectsWednesday
        {
            get { return RegisterOfCurrentWeek.Wednesday; }
            set
            {
                RegisterOfCurrentWeek.Wednesday = value;
                OnPropertyChanged(nameof(RegisterDataObjectsWednesday));
            }
        }

        public List<DataObject> RegisterDataObjectsThursday
        {
            get { return RegisterOfCurrentWeek.Thursday; }
            set
            {
                RegisterOfCurrentWeek.Thursday = value;
                OnPropertyChanged(nameof(RegisterDataObjectsThursday));
            }
        }

        /// <summary>
        /// The register Data for Friday - same for the other days
        /// </summary>
        /// <value>register Dataobjects</value>
        public List<DataObject> RegisterDataObjectsFriday
        {
            get { return RegisterOfCurrentWeek.Friday; }
            set
            {
                RegisterOfCurrentWeek.Friday = value;
                OnPropertyChanged (nameof (RegisterDataObjectsFriday));
            }
        }

        public List<string> WeekListItems
        {
            get { return _weekListItems; }
            set
            {
                _weekListItems = value;
                OnPropertyChanged(nameof(WeekListItems));
            }
        }

        /// <summary>
        /// Represents the current selected Week as a string.
        /// </summary>
        /// <value>the week</value>
        public string CurrentWeek
        {
            get { return _currentWeek; }
            set
            {
                _currentWeek = value;
                OnPropertyChanged (nameof (CurrentWeek));
                PropertyChangedClass ();
            }
        }

        public string SelectedClass
        {
            get { return _selectedClass; }
            set
            {
                _selectedClass = value;
                PropertyChangedClass();
            }
        }

        /// <summary>
        /// A list of current available classes
        /// </summary>
        /// <value>the classes</value>
        public List<string> ClassItems
        {
            get { return _classItems; }
            set
            {
                _classItems = value;
                OnPropertyChanged (nameof (ClassItems));
            }
        }

        public List<TimeTableRow> TimeTableForView
        {
            get { return TimeTableOfCurrentClass.TimeTableRows; }
            set
            {
                TimeTableOfCurrentClass.TimeTableRows = value;
                OnPropertyChanged(nameof(TimeTableForView));
            }
        }

        public List<TeachersView> TeachersViews
        {
            get
            {
                return
                    Teachers.SelectMany(
                            teacher => teacher.TeachersViews.Where(view => view.Class.Equals(SelectedClass)).ToList())
                        .ToList();
            }
            set //Don't add TeachersViews - Always add Teachers!
            {
                for (var i = 0; i < Teachers.Count; i++)
                {
                    Teachers[i].Name = value[i].Name;
                    foreach (var t in Teachers[i].TeacherProperties)
                    {
                        if (!t.Class.Equals(SelectedClass))
                            continue;
                        t.Subjects = value[i].Subjects.Split(',').ToList();
                        t.ClassTeacher = value[i].ClassTeacher;
                    }
                }
                OnPropertyChanged(nameof(TeachersViews));
            }
        }

        public List<StudentsView> StudentsViews
        {
            get
            {
                return
                    Students.Where(student => student.Class.Equals(SelectedClass))
                        .Select(student => student.StudentsView)
                        .ToList();
            }
            set //see at TeachersView
            {
                for (var i = 0; i < Students.Count; i++)
                    if (Students[i].Class.Equals(SelectedClass))
                    {
                        Students[i].Name = value[i].Name;
                        Students[i].StudentsView.Name = value[i].Name;
                    }
                OnPropertyChanged(nameof(StudentsViews));
            }
        }

        public DateTime SelectedDate //TODO Handle Runtime Changed Date
        {
            get { return _selectedDate; }
            set
            {
                _selectedDate = value;
                OnPropertyChanged(nameof(SelectedDate));
                WeekListItems = TimeUtil.GetWeekList(SelectedDate, TimeUtil.GetWeeksTillDate(value, value.AddYears(1)));
            }
        }

        public StudentsView SelectedStudent
        {
            get { return _selectedStudent; }
            set
            {
                _selectedStudent = value;
                OnPropertyChanged(nameof(SelectedStudent));
                OnPropertyChanged(nameof(ContextMenuDeleteStudentItemVisibility));
            }
        }

        public TeachersView SelectedTeacher
        {
            get { return _selectedTeacher; }
            set
            {
                _selectedTeacher = value;
                OnPropertyChanged(nameof(SelectedTeacher));
                OnPropertyChanged(nameof(ContextMenuDeleteTeacherItemVisibility));
            }
        }

        /// <summary>
        /// Determines wether or not the DeleteStudent Option int the context menu for the students list is visible - it pretends on wether or not the user has selected a student
        /// </summary>
        /// <value>visibility for deletestudent option</value>
        public Visibility ContextMenuDeleteStudentItemVisibility
                    => SelectedStudent != null ? Visibility.Visible : Visibility.Collapsed;

        /// <summary>
        /// Determines wether or not the DeleteTeacher Option int the context menu for the teachers list is visible - it pretends on wether or not the user has selected a teacher
        /// </summary>
        /// <value>Visbility of DeleteTeacher option</value>
        public Visibility ContextMenuDeleteTeacherItemVisibility
                    => SelectedTeacher != null ? Visibility.Visible : Visibility.Collapsed;

        #endregion

        #region Commands

        public ICommand FillRegisterButtonClickCommand { get; set; }
        public ICommand AddStudentCommand { get; set; }
        public ICommand AddTeacherCommand { get; set; }
        public ICommand DeleteStudentCommand { get; set; }
        public ICommand DeleteTeacherCommand { get; set; }

        #endregion
    }
}