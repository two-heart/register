using System.Windows;

namespace LAS_Interface.UI
{
    /// <summary>
    ///     Interaction logic for EditClassesPopUpWindow.xaml
    /// </summary>
    public partial class EditClassesPopUpWindow : Window
    {
        /// <summary>
        /// Initializes the class popup window and sets the EditClassesViewModel as the data context
        /// </summary>
        /// <returns>nothing</returns>
        public EditClassesPopUpWindow (MainViewModel mvm)
        {
            InitializeComponent ();
            DataContext = new EditClassesViewModel (this, mvm);
        }
    }
}