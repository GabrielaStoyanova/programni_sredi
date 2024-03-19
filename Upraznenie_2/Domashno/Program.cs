using Microsoft.Extensions.Logging;
using Welcome.Model;
using Welcome.View;
using Welcome.ViewModel;
using WelcomeExtended.Loggers;
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

            // Example usage of HashLogger
            HashLogger logger = new HashLogger("Example");
            logger.Log(LogLevel.Information, new EventId(1), "Logging information", null, (state, ex) => state.ToString());
            logger.Log(LogLevel.Error, new EventId(2), "Logging error", null, (state, ex) => state.ToString());

            // Get recorded messages
            string[] recordedMessages = logger.GetRecordedMessages();
            foreach (string message in recordedMessages)
            {
                Console.WriteLine(message);
            }

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
