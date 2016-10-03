using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using LAS_Interface.ForeignStuff;
using LAS_Interface.Types;

namespace LAS_Interface.UI
{
    public class EditClassesViewModel : INotifyPropertyChanged
    {
        private readonly EditClassesPopUpWindow _editClassesPopUpWindow;
        private readonly MainViewModel _mainViewModel;

        private List<Mstring> _classItems;
        private Mstring _selectedClass;

        /// <summary>
        /// Initializes the ViewModel for the EditClassesPopUpWindow
        /// </summary>
        /// <returns>nothing</returns>
        public EditClassesViewModel (EditClassesPopUpWindow eCPW, MainViewModel mvm)
        {
            _editClassesPopUpWindow = eCPW;
            _mainViewModel = mvm;

            CancelButtonClickCommand = new DelegateCommand (CancelButtonClick);
            SaveButtonClickCommand = new DelegateCommand (SaveButtonClick);
            AddButtonClickCommand = new DelegateCommand(AddButtonClick);
            RemoveButtonClickCommand = new DelegateCommand(RemoveButtonClick);

            ClassItems = new List<Mstring>(mvm.ClassItems.Select(s => new Mstring(s)));
        }
        
        public ICommand CancelButtonClickCommand { get; set; }
        public ICommand SaveButtonClickCommand { get; set; }
        public ICommand AddButtonClickCommand { get; set; }
        public ICommand RemoveButtonClickCommand { get; set; }

        /// <summary>
        /// The text of the big text box - so it represents the list of classes in form of a string
        /// </summary>
        /// <value>classes</value>
        public List<Mstring> ClassItems
        {
            get { return _classItems; }
            set
            {
                _classItems = value;
                OnPropertyChanged (nameof (ClassItems));
            }
        }

        /// <summary>
        /// The currently selected Class of the list
        /// </summary>
        /// <value>the class</value>
        public Mstring SelectedClass
        {
            get { return _selectedClass; }
            set
            {
                _selectedClass = value;
                OnPropertyChanged (nameof (SelectedClass));
                OnPropertyChanged (nameof (IsRemoveButtonEnabled));
            }
        }

        public bool IsRemoveButtonEnabled => SelectedClass != null;

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Is called when the cancel button is pressed - so it just closes the current window without saving anything
        /// </summary>
        public void CancelButtonClick (object param) => _editClassesPopUpWindow.Close ();

        /// <summary>
        /// Is called when the save button is pressed - so it changes the data of the classes in the MainViewModel and closes the current window
        /// </summary>
        public void SaveButtonClick (object param)
        {
            _mainViewModel.ClassItems = ClassItems.Select(mstring => mstring.Name).ToList();
            _editClassesPopUpWindow.Close ();
        }

        public void AddButtonClick(object param)
        {
            var n = new Mstring("");
            ClassItems = new List<Mstring> (ClassItems) { n };
            SelectedClass = n;
        }

        /// <summary>
        /// Is called when the user presses the remove button and removes the currently selected Item
        /// </summary>
        public void RemoveButtonClick (object param)
        {
            ClassItems.Remove (SelectedClass);
            ClassItems = new List<Mstring> (ClassItems);
        }

        /// <summary>
        /// Tells the view that a specific property has changed
        /// </summary>
        protected void OnPropertyChanged (string name)
                    => PropertyChanged?.Invoke (this, new PropertyChangedEventArgs (name));

        /// <summary>
        /// Is called from the code behind (when the user presses a key)
        /// </summary>
        public void OnKeyPress (object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete && SelectedClass != null)
                RemoveButtonClick (null);
        }
    }
}