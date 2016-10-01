using System.Windows;

namespace LAS_Interface.UI
{
    /// <summary>
    ///     Interaction logic for EditClassesPopUpWindow.xaml
    /// </summary>
    public partial class EditClassesPopUpWindow : Window
    {
        public EditClassesPopUpWindow(MainViewModel mvm)
        {
            InitializeComponent();
            DataContext = new EditClassesViewModel(this, mvm);
        }
    }
}