using System;
using System.Collections.Generic;
using System.ComponentModel;
using LAS_Interface.Types;
using LAS_Interface.Util;

namespace LAS_Interface
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public WeekDataObjects DataObjectsWeek
        {
            get { return AllDataObjects[CurrentWeek]; } 
            set { AllDataObjects[CurrentWeek] = value; }
        }

        private List<string> _listItems;
        private int _currentWeek;
        public int EntriesPerDay = 8;

        public List<WeekDataObjects> AllDataObjects;

        public event PropertyChangedEventHandler PropertyChanged;


        public MainViewModel ()
        {
            ListItems = GeneralUtil.GetWeekList (DateTime.Now.Year);
            AllDataObjects = DataObjectsUtil.GetEmptyAllDataObjects(EntriesPerDay, GeneralUtil.WeeksPerYear);
        }


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
                OnPropertyChanged(nameof(CurrentWeek));
                PropertyChangedWeek();
            }
        }

        public void PropertyChangedWeek()
        {
            OnPropertyChanged(nameof(DataObjectsWeek));
            OnPropertyChanged(nameof(DataObjectsMonday));
            OnPropertyChanged(nameof(DataObjectsTuesday));
            OnPropertyChanged(nameof(DataObjectsWednesday));
            OnPropertyChanged(nameof(DataObjectsThursday));
            OnPropertyChanged(nameof(DataObjectsFriday));
        }

        protected void OnPropertyChanged (string name)
        {
            PropertyChanged?.Invoke (this, new PropertyChangedEventArgs (name));
        }
    }
}