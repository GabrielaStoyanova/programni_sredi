using Welcome.Model;
using Welcome.View;
using Welcome.ViewModel;
using WelcomeExtended.Others;


namespace WelcomeExtended
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("WelcomeExtended");
            //to start this project => right-click on the project and choose
            // "Set as Startup Project" and then the selected project will be
            // highlighted with bold white color
            try
            {
                var user = new User {
                    Names = "John Smith",
                    Password = "password",
                    Role = Welcome.Others.UserRolesEnum.STUDENT
                };
                var viewModel = new UserViewModel(user);
                var view = new UserView(viewModel);
                view.Display();
                view.DisplayError();
            }catch (Exception ex)
            {
                var log = new ActionOnError(Delegates.Log);
                log(ex.Message);
            }finally
            {
                Console.WriteLine("Executed in any case!");
            }
        }
    }
}
