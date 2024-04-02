using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LogButtonClick(object sender, RoutedEventArgs e)
        {
            // Check if there is a selected student
            if (studentsList.students.SelectedItem != null)
            {
                // Trigger the double-click event handler manually
                studentsList.LoggerDoubleClick(sender, new MouseButtonEventArgs(Mouse.PrimaryDevice, 0, MouseButton.Left));
            }
            else
            {
                // Log a message indicating that no student is selected
                MessageBox.Show("Please select a student before logging an event.", "No Student Selected", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}