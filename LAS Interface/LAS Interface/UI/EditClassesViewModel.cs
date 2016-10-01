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

        public EditClassesViewModel(EditClassesPopUpWindow eCPW, MainViewModel mvm)
        {
            _editClassesPopUpWindow = eCPW;
            _mainViewModel = mvm;

            CancelButtonClickCommand = new DelegateCommand(CancelButtonClick);
            SaveButtonClickCommand = new DelegateCommand(SaveButtonClick);

            if (_mainViewModel.ClassItems.Count <= 0)
                return;
            var temp = Text != null ? string.Copy(Text) : "";
            temp = _mainViewModel.ClassItems.Aggregate(temp, (current, item) => current + item + "\n");
            var foo = new char[temp.Length - 1];
            Array.Copy(temp.ToCharArray(), foo, temp.Length - 1);
            Text = new string(foo);
        }

        public ICommand CancelButtonClickCommand { get; set; }
        public ICommand SaveButtonClickCommand { get; set; }

        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                OnPropertyChanged(nameof(Text));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void CancelButtonClick(object param) => _editClassesPopUpWindow.Close();

        public void SaveButtonClick(object param)
        {
            _mainViewModel.ClassItems = Text.Split('\n').ToList();
            _editClassesPopUpWindow.Close();
        }

        protected void OnPropertyChanged(string name)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}