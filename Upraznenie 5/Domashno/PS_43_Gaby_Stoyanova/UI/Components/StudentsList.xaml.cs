using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DataLayer.Database;
using DataLayer.Model;
using UI.Extras;

namespace UI.Components
{
    /// <summary>
    /// Interaction logic for StudentsList.xaml
    /// </summary>
    public partial class StudentsList : UserControl
    {
        private Logger logger;
        public StudentsList()
        {
            InitializeComponent();

            // Initialize the logger with a log file path
            string logFilePath = "studentslist_log.txt"; // Specify the log file path
            logger = new Logger(logFilePath);

            // Log a message when the StudentsList is initialized
            logger.Log("StudentsList initialized.");

            using (var context = new DatabaseContext())
            {
                var records = context.Users.ToList();
                students.DataContext = records;
            }
        }

        public void LoggerDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // Log the double-click event
            logger.Log("User double-clicked on a student record.");

            // Retrieve the selected student from the DataGrid
            // Note: Replace "YourDataType" with the actual type of your student records
            var selectedStudent = students.SelectedItem as DatabaseUser;

            // Format and display the selected student's details
            if (selectedStudent != null)
            {
                string formattedDetails = $"ID: {selectedStudent.Id}, Name: {selectedStudent.Names}, Role: {selectedStudent.Role}, Expires: {selectedStudent.Expires}, Password: {selectedStudent.Password}"; 
                MessageBox.Show(formattedDetails, "Student Details", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        public void LogEvent()
        {
            // Log the event
            logger.Log("Event logged from StudentsList component.");
        }
    }
}
