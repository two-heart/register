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
        public MainWindow()
        {
            DataContext = new MainViewModel(this);
            InitializeComponent();
        }

        private void TeacherDataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
            => e.Cancel = e.PropertyName == "Class";

        private void ClassLabel_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
            => ((MainViewModel) DataContext).OnMouseDoubleClick(sender, e, nameof(ClassLabel));
    }
}