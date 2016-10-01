using System.Windows;
using System.Windows.Input;

namespace LAS_Interface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow ()
        {
            DataContext = new MainViewModel ();
            InitializeComponent ();
        }

        private void TeacherDataGrid_AutoGeneratingColumn (object sender, System.Windows.Controls.DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "Class")
                e.Cancel = true;
        }

        private void TeacherDataGrid_OnMouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            ((MainViewModel)DataContext).OnTeachersViewRightClick(sender, e);
        }

        private void StudentsDataGrid_OnMouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            ((MainViewModel) DataContext).OnStudentsViewRightClick(sender, e);
        }
    }
}
