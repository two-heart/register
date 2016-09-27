using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using LAS_Interface.Automation;
using LAS_Interface.ForeignStuff;
using LAS_Interface.PublicStuff;
using LAS_Interface.Types;
using LAS_Interface.Util;

namespace LAS_Interface
{
    public class MainViewModel : INotifyPropertyChanged
    {

        private List<string> _listItems;
        private int _currentWeek;
        private string _selectedClass;
        private List<string> _classItems;

        public List<ClassRegister> AllRegisters; //Those two files should be saved/loaded to/from the Data Source
        public List<TimeTable> AllTimeTables;

        public ClassRegister RegisterOfCurrentClass
        {
            get
            { return AllRegisters.FirstOrDefault (classDataObjectse => classDataObjectse.Class.Equals (SelectedClass)); }
            set
            {
                for (var i = 0; i < AllRegisters.Count; i++)
                    if (AllRegisters[i].Class.Equals(SelectedClass))
                        AllRegisters[i] = value;
            }
        }
        public WeekDataObjects RegisterOfCurrentWeek
        {
            get { return RegisterOfCurrentClass.WeekDataObjects[CurrentWeek]; }
            set
            {
                RegisterOfCurrentClass.WeekDataObjects[CurrentWeek] = value;
            }
        }

        public TimeTable TimeTableOfCurrentClass
        {
            get { return AllTimeTables.FirstOrDefault(timeTable => timeTable.Class.Equals(SelectedClass)); }
            set
            {
                for (var i = 0; i < AllTimeTables.Count; i++)
                    if (AllTimeTables[i].Class.Equals(SelectedClass))
                        AllTimeTables[i] = value;;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;


        public MainViewModel ()
        {
            ClassItems = GeneralUtil.GetClasses ();
            ListItems = GeneralUtil.GetWeekList (DateTime.Now.Year);
            AllRegisters = DataObjectsUtil.GenerateAllEmptyClassDataObjectses (ClassItems);
            AllTimeTables = TimeTableUtil.GetAllEmptyTimeTables(ClassItems);
            FillRegisterButtonClickCommand = new DelegateCommand(FillRegisterButtonClick);
        }

        public void FillRegisterButtonClick(object param)
        {
            AllRegisters = AutoFill.GetFilledRegissters(AllRegisters, AllTimeTables);
            PropertyChangedClass();
        }

        #region BoundVariables
        public List<DataObject> RegisterDataObjectsMonday
        {
            get
            {
                return RegisterOfCurrentWeek.Monday;
            }
            set
            {
                RegisterOfCurrentWeek.Monday = value;
                OnPropertyChanged (nameof (RegisterDataObjectsMonday));
            }
        }

        public List<DataObject> RegisterDataObjectsTuesday
        {
            get
            {
                return RegisterOfCurrentWeek.Tuesday;
            }
            set
            {
                RegisterOfCurrentWeek.Tuesday = value;
                OnPropertyChanged (nameof (RegisterDataObjectsTuesday));
            }
        }

        public List<DataObject> RegisterDataObjectsWednesday
        {
            get
            {
                return RegisterOfCurrentWeek.Wednesday;
            }
            set
            {
                RegisterOfCurrentWeek.Wednesday = value;
                OnPropertyChanged (nameof (RegisterDataObjectsWednesday));
            }
        }

        public List<DataObject> RegisterDataObjectsThursday
        {
            get
            {
                return RegisterOfCurrentWeek.Thursday;
            }
            set
            {
                RegisterOfCurrentWeek.Thursday = value;
                OnPropertyChanged (nameof (RegisterDataObjectsThursday));
            }
        }

        public List<DataObject> RegisterDataObjectsFriday
        {
            get
            {
                return RegisterOfCurrentWeek.Friday;
            }
            set
            {
                RegisterOfCurrentWeek.Friday = value;
                OnPropertyChanged (nameof (RegisterDataObjectsFriday));
            }
        }

        public List<string> ListItems
        {
            get { return _listItems; }
            set
            {
                _listItems = value;
                OnPropertyChanged (nameof (ListItems));
            }
        }

        public int CurrentWeek
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
            get
            {
                return _selectedClass;
            }
            set
            {
                _selectedClass = value;
                PropertyChangedClass ();
            }
        }

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
                OnPropertyChanged (nameof (TimeTableForView));
            }
        }
        #endregion

        #region Commands

        public ICommand FillRegisterButtonClickCommand { get; set; }
        #endregion

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
        }

        protected void OnPropertyChanged (string name)
        {
            PropertyChanged?.Invoke (this, new PropertyChangedEventArgs (name));
        }
    }
}