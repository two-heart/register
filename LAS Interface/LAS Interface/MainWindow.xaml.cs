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
    }
}
