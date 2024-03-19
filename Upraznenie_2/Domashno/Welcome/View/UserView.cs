using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.ViewModel;

namespace Welcome.View
{
    public class UserView
    {
        private UserViewModel _viewModel;
        public UserView(UserViewModel viewModel) { 
            _viewModel = viewModel;
        }

        public void Display()
        {
            Console.WriteLine("Welcome");
            Console.WriteLine($"User: {_viewModel.Name}");
            Console.WriteLine($"Role: {_viewModel.Role}");
            Console.WriteLine($"Faculty Number: {_viewModel.FacultyNumber}");
            Console.WriteLine($"Email: {_viewModel.Email}");
        }

        public void DisplayFacultyNumber()
        {
            Console.WriteLine("Welcome");
            Console.WriteLine($"User: {_viewModel.Name}");
            Console.WriteLine($"Faculty Number: {_viewModel.FacultyNumber}");
        }

        public void DisplayEmail()
        {
            Console.WriteLine("Welcome");
            Console.WriteLine($"User: {_viewModel.Name}");
            Console.WriteLine($"Email: {_viewModel.Email}");
        }
        public void DisplayError()
        {
            throw new Exception("An error occurred in the UserView class.");
        }
    }
}
