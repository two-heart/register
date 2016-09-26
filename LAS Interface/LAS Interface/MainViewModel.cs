using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
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


        public List<ClassDataObjects> AllDataObjects;

        public ClassDataObjects AllDataObjectsOfCurrentClass
        {
            get
            { return AllDataObjects.FirstOrDefault(classDataObjectse => classDataObjectse.Class.Equals(SelectedClass)); }
            set
            {
                for (var i = 0; i < AllDataObjects.Count; i++)
                    if (AllDataObjects[i].Class == SelectedClass)
                        AllDataObjects[i] = value;
            }
        }
        public WeekDataObjects DataObjectsWeek
        {
            get { return AllDataObjectsOfCurrentClass.WeekDataObjects[CurrentWeek]; }
            set
            {
                AllDataObjectsOfCurrentClass.WeekDataObjects[CurrentWeek] = value; 
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;


        public MainViewModel ()
        {
            ClassItems = GeneralUtil.GetClasses ();
            ListItems = GeneralUtil.GetWeekList (DateTime.Now.Year);
            AllDataObjects = DataObjectsUtil.GenerateAllEmptyClassDataObjectses(ClassItems);
        }

        #region BoundVariables
        public List<DataObject> DataObjectsMonday
        {
            get
            {
                return DataObjectsWeek.Monday;
            }
            set
            {
                DataObjectsWeek.Monday = value;
                OnPropertyChanged (nameof (DataObjectsMonday));
            }
        }

        public List<DataObject> DataObjectsTuesday
        {
            get
            {
                return DataObjectsWeek.Tuesday;
            }
            set
            {
                DataObjectsWeek.Tuesday = value;
                OnPropertyChanged (nameof (DataObjectsTuesday));
            }
        }

        public List<DataObject> DataObjectsWednesday
        {
            get
            {
                return DataObjectsWeek.Wednesday;
            }
            set
            {
                DataObjectsWeek.Wednesday = value;
                OnPropertyChanged (nameof (DataObjectsWednesday));
            }
        }

        public List<DataObject> DataObjectsThursday
        {
            get
            {
                return DataObjectsWeek.Thursday;
            }
            set
            {
                DataObjectsWeek.Thursday = value;
                OnPropertyChanged (nameof (DataObjectsThursday));
            }
        }

        public List<DataObject> DataObjectsFriday
        {
            get
            {
                return DataObjectsWeek.Friday;
            }
            set
            {
                DataObjectsWeek.Friday = value;
                OnPropertyChanged (nameof (DataObjectsFriday));
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
                PropertyChangedWeek ();
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
                OnPropertyChanged (nameof (SelectedClass));
                PropertyChangedWeek();
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
        #endregion

        #region Commands
        #endregion

        public void PropertyChangedWeek ()
        {
            OnPropertyChanged (nameof (DataObjectsWeek));
            OnPropertyChanged (nameof (DataObjectsMonday));
            OnPropertyChanged (nameof (DataObjectsTuesday));
            OnPropertyChanged (nameof (DataObjectsWednesday));
            OnPropertyChanged (nameof (DataObjectsThursday));
            OnPropertyChanged (nameof (DataObjectsFriday));
        }

        protected void OnPropertyChanged (string name)
        {
            PropertyChanged?.Invoke (this, new PropertyChangedEventArgs (name));
        }
    }
}