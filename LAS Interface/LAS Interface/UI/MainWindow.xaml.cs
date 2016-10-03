using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LAS_Interface.UI
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes the MainWindow - so it initializes literally everything
        /// </summary>
        /// <returns>nothing</returns>
        public MainWindow ()
        {
            DataContext = new MainViewModel (this);
            InitializeComponent ();
        }

        /// <summary>
        /// This is there to prevent the auto-generate table from generating a class column
        /// </summary>
        private void TeacherDataGrid_AutoGeneratingColumn (object sender, DataGridAutoGeneratingColumnEventArgs e)
                    => e.Cancel = e.PropertyName == "Class";

        /// <summary>
        /// This method is called when the class-label is clicked and calls the OnDoubleClick Method from the MainViewModel
        /// </summary>
        private void ClassLabel_OnMouseDoubleClick (object sender, MouseButtonEventArgs e)
                    => ((MainViewModel) DataContext).OnMouseDoubleClick (sender, e, nameof (ClassLabel));

        /// <summary>
        /// Is called whenever a cell of the timeTable changed
        /// </summary>
        private void DataGrid_OnCurrentCellChanged (object sender, EventArgs e)
                    => ((MainViewModel) DataContext).TimeTableChanged (sender, e);

        /// <summary>
        /// Is called whenever the teachers list is changed
        /// </summary>
        private void TeacherDataGrid_OnCurrentCellChanged (object sender, EventArgs e)
                    => ((MainViewModel) DataContext).TeachersListChanged (sender, e);

        /// <summary>
        /// Is called whenever the students List is changed
        /// </summary>
        private void StudentsDataGrid_OnCurrentCellChanged (object sender, EventArgs e) => ((MainViewModel) DataContext).StudentsListChanged (sender, e);
    }
}