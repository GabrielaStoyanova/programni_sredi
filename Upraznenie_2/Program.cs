using Welcome.Model;
using Welcome.Others;
using Welcome.View;
using Welcome.ViewModel;

namespace Welcome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            User user = new User();
            user.Names = "Gaby Stoyanova";
            user.Password = "password123";
            user.Role = UserRolesEnum.ADMIN;
            user.facultyNumber = "121221000";
            user.email = "example@tu-sofia.bg";

            UserViewModel userViewModel = new UserViewModel(user);
            UserView userView = new UserView(userViewModel);
            userView.Display();
            userView.DisplayFacultyNumber();
            userView.DisplayEmail();
        }
    }
}
