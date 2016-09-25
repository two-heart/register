using System.Collections.Generic;
using System.ComponentModel;
using LAS_Interface.Types;

namespace LAS_Interface
{
    public class MainViewModel :INotifyPropertyChanged
    {
        private List<DataObject> _dataObjects;
        public event PropertyChangedEventHandler PropertyChanged;

        public List<DataObject> DataObjects
        {
            get { return _dataObjects; }
            set
            {
                _dataObjects = value;
                OnPropertyChanged(nameof(DataObjects));
            }
        }


        protected void OnPropertyChanged (string name)
        {
            PropertyChanged?.Invoke (this, new PropertyChangedEventArgs (name));
        }
    }
}