using System;
using System.Collections.Generic;
using System.ComponentModel;
using LAS_Interface.Types;
using LAS_Interface.Util;

namespace LAS_Interface
{
    public class MainViewModel :INotifyPropertyChanged
    {
        private List<DataObject> _dataObjectsMonday;
        private List<DataObject> _dataObjectsTuesday;
        private List<DataObject> _dataObjectsWedenesday;
        private List<DataObject> _dataObjectsThursday;
        private List<DataObject> _dataObjectsFriday;
        private List<string> _listItems;

        public int EntriesPerDay = 8;

        public List<List<DataObject>> AllDataObjects;

        public event PropertyChangedEventHandler PropertyChanged;


        public MainViewModel()
        {
            ListItems = GeneralUtil.GetWeekList(DateTime.Now.Year);
            InitializeDataObjects();
        }

        public void InitializeDataObjects()
        {
            DataObjectsMonday = DataObjectsUtil.GetnEmptyDataObjects(EntriesPerDay);
            DataObjectsTuesday = DataObjectsUtil.GetnEmptyDataObjects (EntriesPerDay);
            DataObjectsWednesday = DataObjectsUtil.GetnEmptyDataObjects (EntriesPerDay);
            DataObjectsThursday = DataObjectsUtil.GetnEmptyDataObjects (EntriesPerDay);
            DataObjectsFriday = DataObjectsUtil.GetnEmptyDataObjects (EntriesPerDay);
        }


        public List<DataObject> DataObjectsMonday
        {
            get
            {
                return _dataObjectsMonday;
            }
            set
            {
                _dataObjectsMonday = value;
                OnPropertyChanged(nameof(DataObjectsMonday));
            }
        }

        public List<DataObject> DataObjectsTuesday
        {
            get
            {
                return _dataObjectsTuesday;
            }
            set
            {
                _dataObjectsTuesday = value;
                OnPropertyChanged(nameof(DataObjectsTuesday));
            }
        }

        public List<DataObject> DataObjectsWednesday
        {
            get
            {
                return _dataObjectsWedenesday;
            }
            set
            {
                _dataObjectsWedenesday = value;
                OnPropertyChanged(nameof(DataObjectsWednesday));
            }
        }

        public List<DataObject> DataObjectsThursday
        {
            get
            {
                return _dataObjectsThursday;
            }
            set
            {
                _dataObjectsThursday = value;
                OnPropertyChanged(nameof(DataObjectsThursday));
            }
        }

        public List<DataObject> DataObjectsFriday
        {
            get
            {
                return _dataObjectsFriday;
            }
            set
            {
                _dataObjectsFriday = value;
                OnPropertyChanged(nameof(DataObjectsFriday));
            }
        }

        public List<string> ListItems
        {
            get {return _listItems;}
            set
            {
                _listItems = value;
                OnPropertyChanged(nameof(ListItems));
            }
        }
        
        protected void OnPropertyChanged (string name)
        {
            PropertyChanged?.Invoke (this, new PropertyChangedEventArgs (name));
        }
    }
}