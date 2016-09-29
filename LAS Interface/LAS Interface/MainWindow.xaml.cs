using System.Windows;

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
    }
}
