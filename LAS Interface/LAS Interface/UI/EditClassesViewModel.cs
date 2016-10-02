using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using LAS_Interface.ForeignStuff;

namespace LAS_Interface.UI
{
    public class EditClassesViewModel : INotifyPropertyChanged
    {
        private readonly EditClassesPopUpWindow _editClassesPopUpWindow;
        private readonly MainViewModel _mainViewModel;

        private string _text;

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

            if (_mainViewModel.ClassItems.Count <= 0)
                return;
            var temp = Text != null ? string.Copy (Text) : "";
            temp = _mainViewModel.ClassItems.Aggregate (temp, (current, item) => current + item + "\n");
            var foo = new char[temp.Length - 1];
            Array.Copy (temp.ToCharArray (), foo, temp.Length - 1);
            Text = new string (foo);
        }
        
        public ICommand CancelButtonClickCommand { get; set; }
        public ICommand SaveButtonClickCommand { get; set; }

        /// <summary>
        /// The text of the big text box - so it represents the list of classes in form of a string
        /// </summary>
        /// <value>classes</value>
        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                OnPropertyChanged (nameof (Text));
            }
        }

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
            _mainViewModel.ClassItems = Text.Split ('\n').ToList ();
            _editClassesPopUpWindow.Close ();
        }

        /// <summary>
        /// Tells the view that a specific property has changed
        /// </summary>
        protected void OnPropertyChanged (string name)
                    => PropertyChanged?.Invoke (this, new PropertyChangedEventArgs (name));
    }
}