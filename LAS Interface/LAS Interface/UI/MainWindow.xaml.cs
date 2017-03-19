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

        private void StudentsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TeacherDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}